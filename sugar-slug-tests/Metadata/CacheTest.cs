using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SugarSlug.IO;
using SugarSlug.Metadata;
using SugarSlug.Metadata.Model;

namespace SugarSlugTests.Metadata {
    [TestClass]
    public class CacheTest {
        [TestMethod]
        public void ShouldEncacheNewAsset() {
            // given
            Cache cache = Cache.Instance;
            Asset asset = new Sprite() {
                ID = "id",
                Source = Paths.Assets
            };

            // when
            cache.Add(asset.CacheKey, asset);

            // then
            cache.ContainsKey(asset.CacheKey);
        }
    }
}
