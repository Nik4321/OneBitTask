using System.Collections.Generic;
using OneBitTask.Data.Enums;

namespace OneBitTask.Data.Entities
{
    public class Customer : BaseEntity
    {
        public Customer()
        {
            this.PurchaseOrders = new HashSet<PurchaseOrder>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Gender Sex { get; set; }

        public string Telephone { get; set; }

        public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; }
    }
}
