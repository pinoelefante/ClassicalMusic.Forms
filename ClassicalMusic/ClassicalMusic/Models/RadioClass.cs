using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassicalMusic.Models
{
    public class RadioItem
    {
        [JsonProperty("title")]
        public string Name { get; set; }
        [JsonProperty("descr")]
        public string WebSite { get; set; }
        [JsonProperty("link")]
        public string RadioLink { get; set; }
        [JsonProperty("image")]
        public string Image { get; set; }
    }
}
