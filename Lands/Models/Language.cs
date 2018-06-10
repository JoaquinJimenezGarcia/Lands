namespace Lands.Models
{
    using Newtonsoft.Json;

    public class Language
    {
        [JsonProperty(PropertyName = "iso639_1")]
        public string ISO6391 { get; set; }

        [JsonProperty(PropertyName = "iso639_2")]
        public string ISO6392 { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "nativeName")]
        public string NativeName { get; set; }
    }
}
