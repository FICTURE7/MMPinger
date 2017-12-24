using MMPinger.Models;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace MMPinger
{
    public class Manager
    {
        private const string TempDirectoryPath = "tmp";
        private const string ConfigurationPath = "config.json";

        private const string IPUrl = "https://raw.githubusercontent.com/SteamDatabase/SteamTracking/master/Random/NetworkDatagramConfig.json";

        private static readonly string IPFilePath = Path.Combine(TempDirectoryPath, "ips.json");

        public Manager()
        {
            Directory.CreateDirectory(TempDirectoryPath);

            LoadConfiguration();
        }

        public Configuration Configuration => _config;

        private Configuration _config;

        public async Task<Server[]> LoadIPsAsync()
        {
            string json;
            JObject ips;

            if (!File.Exists(IPFilePath))
            {
                using (var client = new WebClient())
                    json = await client.DownloadStringTaskAsync(IPUrl);

                using (var file = new StreamWriter(IPFilePath))
                    await file.WriteAsync(json);
            }
            else
            {
                using (var file = new StreamReader(IPFilePath))
                    json = await file.ReadToEndAsync();
            }

            ips = JObject.Parse(json);

            List<Server> servers = new List<Server>();
            foreach (var obj in ips)
            {
                if (obj.Key == "data_centers")
                {
                    foreach (var dataCenter in obj.Value)
                    {
                        var property = dataCenter as JProperty;

                        string name = property.Name;
                        var value = property.Value;
                        var ipAddresses = value["address_ranges"].ToObject<string[]>();

                        Server server = new Server
                        {
                            IPRanges = ipAddresses,
                            Name = name
                        };
                        servers.Add(server);
                    }
                }
            }

            return servers.ToArray();
        }

        private void LoadConfiguration()
        {
            if (!File.Exists(ConfigurationPath))
            {
                _config = new Configuration();
                var json = _config.ToJson(true);
                File.WriteAllText(ConfigurationPath, json);
            }
            else
            {
                var json = File.ReadAllText(ConfigurationPath);
                _config = Configuration.FromJson(json);
            }
        }
    }
}
