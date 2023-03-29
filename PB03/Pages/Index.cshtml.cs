using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PB03.App.Session;
using PB03.Pages.Forms;

namespace PB03.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public DateForm DateForm { get; set; }

        public string Message => GetMessage();
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        private string GetMessage()
        {
            bool isGirl = false;

            if (DateForm.Name.Last() == 'a')
            {
                isGirl = true;
            }

            bool isLeap = DateTime.IsLeapYear(DateForm.Year);

            HttpContext.Session.AddItem("forms", new SessionItem { Form = DateForm, IsLeap = isLeap});

            return $"{DateForm.Name} urodził{(isGirl ? "a" : string.Empty)} się w {DateForm.Year} roku. To {(isLeap ? string.Empty : "nie ")}był rok przestępny.";
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