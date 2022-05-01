using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Logging;
using TigerTix.Web.Data;
using TigerTix.Web.Controllers;

namespace TigerTix.Web.Areas.Ticket.Controllers
{
    public class TicketController : Controller
    {
        public TicketController() { }
    }
}
