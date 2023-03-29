using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PB03.App.Session;
using PB03.Pages.Forms;

namespace PB03.Pages
{
    public class ZapisaneModel : PageModel
    {
        public List<SessionItem> SessionData => 
            HttpContext.Session.AsList<SessionItem>("forms");

        public void OnGet()
        {
        }
    }
}
