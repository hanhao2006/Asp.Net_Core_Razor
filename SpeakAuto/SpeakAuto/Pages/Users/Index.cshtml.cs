using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SpeakAuto.Data;
using SpeakAuto.Models;

namespace SpeakAuto.Pages.Users
{
    public class IndexModel : PageModel
    {

        private readonly ApplicationDbContext _db;
        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public List<ApplicationUser> ApplicationUsersList { get; set; }

        public async Task<IActionResult> OnGet()
        {
            ApplicationUsersList = await _db.ApplicationUser.ToListAsync();
            return Page();
        }
    }
}