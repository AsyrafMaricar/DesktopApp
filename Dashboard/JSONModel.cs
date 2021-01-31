using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard
{
    public class JSONModel
    {

        [JsonProperty(PropertyName = "Device")]
        public string device { get; set; }

        public DateTime date { get; set; }

        [JsonProperty(PropertyName = "Sen1")]
        public float sen1 { get; set; }

        [JsonProperty(PropertyName = "Sen2")]
        public float sen2 { get; set; }

        [JsonProperty(PropertyName = "Sen3")]
        public float sen3 { get; set; }

        [JsonProperty(PropertyName = "Sen4")]
        public float sen4 { get; set; }

    }
}
