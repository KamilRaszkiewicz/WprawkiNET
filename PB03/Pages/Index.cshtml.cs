using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PB03.Pages.Forms;

namespace PB03.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public DateForm DateForm { get; set; }
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public IActionResult OnPost()
        {
            return Page();
        }

        public void OnGet()
        {

        }
    }
}