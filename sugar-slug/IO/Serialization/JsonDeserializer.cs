using Newtonsoft.Json;
using SugarSlug.IO.Serialization.Templates;
using System;

namespace SugarSlug.IO.Serialization {
    public class JsonDeserializer<Result> : IDeserializer<String, Result> where Result : new() {
        public Result Deserialize(String jsonString) {
            return JsonConvert.DeserializeObject<Result>(jsonString);
        }
    }
}
