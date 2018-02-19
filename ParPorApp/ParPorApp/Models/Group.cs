using Newtonsoft.Json;

namespace ParPorApp.ViewModels
{
    public class Group
    {
        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("DistrictId")]
        public string DistrictId { get; set; }

        [JsonProperty("Id")]
        public long Id { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("UserId")]
        public string UserId { get; set; }

    }
}
