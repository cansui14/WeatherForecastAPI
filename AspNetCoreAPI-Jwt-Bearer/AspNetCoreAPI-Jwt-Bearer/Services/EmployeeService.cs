using AspNetCoreAPI_Jwt_Bearer.DTOs;
using AspNetCoreAPI_Jwt_Bearer.Interfaces;
using AutoMapper;

namespace AspNetCoreAPI_Jwt_Bearer.Services
{
	public class EmployeeService : IEmployeeService
	{
		private readonly IEmployeeRepository _employeeRepository;
		private readonly IMapper _mapper;
		public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
		{
			_employeeRepository = employeeRepository;
			_mapper = mapper;
		}
		public async Task<EmployeeDto> Get(int id)
		{
			var employee = await _employeeRepository.GetByIdAsync(id);
			return _mapper.Map<EmployeeDto>(employee);
		}
		public async Task<List<EmployeeDto>> GetAll()
		{
			var list = await _employeeRepository.GetAllAsync();
			return _mapper.Map<List<EmployeeDto>>(list);
		}
	}
}
