using Newtonsoft.Json;
using SugarSlug.Caching.Templates;
using SugarSlug.Metadata.Templates;
using System;

namespace SugarSlug.Metadata.Model {
    public abstract class Asset : IAsset, ICacheable {
        [JsonRequired]
        public String ID { get; set; }
        [JsonIgnore]
        public String CacheKey => ID;
        [JsonIgnore]
        public Uri Source { get; set; }
        [JsonRequired]
        public AssetType Type { get; set; }

        [JsonConstructor]
        public Asset() { }

        public Asset(String id, Uri source) {
            ID = id;
            Source = source;
        }
    }
}
