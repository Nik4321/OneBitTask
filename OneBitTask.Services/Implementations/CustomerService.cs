using System.Linq;
using AutoMapper;
using OneBitTask.Data.Entities;
using OneBitTask.Data.Enums;
using OneBitTask.Repositories;
using OneBitTask.ViewModels.Customer;
using OneBitTask.ViewModels.Shared;

namespace OneBitTask.Services.Implementations
{
    public class CustomerService : ICustomerService
    {
        private readonly IMapper mapper;
        private readonly ICustomerRepository customerRepository;

        public CustomerService(IMapper mapper, ICustomerRepository customerRepository)
        {
            this.mapper = mapper;
            this.customerRepository = customerRepository;
        }

        public DataTableResponseViewModel<ListCustomerViewModel> GetTableData(
            int draw,
            int start,
            int pageSize,
            string sortColumnString,
            string sortDirectionString)
        {
            var sortColumn = 0;
            var sortDirection = "asc";

            if (sortColumnString != null)
            {
                sortColumn = int.Parse(sortColumnString);
            }
            if (sortDirectionString != null)
            {
                sortDirection = sortDirectionString;
            }

            var customersQuery = this.customerRepository
                .FilterTableData(start, pageSize, sortColumn, sortDirection);

            var tableData = this.mapper
                .ProjectTo<ListCustomerViewModel>(customersQuery)
                .ToList();

            var result = new DataTableResponseViewModel<ListCustomerViewModel>
            {
                Data = tableData,
                Draw = draw,
                RecordsFiltered = this.customerRepository.GetAllCount(),
                RecordsTotal = this.customerRepository.GetAllCount()
            };
            return result;
        }

        public DetailsCustomerViewModel GetDetails(int id)
        {
            var customer = this.customerRepository
                .Filter(c => c.Id == id, prop => prop.PurchaseOrders)
                .FirstOrDefault();

            var result = this.mapper.Map<DetailsCustomerViewModel>(customer);
            return result;
        }

        public void Create(AddCustomerViewModel model)
        {
            var entity = this.mapper.Map<Customer>(model);
            this.customerRepository.Create(entity);
            this.customerRepository.SaveChanges();
        }

        public EditCustomerViewModel GetEditModel(int id)
        {
            var entity = this.customerRepository.GetById(id);
            var model = this.mapper.Map<EditCustomerViewModel>(entity);
            return model;
        }

        public void Update(EditCustomerViewModel model)
        {
            var entity = this.customerRepository.GetById(model.Id);
            this.mapper.Map(model, entity);
            this.customerRepository.Update(entity);
            this.customerRepository.SaveChanges();
        }

        public void Delete(int id)
        {
            this.customerRepository.Delete(id);
            this.customerRepository.SaveChanges();
        }

        public void ChangeStatus(int id)
        {
            var entity = this.customerRepository.GetById(id);
            entity.Status = entity.Status == EntityStatus.Active ? EntityStatus.Inactive : EntityStatus.Active;
            this.customerRepository.Update(entity);
            this.customerRepository.SaveChanges();
        }
    }
}
