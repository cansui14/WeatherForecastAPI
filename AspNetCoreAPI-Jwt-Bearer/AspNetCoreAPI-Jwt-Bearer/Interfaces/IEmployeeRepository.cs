using AspNetCoreAPI_Jwt_Bearer.Entities;

namespace AspNetCoreAPI_Jwt_Bearer.Interfaces
{
	public interface IEmployeeRepository
	{
		Task<List<Employee>> GetAllAsync();
		Task<Employee> GetByIdAsync(int id);
		Task<Employee> CreateAsync(Employee employee);
		Task UpdateAsync(Employee employee);
		Task DeleteAsync(Employee employee);
	}
}
