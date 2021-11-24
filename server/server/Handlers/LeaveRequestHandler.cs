using AutoMapper;
using server.Dtos;
using server.Interfaces;
using server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Handlers
{
    public class LeaveRequestHandler : ILeaveRequestHandler
    {
        private readonly ILeaveRequestRespository _repo;
        private readonly IEmployeeRespository _empManager;
        private readonly IMapper _map;

        public LeaveRequestHandler(ILeaveRequestRespository repo, IEmployeeRespository empManager, IMapper map)
        {
            _repo = repo;
            _empManager = empManager;
            _map = map;
        }
        public async Task<List<LeaveRequestDto>> GetAll(LeaveRequestFiltersDto filter)
        {
            var requests = await _repo.GetListAsync(filter.Month, filter.Year);
            var newItem = _map.Map<List<LeaveRequest>, List<LeaveRequestDto>>(requests);
            return newItem;
        }

        public async Task<List<LeaveRequestDto>> GetLeaveRequestsByEmployee(int id)
        {
            var result = await _repo.GetLeaveRequestsByEmployee(id);
            var newItem = _map.Map<List<LeaveRequest>, List<LeaveRequestDto>>(result);
            return newItem;
        }

        public async Task<LeaveRequestDto> FindById(int id)
        {
            var result = await _repo.FindById(id);
            var newItem = _map.Map<LeaveRequest, LeaveRequestDto>(result);
            return newItem;
        }
        public async Task<LeaveRequestDto> AddLeaveRequest(LeaveRequestDto model)
        {
            var fromDate = Convert.ToDateTime(model.FromDate);
            var toDate = Convert.ToDateTime(model.ToDate);
            if (DateTime.Compare(fromDate, toDate) > 1)
            {
                return new LeaveRequestDto
                {
                    IsSuccess = false,
                    MessageResponse = "Start date cannot be further in the future than the end date"
                };
            }
            var employee = await _empManager.GetEmployee(model.CreatedById);
            int daysRequested = (int)(toDate - fromDate).TotalDays;

            if (daysRequested > employee.Dayoff)
            {
                return new LeaveRequestDto
                {
                    IsSuccess = false,
                    MessageResponse = "You do not have sufficient days for this request!"
                };
            }
            var leaveRequestModel = new LeaveRequestDto
            {
                RequestedById = model.RequestedById,
                CreatedById = model.CreatedById,
                FromDate = fromDate,
                ToDate = toDate,
                Approved = null,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                DateActioned = DateTime.Now,
                Reason = model.Reason,
            };

            var leaveRequest = _map.Map<LeaveRequestDto, LeaveRequest>(leaveRequestModel);
            var result = await _repo.Add(leaveRequest);

            var newItem = _map.Map<LeaveRequest, LeaveRequestDto>(result);
            newItem.IsSuccess = true;
            newItem.MessageResponse = null;
            return newItem;

            
        }

        public async Task<LeaveRequestDto> UpdateLeaveRequest(LeaveRequestDto model)
        {
            var newItem = _map.Map<LeaveRequestDto, LeaveRequest>(model);
            var leaveRequest = await _repo.UpdateAsync(newItem);
            return _map.Map<LeaveRequest, LeaveRequestDto>(leaveRequest);
        }

        public async Task<List<LeaveRequestDto>> Check(int id)
        {
            var result = await _repo.Check(id);
            var newItem = _map.Map<List<LeaveRequest>, List<LeaveRequestDto>>(result);
            return newItem;
        }

        //public async Task<LeaveRequestDto> ApproveRequest(int requestId)
        //{
        //    var leaveRequest = await _repo.FindById(requestId);
        //    if (leaveRequest == null) return null;
        //    var employeeId = leaveRequest.CreatedById;
        //    var result = await _empManager.GetEmployee(employeeId);
        //    int daysRequested = (int)(leaveRequest.ToDate - leaveRequest.FromDate).TotalDays;
        //    result.Dayoff = result.Dayoff - daysRequested;

        //    leaveRequest.Approved = true;
        //    leaveRequest.DateActioned = DateTime.Now;

        //    await _repo.Update()
        //}
    }
}
