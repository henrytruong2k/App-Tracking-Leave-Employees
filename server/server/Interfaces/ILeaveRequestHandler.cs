using Microsoft.AspNetCore.Mvc;
using server.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Interfaces
{
    public interface ILeaveRequestHandler
    {
        Task<List<LeaveRequestDto>> GetAll(LeaveRequestFiltersDto filter);
        Task<List<LeaveRequestDto>> GetLeaveRequestsByEmployee(int id);
        Task<LeaveRequestDto> FindById(int id);
        Task<LeaveRequestDto> AddLeaveRequest(LeaveRequestDto model);
        Task<LeaveRequestDto> UpdateLeaveRequest(LeaveRequestDto model);
        Task<List<LeaveRequestDto>> Check(int id);
        
        //Task<LeaveRequestDto> ApproveRequest(int requestId);

    }
}
