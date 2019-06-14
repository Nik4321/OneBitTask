using System.ComponentModel.DataAnnotations;

namespace OneBitTask.ViewModels.PurchaseOrder
{
    public class EditPurchaseOrderViewModel : BasePurchaseOrderViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(MAXIMUM_DESCRIPTION, MinimumLength = MINIMUM_DESCRIPTION)]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Range(MINIMUM_Price, MAXIMUM_Price, ErrorMessage = "Invalid Target Price; Max 18 digits")]
        public decimal Price { get; set; }

        [Required]
        [Range(MINIMUM_QUANTITY, MAXIMUM_QUANTITY, ErrorMessage = "Please enter a number between 1 and 100")]
        public int Quantity { get; set; }

        public decimal TotalAmount { get; set; }

        public int CustomerId { get; set; }
    }
}
