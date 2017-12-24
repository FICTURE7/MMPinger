using Newtonsoft.Json;
using System;

namespace MMPinger.Models
{
    public class Configuration
    {
        public Configuration()
        {
            // Default configuration.
            Ping = new PingConfiguration
            {
                Interval = 5000,
                Good = 100,
                Ok = 150,
                Bad = 200
            };
        }

        [JsonProperty("ping")]
        public PingConfiguration Ping { get; set; }

        public string ToJson(bool indent)
        {
            return JsonConvert.SerializeObject(this, indent ? Formatting.Indented : Formatting.None);
        }

        public static Configuration FromJson(string json)
        {
            if (json == null)
                throw new ArgumentNullException(nameof(json));

            return JsonConvert.DeserializeObject<Configuration>(json);
        }

        public class PingConfiguration
        {
            [JsonProperty("interval_ms")]
            public int Interval { get; set; }
            [JsonProperty("good_ms")]
            public int Good { get; set; }
            [JsonProperty("ok_ms")]
            public int Ok { get; set; }
            [JsonProperty("bad_ms")]
            public int Bad { get; set; }
        }
    }
}
