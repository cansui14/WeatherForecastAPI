using AspNetCoreAPI_Jwt_Bearer.Entities;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreAPI_Jwt_Bearer.Data
{
	public class PersonelDbContext : DbContext
	{
        public PersonelDbContext(DbContextOptions<PersonelDbContext> options) : base(options)
        {   }

        public DbSet<Employee> Employees { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//Seed Data
			modelBuilder.Entity<Employee>().HasData(
					new Employee() { Id = 1, FirstName = "Ali", LastName = "Uçar", Phone = "544 322 12 21", Email = "aliucar@gmail.com"},
					new Employee() { Id = 2, FirstName = "Oya", LastName = "Koşar", Phone = "543 322 12 21", Email = "oyakosar@gmail.com" },
					new Employee() { Id = 3, FirstName = "Neşe", LastName = "Sever", Phone = "532 322 12 21", Email = "nese@gmail.com" },
					new Employee() { Id = 4, FirstName = "Hasan", LastName = "Kaya", Phone = "533 322 12 21", Email = "hasan@gmail.com" }
				);

			base.OnModelCreating(modelBuilder);
		}

	}
}
