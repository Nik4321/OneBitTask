using Microsoft.AspNetCore.Mvc;
using OneBitTask.Services;
using OneBitTask.ViewModels.PurchaseOrder;

namespace OneBitTask.Web.Controllers
{
    public class PurchaseOrderController : BaseController
    {
        private readonly IPurchaseOrderService purchaseOrderService;

        public PurchaseOrderController(IPurchaseOrderService purchaseOrderService)
        {
            this.purchaseOrderService = purchaseOrderService;
        }

        [HttpPost]
        public IActionResult Create(AddPurchaseOrderViewModel model)
        {
            this.purchaseOrderService.Create(model);
            this.SetSuccessMessage("Purchase Order added.");
            return this.RedirectToAction(nameof(CustomerController.Details), "Customer", new { Id = model.CustomerId } );
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = this.purchaseOrderService.GetEditModel(id);

            return this.View(model);
        }

        [HttpPost]
        public IActionResult Edit(EditPurchaseOrderViewModel model)
        {
            this.purchaseOrderService.Update(model);
            this.SetSuccessMessage("Customer updated.");
            return this.RedirectToAction(nameof(CustomerController.Details), "Customer", new { id = model.CustomerId });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            this.purchaseOrderService.Delete(id);
            return this.Ok("Purchase order deleted.");
        }

        [HttpPut]
        public IActionResult ChangeStatus(int id)
        {
            this.purchaseOrderService.ChangeStatus(id);
            return this.Ok("Purchase order updated.");
        }
    }
}