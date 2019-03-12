namespace SugarSlug.IO.Serialization.Templates {
    public interface IDeserializer<Source, Result> where Result : new() {
        Result Deserialize(Source serializedObj);
    }
}
