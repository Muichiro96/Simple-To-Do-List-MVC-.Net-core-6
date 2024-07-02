using Azure.Core;
using System.Text.Json.Serialization;

namespace todolist.Class
{
    public class Feries{
        [JsonPropertyName("status")]
        public int Status { get; set; }

        [JsonPropertyName("warning")]
        public string Warning { get; set; }

        [JsonPropertyName("requests")]
        public Requests Requests { get; set; }
        public List<Holidays> Holidays { get; set; }
    }
    public class Requests
    {
        [JsonPropertyName("used")]
        public int Used { get; set; }

        [JsonPropertyName("available")]
        public int Available { get; set; }

        [JsonPropertyName("resets")]
        public string Resets { get; set; }
    }
    public class Holidays
    {
        [JsonPropertyName("name")]
        public String name { get; set; }
        [JsonPropertyName("date")]
        public DateOnly date { get; set; }
        [JsonPropertyName("observed")]
        public DateOnly observed { get; set; }
        [JsonPropertyName("public")]
        public Boolean Public { get; set; }
        [JsonPropertyName("country")]
        public String country { get; set; }
        [JsonPropertyName("uuid")]
        public String uuid { get; set; }
        [JsonPropertyName("weekday")]
        public Dictionary<string, weekDay>? weekday { get; set; }


    }
    public class weekDay
    {
        [JsonPropertyName("name")]
        public String name { get; set; }
        [JsonPropertyName("numeric")]
        public String numeric { get; set; }
    }
}
