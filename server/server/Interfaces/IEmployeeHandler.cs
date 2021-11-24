using server.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace server.Interfaces
{
    public interface IEmployeeHandler
    {
        Task<EmployeeDto> Authenticate(string email, string password);
        Task<List<EmployeeDto>> GetAll();
        Task<EmployeeDto> Add(EmployeeDto emp);
        Task<EmployeeDto> Update(EmployeeDto emp);
        Task<EmployeeDto> Get(int id);
        Task<EmployeeDto> GetApprover(int id);
    }
}
