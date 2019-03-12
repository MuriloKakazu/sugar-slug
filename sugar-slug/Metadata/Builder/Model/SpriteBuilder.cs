using Newtonsoft.Json;
using SugarSlug.IO.Serialization.Extensions;
using SugarSlug.Metadata.Builder.Exceptions;
using SugarSlug.Metadata.Builder.Templates;
using SugarSlug.Metadata.Model;
using System;
using System.Windows.Media.Imaging;

namespace SugarSlug.Metadata.Builder.Model {
    public class SpriteBuilder : IAssetBuilder<Uri, Sprite> {
        public Sprite Build(Uri source) {
            try {
                var asset = new Sprite().FromJson(source);

                SetSource(asset, source);
                LoadImage(asset);

                return asset;
            } catch (JsonSerializationException e) {
                throw new AssetBuildException($"Asset deserialization failed. {e.Message}");
            } catch (AssetBuildException e) {
                throw new AssetBuildException(e.Message);
            } catch (Exception e) {
                throw new AssetBuildException("Unknown error building asset.");
            }
        }

        protected void SetSource(Sprite sprite, Uri source) {
            try {
                sprite.Source = source;
            } catch (Exception e) {
                throw new AssetBuildException($"Error setting asset source. {e.Message}");
            }
        }

        protected void LoadImage(Sprite sprite) {
            try {
                sprite.Image = new BitmapImage(sprite.ImageSource) {
                    CacheOption = BitmapCacheOption.OnLoad
                };
            } catch (Exception e) {
                throw new AssetBuildException($"Error loading asset image. {e.Message}");
            }
        }
    }
}
