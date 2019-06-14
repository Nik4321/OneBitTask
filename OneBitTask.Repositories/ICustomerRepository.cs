using System.Linq;
using OneBitTask.Data.Entities;

namespace OneBitTask.Repositories
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        IQueryable<Customer> FilterTableData(int start, int pageSize, int sortColumn, string sortDirection);

        int GetAllCount();
    }
}
