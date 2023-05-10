using System.ComponentModel.DataAnnotations;

namespace PB04.Pages.Forms
{
    public class PersonForm
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
    }
}
