using AutoMapper;
using server.Dtos;
using server.Models;

namespace server.Mappings
{
    public class MyMappingProfile : Profile
    {
        public MyMappingProfile()
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<LeaveRequest, LeaveRequestDto>().ReverseMap();
        }
    }
}
