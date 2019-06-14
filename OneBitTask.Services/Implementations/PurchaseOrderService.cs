using AutoMapper;
using OneBitTask.Data.Entities;
using OneBitTask.Data.Enums;
using OneBitTask.Repositories;
using OneBitTask.ViewModels.PurchaseOrder;

namespace OneBitTask.Services.Implementations
{
    public class PurchaseOrderService : IPurchaseOrderService
    {
        private readonly IMapper mapper;
        private readonly IPurchaseOrderRepository purchaseOrderRepository;

        public PurchaseOrderService(
            IMapper mapper,
            IPurchaseOrderRepository purchaseOrderRepository
            )
        {
            this.mapper = mapper;
            this.purchaseOrderRepository = purchaseOrderRepository;
        }

        public void Create(AddPurchaseOrderViewModel model)
        {
            var entity = this.mapper.Map<PurchaseOrder>(model);
            entity.TotalAmount = model.Price * model.Quantity;

            this.purchaseOrderRepository.Create(entity);
            this.purchaseOrderRepository.SaveChanges();
        }

        public EditPurchaseOrderViewModel GetEditModel(int id)
        {
            var entity = this.purchaseOrderRepository.GetById(id);
            var model = this.mapper.Map<EditPurchaseOrderViewModel>(entity);
            return model;
        }

        public void Update(EditPurchaseOrderViewModel model)
        {
            var entity = this.purchaseOrderRepository.GetById(model.Id);
            this.mapper.Map(model, entity);
            entity.TotalAmount = model.Price * model.Quantity;

            this.purchaseOrderRepository.Update(entity);
            this.purchaseOrderRepository.SaveChanges();
        }

        public void Delete(int id)
        {
            this.purchaseOrderRepository.Delete(id);
            this.purchaseOrderRepository.SaveChanges();
        }

        public void ChangeStatus(int id)
        {
            var entity = this.purchaseOrderRepository.GetById(id);
            entity.Status = entity.Status == EntityStatus.Active ? EntityStatus.Inactive : EntityStatus.Active;
            this.purchaseOrderRepository.Update(entity);
            this.purchaseOrderRepository.SaveChanges();
        }
    }
}
