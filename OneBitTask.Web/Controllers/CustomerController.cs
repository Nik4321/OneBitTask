using Microsoft.AspNetCore.Mvc;
using OneBitTask.Services;
using OneBitTask.ViewModels.Customer;

namespace OneBitTask.Web.Controllers
{
    public class CustomerController : BaseController
    {
        private readonly ICustomerService customerService;

        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult GetTableDate(int draw = 1, int start = 0, int length = 25)
        {
            var sortColumnString = HttpContext.Request.Form["order[0][column]"].ToString();
            var sortDirectionString = HttpContext.Request.Form["order[0][dir]"].ToString();

            var tableData = this.customerService.GetTableData(draw, start, length, sortColumnString, sortDirectionString);
            return this.Json(tableData);
        }

        [HttpGet]
        public IActionResult Details([FromRoute] int id)
        {
            var model = this.customerService.GetDetails(id);
            if (model == null)
            {
                this.SetErrorMessage("Customer does not exist");
                return this.RedirectToAction(nameof(CustomerController.Index));
            }

            return this.View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(AddCustomerViewModel model)
        {
            this.customerService.Create(model);

            this.SetSuccessMessage("Customer created.");
            return this.RedirectToAction(nameof(CustomerController.Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = this.customerService.GetEditModel(id);

            return this.View(model);
        }

        [HttpPost]
        public IActionResult Edit(EditCustomerViewModel model)
        {
            this.customerService.Update(model);
            this.SetSuccessMessage("Customer updated.");
            return this.RedirectToAction(nameof(CustomerController.Details), new { id = model.Id });
        }
        
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            this.customerService.Delete(id);
            return this.Ok("Customer deleted.");
        }

        [HttpPut]
        public IActionResult ChangeStatus(int id)
        {
            this.customerService.ChangeStatus(id);
            return this.Ok("Customer updated.");
        }
    }
}