using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PB02.Interfaces;
using PB02.Pages.Dto.Forms;

namespace PB02.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IFizzBuzzMessageProvider _fizzBuzzProvider;

        public string Message {
            get
            {
                return _fizzBuzzProvider.GetFizzBuzzMessage(FizzBuzzForm.Number);
            } 
        }

        [BindProperty]
        public FizzBuzzForm FizzBuzzForm { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IFizzBuzzMessageProvider fizzBuzzProvider)
        {
            _logger = logger;
            _fizzBuzzProvider = fizzBuzzProvider;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            return Page();
        }

    }
}