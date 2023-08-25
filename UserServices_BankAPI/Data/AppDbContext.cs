using Microsoft.EntityFrameworkCore;
using UserServices_BankAPI.Models;

namespace UserServices_BankAPI;


public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    public DbSet<Account> Accounts { get; set; }
}