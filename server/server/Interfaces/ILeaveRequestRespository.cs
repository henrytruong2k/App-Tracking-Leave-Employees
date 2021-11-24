using server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Interfaces
{
    public interface ILeaveRequestRespository
    {
        Task<List<LeaveRequest>> GetListAsync(int? month, int? year);
        Task<List<LeaveRequest>> GetLeaveRequestsByEmployee(int id);
        Task<LeaveRequest> FindById(int id);
        Task<LeaveRequest> Add(LeaveRequest entity);
        Task<LeaveRequest> UpdateAsync(LeaveRequest entity);
        Task<List<LeaveRequest>> Check(int id);
    }
}
