using Microsoft.EntityFrameworkCore;

namespace SS12CarWashing.Models;

public class AppDbContext:DbContext
{
	public AppDbContext(DbContextOptions<AppDbContext> options)
		:base(options)
	{

	}
	public DbSet<Customer> Customer { get; set; }
}
