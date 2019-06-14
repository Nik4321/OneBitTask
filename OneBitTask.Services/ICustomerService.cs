
using OneBitTask.ViewModels.Customer;
using OneBitTask.ViewModels.Shared;

namespace OneBitTask.Services
{
    public interface ICustomerService
    {
        DataTableResponseViewModel<ListCustomerViewModel> GetTableData(int draw, int start, int pageSize, string sortColumn, string sortDirection);

        DetailsCustomerViewModel GetDetails(int id);

        void Create(AddCustomerViewModel model);

        EditCustomerViewModel GetEditModel(int id);

        void Update(EditCustomerViewModel model);

        void Delete(int id);

        void ChangeStatus(int id);
    }
}