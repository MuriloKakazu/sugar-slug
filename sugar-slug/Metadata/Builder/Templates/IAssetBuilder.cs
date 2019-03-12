using SugarSlug.Metadata.Templates;

namespace SugarSlug.Metadata.Builder.Templates {
    public interface IAssetBuilder<Source, Result> where Result : IAsset {
        Result Build(Source source);
    }
}
