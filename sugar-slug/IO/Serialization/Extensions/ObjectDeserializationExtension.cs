using System;
using System.IO;

namespace SugarSlug.IO.Serialization.Extensions {
    public static class ObjectDeserializationExtension {
        public static T FromJson<T>(this T obj, Uri source) where T : class, new() {
            var jsonString = File.ReadAllText(source.AbsolutePath);

            return new JsonDeserializer<T>().Deserialize(jsonString);
        }
    }
}
