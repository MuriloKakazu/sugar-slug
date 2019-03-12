using SugarSlug.IO.Serialization.Extensions;
using SugarSlug.Metadata.Builder.Templates;
using SugarSlug.Metadata.Model;
using System;

namespace SugarSlug.Metadata.Builder.Model {
    public class SoundFxBuilder : IAssetBuilder<Uri, SoundFX> {
        public SoundFX Build(Uri source) {
            var asset = new SoundFX().FromJson(source);

            // process (to do)

            return asset;
        }
    }
}
