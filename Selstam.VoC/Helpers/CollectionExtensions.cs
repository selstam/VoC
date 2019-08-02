namespace Selstam.VoC.Helpers
{
    using System.Collections.Generic;
    using System.Linq;

    using Newtonsoft.Json;

    public static class CollectionExtensions
    {
        public static List<KeyValuePair<string, object>> Convert(this string rawData)
        {
            return JsonConvert.DeserializeObject<Dictionary<string, object>>(rawData).ToList();
        }

        public static void AddSerializedDictionary(this Dictionary<string, object> dictionary, string rawData)
        {
            rawData.Convert().ForEach(kvp => dictionary[kvp.Key] = kvp.Value);
        }
    }
}