using SugarSlug.Metadata.Model;
using System;

namespace SugarSlug.Metadata.Templates {
    public interface IAsset {
        String ID { get; set; }
        Uri Source { get; set; }
        AssetType Type { get; set; }
    }
}
