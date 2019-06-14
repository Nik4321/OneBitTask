using System.Linq;
using OneBitTask.Data;
using OneBitTask.Data.Entities;

namespace OneBitTask.Repositories.Implementations
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ApplicationDbContext db) : base(db)
        {
                
        }

        public IQueryable<Customer> FilterTableData(int start, int pageSize, int sortColumn, string sortDirection)
            => this.BuildSearchQuery(sortColumn, sortDirection).Skip(start).Take(pageSize);

        public int GetAllCount()
            => this.GetAll().Count();

        private IQueryable<Customer> BuildSearchQuery(int sortColumn, string sortDirection)
        {
            var query = this.GetAll();

            switch (sortColumn)
            {
                case 0 when sortDirection == "asc":
                    query = query.OrderBy(x => x.FirstName).ThenBy(x => x.LastName);
                    break;
                case 0:
                    query = query.OrderByDescending(x => x.FirstName).ThenByDescending(x => x.LastName);
                    break;
                case 1 when sortDirection == "asc":
                    query = query.OrderByDescending(x => x.Sex);
                    break;
                case 1:
                    query = query.OrderBy(x => x.Sex);
                    break;
                case 2 when sortDirection == "asc":
                    query = query.OrderBy(x => x.Telephone);
                    break;
                case 2:
                    query = query.OrderByDescending(x => x.Telephone);
                    break;
                case 3 when sortDirection == "asc":
                    query = query.OrderBy(x => x.Created);
                    break;
                case 3:
                    query = query.OrderByDescending(x => x.Created);
                    break;
                case 4 when sortDirection == "asc":
                    query = query.OrderBy(x => x.Status);
                    break;
                case 4:
                    query = query.OrderByDescending(x => x.Status);
                    break;
            }

            return query;
        }
    }
}