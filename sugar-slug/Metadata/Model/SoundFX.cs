using Newtonsoft.Json;

namespace SugarSlug.Metadata.Model {
    public class SoundFX : Asset {
        [JsonRequired]
        public new AssetType Type => 
            AssetType.SoundFX;
    }
}
