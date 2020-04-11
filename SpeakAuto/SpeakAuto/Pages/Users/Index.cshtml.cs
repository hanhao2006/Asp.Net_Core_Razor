using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SpeakAuto.Data;
using SpeakAuto.Models;
using SpeakAuto.Models.ViewModel;
using SpeakAuto.Uitlity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public UsersListViewModel UsersListVM { get; set; }

        public async Task<IActionResult> OnGet(int productPage = 1 )
        {
            UsersListVM = new UsersListViewModel()
            {
                ApplicationUsersList = await _db.ApplicationUser.ToListAsync()
            };

            StringBuilder param = new StringBuilder();
            param.Append("/Users?productPage=:");

            var count = UsersListVM.ApplicationUsersList.Count;

            UsersListVM.PagingInfo = new PagingInfo
            {
                CurrentPage = productPage,
                ItemPerPage = SD.PaginationUsersPageSize,
                TotalItems = count,
                UrlParam = param.ToString()
            };

            UsersListVM.ApplicationUsersList = UsersListVM.ApplicationUsersList.OrderBy(p => p.Email)
                .Skip((productPage - 1) * SD.PaginationUsersPageSize)
                .Take(SD.PaginationUsersPageSize).ToList();
          
            return Page();
        }
    }
}