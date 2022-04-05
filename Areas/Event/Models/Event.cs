using System.ComponentModel.DataAnnotations;

namespace TigerTix.Web.Models
{
    public class Event
    {
        public int ID { get; set; }
        public string EventType { get; set; }
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public string EventLocation { get; set; }

        public string EventDateTime { get; set; }
    }
}
