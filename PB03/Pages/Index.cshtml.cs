using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PB03.Pages.Forms;

namespace PB03.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public DateForm DateForm { get; set; }

        public string Message => GetMessage(DateForm.Name, DateForm.Year);
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        private string GetMessage(string name, int year)
        {
            bool isGirl = false;

            if (name.Last() == 'a')
            {
                isGirl = true;
            }

            bool isLeap = DateTime.IsLeapYear(year);

            return $"{name} urodził{(isGirl ? "a" : string.Empty)} się w {DateForm.Year} roku. To {(isLeap ? "nie " : string.Empty)}był rok przestępny.";
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