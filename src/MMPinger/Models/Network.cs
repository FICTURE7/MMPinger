using System;

namespace MMPinger.Models
{
    public class Network
    {
        public string ToJson(bool indent)
        {
            return null;
        }

        public static Network FromJson(string json)
        {
            if (json == null)
                throw new ArgumentNullException(nameof(json));

            return null;
        }
    }
}
