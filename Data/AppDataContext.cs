using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Data;

public class AppDataContext : DbContext
{
    public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
    {
        
    }

    public DbSet<Venda> Vendas { get; set; }
}