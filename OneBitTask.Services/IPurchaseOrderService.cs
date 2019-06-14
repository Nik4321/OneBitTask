using OneBitTask.ViewModels.PurchaseOrder;

namespace OneBitTask.Services
{
    public interface IPurchaseOrderService
    {
        void Create(AddPurchaseOrderViewModel model);

        EditPurchaseOrderViewModel GetEditModel(int id);

        void Update(EditPurchaseOrderViewModel model);

        void Delete(int id);

        void ChangeStatus(int id);
    }
}