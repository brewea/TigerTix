using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TigerTix.Web.Areas.Event.Models
{
    public class EventModel : PageModel
    {
        public int ID { get; set; }
        public string EventType { get; set; }
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public string EventLocation { get; set; }

        public string EventDateTime { get; set; }
        public string EventStatus { get; set; }
    }
}