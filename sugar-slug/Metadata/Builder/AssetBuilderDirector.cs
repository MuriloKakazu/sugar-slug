using Newtonsoft.Json;
using SugarSlug.IO.Serialization.Extensions;
using SugarSlug.Metadata.Builder.Exceptions;
using SugarSlug.Metadata.Builder.Model;
using SugarSlug.Metadata.Builder.Templates;
using SugarSlug.Metadata.Model;
using SugarSlug.Metadata.Templates;
using System;

namespace SugarSlug.Metadata.Builder {
    public class AssetBuilderDirector {
        public static AssetBuilderDirector Instance { get; protected set; }

        static AssetBuilderDirector() {
            Instance = new AssetBuilderDirector();
        }

        protected AssetBuilderDirector() { }

        public IAsset Build(Uri source) {
            try {
                var partialAsset = GetPartialAsset(source);
                var builder = GetBuilder(partialAsset.Type);

                return builder.Build(source);
            } catch (JsonSerializationException e) {
                throw new AssetBuildException($"Partial asset deserialization failed. {e.Message}");
            } catch (AssetBuildException e) {
                throw new AssetBuildException($"Could not build asset. {e.Message}");
            } catch (Exception e) {
                throw new AssetBuildException($"Unknown error on asset director. {e.Message}");
            }
        }

        protected PartialAsset GetPartialAsset(Uri source) {
            return new PartialAsset().FromJson(source);
        }

        protected IAssetBuilder<Uri, IAsset> GetBuilder(AssetType type) {
            switch (type) {
                case AssetType.Sprite:
                    return new SpriteBuilder() as IAssetBuilder<Uri, IAsset>;
                case AssetType.SoundFX:
                    return new SoundFxBuilder() as IAssetBuilder<Uri, IAsset>;
                default:
                    throw new AssetBuildException($"Asset builder could not be determined.");
            }
        }
    }
}
