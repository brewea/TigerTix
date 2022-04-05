using System;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TigerTix.Web.Models
{
    public class ErrorViewModel : PageModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
