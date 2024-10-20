using Microsoft.EntityFrameworkCore;
using ContactMAnager.Models;
namespace ContactMAnager.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    public DbSet<contactitem> contactitems { get; set; }
}
