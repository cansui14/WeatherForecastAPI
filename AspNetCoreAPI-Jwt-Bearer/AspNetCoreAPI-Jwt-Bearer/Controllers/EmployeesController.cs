using AspNetCoreAPI_Jwt_Bearer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreAPI_Jwt_Bearer.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EmployeesController : ControllerBase
	{
		private readonly IEmployeeService _employeeService;
		public EmployeesController(IEmployeeService employeeService)
		{
			_employeeService = employeeService;
		}
		[Authorize(Roles = "Admin")]
		[HttpGet]
		public async Task<IActionResult> Get()
		{
			var list = await _employeeService.GetAll();
			return Ok(list);
		}
		[AllowAnonymous]
		[HttpGet("{id}")]
		public async Task<IActionResult> Get(int id)
		{
			var employee = await _employeeService.Get(id);
			if(employee == null)
			{
				return NotFound();
			}
			return Ok(employee);
		}
	}
}
