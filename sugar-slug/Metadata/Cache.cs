using SugarSlug.Caching.Templates;
using SugarSlug.Metadata.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SugarSlug.Metadata {
    public class Cache : ICache<String, Asset> {
        public static Cache Instance { get; protected set; }

        static Cache() {
            Instance = new Cache();
        }

        IDictionary<String, Asset> InternalCache { get; set; }
        public int Size => InternalCache.Count;

        protected Cache() {
            InternalCache = new Dictionary<String, Asset>();
        }

        public ICache<String, Asset> Add(String key, Asset asset) {
            Validate(asset);
            InternalCache.Add(key, asset);
            return this;
        }

        public ICache<String, Asset> AddRange(IDictionary<String, Asset> mappedAssets) {
            var keys = mappedAssets.Keys.ToList();

            keys.ForEach(key => Add(key, mappedAssets[key]));
            return this;
        }

        public ICache<String, Asset> Remove(String assetID) {
            InternalCache.Remove(assetID);
            return this;
        }

        public ICache<String, Asset> RemoveRange(ICollection<String> assetIdCollection) {
            assetIdCollection.ToList()
                .ForEach(assetID => Remove(assetID));
            return this;
        }

        public ICache<String, Asset> Clear() {
            InternalCache.Clear();
            return this;
        }

        public Asset Get(String assetID) {
            return InternalCache[assetID];
        }

        public ICollection<Asset> GetRange(ICollection<String> assetIdCollection) {
            return assetIdCollection
                .Select(assetID => Get(assetID)).ToList();
        }

        public Boolean ContainsKey(String assetID) {
            return InternalCache.ContainsKey(assetID);
        }

        protected void Validate(ICacheable asset) {
            String key = asset.CacheKey;
            if (String.IsNullOrWhiteSpace(key)) {
                throw new CacheException($"Asset key can not be empty");
            }
        }

        public class CacheException : Exception {
            public CacheException(String message) : base(message) { }
        }
    }
}
