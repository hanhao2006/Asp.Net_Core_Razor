using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SpeakAuto.Data;
using SpeakAuto.Models;

namespace SpeakAuto.Pages.ServiceTypes
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IList<ServiceType> ServiceTypes { get; set; }

        public async Task<IActionResult> OnGet()
        {
            ServiceTypes = await _db.ServiceType.ToListAsync();
            return Page();
        }
    }
}