using AspNetCoreAPI_Jwt_Bearer.DTOs;
using AspNetCoreAPI_Jwt_Bearer.Entities;
using AutoMapper;

namespace AspNetCoreAPI_Jwt_Bearer.Mapping
{
	public class MappingProfile : Profile
	{
		public MappingProfile() 
		{
			CreateMap<Employee, EmployeeDto>().ReverseMap();
		}
	}
}
