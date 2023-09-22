using Microsoft.EntityFrameworkCore;
using MinimalApiDemo.Models;

namespace MinimalApiDemo.Data;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    public DbSet<Command> Commands => Set<Command>(); 
    
}