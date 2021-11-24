using server.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace server.Interfaces
{
    public interface IEmployeeRespository
    {
        Task<List<Employee>> GetListAsync();
        Task<Employee> InsertAsync(Employee emp);
        Task<Employee> UpdateAsync(Employee emp);
        Task<Employee> Authenticate(string email, string password);
        Task<Employee> GetEmployee(int id);
        Task<Employee> GetApprover(int id);
    }
}
