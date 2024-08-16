using AspNetCoreAPI_Jwt_Bearer.DTOs;

namespace AspNetCoreAPI_Jwt_Bearer.Interfaces
{
	public interface IEmployeeService
	{
		Task<List<EmployeeDto>> GetAll();
		Task<EmployeeDto> Get(int id);
	}
}
