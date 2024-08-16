namespace AspNetCoreAPI_Jwt_Bearer.DTOs
{
	public class EmployeeDto
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime BeginDate { get; set; } = DateTime.Now;
		public string Phone { get; set; }
		public string Email { get; set; }
	}
}
