using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Infrastructure;
using PB04.Models;
using PB04.Pages.Forms;

namespace PB04.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ApplicationDbContext _ctx;


        public List<Person> People => _ctx.People.ToList();

        [BindProperty]
        public PersonForm PersonForm { get; set; }

        public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext ctx)
        {
            _logger = logger;
            _ctx = ctx;
        }

        public void OnGet()
        {

        }
        
        public IActionResult OnPost() 
        {
            if (!ModelState.IsValid)
                return Page();


            var person = new Person
            {
                FirstName = PersonForm.FirstName,
                LastName = PersonForm.LastName,
            };

            _ctx.Add(person);
            _ctx.SaveChanges();

            return Page();
        }
    }
}