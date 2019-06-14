using System.ComponentModel.DataAnnotations;
using OneBitTask.Data.Enums;

namespace OneBitTask.ViewModels.Customer
{
    public class EditCustomerViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(25)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(25)]
        public string LastName { get; set; }

        [Required]
        public Gender Sex { get; set; }

        [Required]
        [RegularExpression(@"^\d{3}-\d{3}-\d{4}$", ErrorMessage = "Phone has an invalid format. Format: ###-###-####")]
        public string Telephone { get; set; }
    }
}
