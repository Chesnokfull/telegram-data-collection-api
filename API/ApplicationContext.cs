using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection.Metadata;

public class ApplicationContext : DbContext
{
    public DbSet<Source> Sources { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Survey> Surveys { get; set; }

    private readonly string _connectionString;
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
    }
    public ApplicationContext(string connectionString)
    {
        _connectionString = connectionString;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
