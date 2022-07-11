using Newtonsoft.Json;
using System.Globalization;

namespace PointsApi.Models
{
    public class Points
    {
        public long Id { get; set; }
        public string Payer { get; set; }
        public int TransactionPoints { get; set; }

        //[JsonProperty("timestamp")]
        //private string Timestamp { get; set; }

        //[JsonIgnore]
        //public DateTime? timestamp
        //{
        //    get { return DateTime.Parse(Timestamp, new CultureInfo("en-US")); }
        //}

        public DateTime Timestamp { get; set; }   //1/1/1994 12:00:00 AM  or try "Timestamp":"/Date(1239018869048)/"  or "yyyy-MM-dd HH:mm:ss"
    }
}
