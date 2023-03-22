using System.ComponentModel.DataAnnotations;

namespace PB02.Pages.Dto.Forms
{
    public class FizzBuzzForm
    {
        [Required]
        [RegularExpression("^(?!2137$).*", ErrorMessage ="Tak nie wolno")]
        public int Number { get; set; }
    }
}
