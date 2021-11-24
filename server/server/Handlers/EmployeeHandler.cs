using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using server.Dtos;
using server.Helpers;
using server.Interfaces;
using server.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace server.Handlers
{
    public class EmployeeHandler : IEmployeeHandler
    {
        
        private readonly IEmployeeRespository _repo;        
        private readonly IMapper _map;

        public EmployeeHandler(IEmployeeRespository repo, IMapper map)
        {
            _repo = repo;
            _map = map;
        }
        public async Task<List<EmployeeDto>> GetAll()
        {               
            
            var emps = await _repo.GetListAsync();
           
            var newItem = _map.Map<List<Employee>, List<EmployeeDto>>(emps);
            return newItem;
        }

        public async Task<EmployeeDto> Get(int id)
        {
            var emp = await _repo.GetEmployee(id);
            var newItem = _map.Map<Employee, EmployeeDto>(emp);
            return newItem;
        }

        public async Task<EmployeeDto> Authenticate(string email, string password)
        {
            var user = await _repo.Authenticate(email, password);
            var newItem = _map.Map<Employee, EmployeeDto>(user);
            return newItem;
        }

        public async Task<EmployeeDto> Add(EmployeeDto empDto)
        {
            var newItem = _map.Map<EmployeeDto, Employee>(empDto);
            var emp = await _repo.InsertAsync(newItem);
            return _map.Map<Employee, EmployeeDto>(emp);
        }
        public async Task<EmployeeDto> Update(EmployeeDto empDto)
        {
            var newItem = _map.Map<EmployeeDto, Employee>(empDto);
            var emp = await _repo.UpdateAsync(newItem);
            return _map.Map<Employee, EmployeeDto>(emp);
        }

        public async Task<EmployeeDto> GetApprover(int id)
        {
            var result = await _repo.GetApprover(id);
            var newItem = _map.Map<Employee, EmployeeDto>(result);
            return newItem;
        }
    }
}
