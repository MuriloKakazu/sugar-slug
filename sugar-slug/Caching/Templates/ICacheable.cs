using System;

namespace SugarSlug.Caching.Templates {
    public interface ICacheable {
        String CacheKey { get; }
    }
}
