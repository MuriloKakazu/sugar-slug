using SugarSlug.Metadata.Builder;
using SugarSlug.Metadata.Model;
using System;
using System.IO;

namespace SugarSlug.Metadata.Loader {
    public class AssetLoader {
        protected AssetBuilderDirector Director { get; set; }
        public static AssetLoader Instance { get; protected set; }

        static AssetLoader() {
            Instance = new AssetLoader();
        }

        protected AssetLoader() {
            Director = AssetBuilderDirector.Instance;
        }

        public AssetLoader Encache(Asset asset) {
            Cache.Instance.Add(asset.CacheKey, asset);

            return this;
        }

        public AssetLoader EncacheFile(Uri source) {
            var result = Director.Build(source);

            return Encache(result as Asset);
        }

        public AssetLoader EncacheAll(Uri directorySource) {
            var files = Directory.GetFiles(directorySource.AbsolutePath, "*.json");

            foreach (String fileSource in files) {
                var path = new Uri(fileSource);

                EncacheFile(path);
            }

            return this;
        }

        public AssetLoader EncacheAllRecursively(Uri directorySource) {
            var dir = directorySource;
            var subdirs = Directory.GetDirectories(dir.AbsolutePath);

            EncacheAll(dir);

            foreach (var dirSource in subdirs) {
                var path = new Uri(dirSource);

                EncacheAllRecursively(path);
            }

            return this;
        }
    }
}
