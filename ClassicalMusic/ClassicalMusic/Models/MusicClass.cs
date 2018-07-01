using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassicalMusic.Models
{
    public class Track
    {
        [JsonProperty("titolo")]
        public string Title { get; set; }
        [JsonProperty("link")]
        public string Link { get; set; }
    }

    public class Opera
    {
        [JsonProperty("opera")]
        public string Name { get; set; }
        [JsonProperty("tracce")]
        public List<Track> Tracks { get; set; }
    }

    public class Category
    {
        [JsonProperty("categoria")]
        public string Name { get; set; }
        [JsonProperty("opere")]
        public List<Opera> OperaList { get; set; }
    }

    public class Composer
    {
        [JsonProperty("nome")]
        public string Name { get; set; }
        [JsonProperty("opere")]
        public List<Opera> OperaList { get; set; }
        [JsonProperty("categorie")]
        public List<Category> Categories { get; set; }
    }
}
