using System.ComponentModel.DataAnnotations.Schema;

namespace OneBitTask.Data.Entities
{
    public class PurchaseOrder : BaseEntity
    {
        public string Description { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public int Quantity { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }

        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
