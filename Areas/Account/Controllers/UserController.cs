using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TigerTix.Web.Data;
using TigerTix.Web.Controllers;
using TigerTix.Web.Areas.Account.Models;

namespace TigerTix.Web.Areas.Account.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        
        private readonly TigerTixWebContext _context;
        private readonly SignInManager<SingleUser> _signInManager;
        private readonly UserManager<SingleUser> _userManager;
        private readonly ILogger<SingleUser> _logger;
        private readonly IEmailSender _emailSender;

        [BindProperty]
        public UserModel Input { get; set; }
        public string ReturnUrl { get; set; }
        public UserController(
            UserManager<SingleUser> userManager,
            SignInManager<SingleUser> signInManager,
            ILogger<SingleUser> logger,
            IEmailSender emailSender,
            TigerTixWebContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _context = context;
        }
        [TempData]
        public string ErrorMessage { get; set; }

        // View all Users
        [HttpGet]
        public async Task<IActionResult> ViewUsers()
        {
            return View(await _context.User.ToListAsync());
            
        }

        // REGISTER NEW USER
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Create(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var user = new SingleUser { UserName = model.Email, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    // var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    // var callbackUrl = Url.EmailConfirmationLink(user.Id, code, Request.Scheme);
                    // await _emailSender.SendEmailConfirmationAsync(model.Email, callbackUrl);

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    _logger.LogInformation("User created a new account with password.");
                    return RedirectToLocal(returnUrl);
                }
                AddErrors(result);
            }

            // If execution got this far, something failed, redisplay the form.
            return View(model);
        }
        private void AddErrors(IdentityResult result)
        {
            throw new NotImplementedException();
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }




        /*
// GET: User
public async Task<IActionResult> Index()
{
   return View(await _context.User.ToListAsync());
}

// GET: User/Details/5
public async Task<IActionResult> Details(int? id)
{
   if (id == null)
   {
       return NotFound();
   }

   var user = await _context.User
       .FirstOrDefaultAsync(m => m.ID == id);
   if (user == null)
   {
       return NotFound();
   }

   return View(user);
}

// GET: User/Create
public IActionResult Create()
{
   return View();
}


// POST: User/Create
// To protect from overposting attacks, enable the specific properties you want to bind to.
// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Create([Bind("ID,FirstName,LastName,Email,PhoneNumber,Password,CreditCard,AccountType")] UserModel user)
{
   if (ModelState.IsValid)
   {
       _context.Add(user);
       await _context.SaveChangesAsync();
       return RedirectToAction(nameof(Index));
   }
   return View(user);
}

// GET: User/Edit/5
public async Task<IActionResult> Edit(int? id)
{
   if (id == null)
   {
       return NotFound();
   }

   var user = await _context.User.FindAsync(id);
   if (user == null)
   {
       return NotFound();
   }
   return View(user);
}



// POST: User/Edit/5
// To protect from overposting attacks, enable the specific properties you want to bind to.
// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
/*        [HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Edit(int id, [Bind("ID,FirstName,LastName,Email,PhoneNumber,Password,CreditCard,AccountType")] UserModel user)
{
   if (id != user.ID)
   {
       return NotFound();
   }

   if (ModelState.IsValid)
   {
       try
       {
           _context.Update(user);
           await _context.SaveChangesAsync();
       }
       catch (DbUpdateConcurrencyException)
       {
           if (!UserExists(user.ID))
           {
               return NotFound();
           }
           else
           {
               throw;
           }
       }
       return RedirectToAction(nameof(Index));
   }
   return View(user);
}

// GET: User/Delete/5
public async Task<IActionResult> Delete(int? id)
{
   if (id == null)
   {
       return NotFound();
   }

   var user = await _context.User
       .FirstOrDefaultAsync(m => m.ID == id);
   if (user == null)
   {
       return NotFound();
   }

   return View(user);
}

// POST: User/Delete/5
[HttpPost, ActionName("Delete")]
[ValidateAntiForgeryToken]
public async Task<IActionResult> DeleteConfirmed(int id)
{
   var user = await _context.User.FindAsync(id);
   _context.User.Remove(user);
   await _context.SaveChangesAsync();
   return RedirectToAction(nameof(Index));
}

private bool UserExists(int id)
{
   return _context.User.Any(e => e.ID == id);
}

[HttpGet("/UserLogin")]
public IActionResult UserLogin()
{
   return View();
}
[HttpPost("/UserLogin")]
public IActionResult UserLogin(User user)
{
   return View();
}
*/

    }
}
