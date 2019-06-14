using OneBitTask.Data;
using OneBitTask.Data.Entities;

namespace OneBitTask.Repositories.Implementations
{
    public class PurchaseOrderRepository : Repository<PurchaseOrder>, IPurchaseOrderRepository
    {
        private readonly ApplicationDbContext db;
        public PurchaseOrderRepository(ApplicationDbContext db)
            : base(db)
        {
            this.db = db;
        }
    }
}
