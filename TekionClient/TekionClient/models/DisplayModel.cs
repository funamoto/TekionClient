using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TekionClient
{
    public class DisplayModel
    {
        [JsonProperty("result")]
        public int ResultCode { get; set; }
        [JsonProperty("wether")]
        public int WeatherCode { get; set; }
        [JsonProperty("temperature")]
        public float? Temperature { get; set; }

        public DisplayModel()
        {
            ResultCode = 0;
            WeatherCode = 0;
            Temperature = null;
        }
    }
}
