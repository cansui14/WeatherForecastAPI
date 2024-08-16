using AspNetCoreAPI_Jwt_Bearer.Data;
using AspNetCoreAPI_Jwt_Bearer.Entities;
using AspNetCoreAPI_Jwt_Bearer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreAPI_Jwt_Bearer.Repositories
{
	public class EmployeeRepository : IEmployeeRepository
	{
		private readonly PersonelDbContext _context;

		public EmployeeRepository(PersonelDbContext context)
		{
			_context = context;
		}
		public async Task<Employee> CreateAsync(Employee employee)
		{
			await _context.Employees.AddAsync(employee);
			await _context.SaveChangesAsync();
			return employee;
		}
		public async Task DeleteAsync(Employee employee)
		{
			_context.Employees.Remove(employee);
			await _context.SaveChangesAsync();
		}
		public async Task<List<Employee>> GetAllAsync()
		{
			return await _context.Employees.ToListAsync();
		}
		public async Task<Employee> GetByIdAsync(int id)
		{
			var employee = await _context.Employees.FindAsync(id);
			return employee;
		}
		public async Task UpdateAsync(Employee employee)
		{
			var orjEmployee = await _context.Employees.FirstOrDefaultAsync(c => c.Id == employee.Id);
			_context.Entry(orjEmployee).CurrentValues.SetValues(employee);
			await _context.SaveChangesAsync();
		}
	}
}
