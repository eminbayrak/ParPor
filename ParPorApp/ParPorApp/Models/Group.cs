using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ParPorApp.Models
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

        public string ImageUrl { get; set; }
        public string Phone { get; internal set; }
        public string Email { get; internal set; }
    }
}
