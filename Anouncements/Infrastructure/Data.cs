using Anouncements.Models;
using Microsoft.EntityFrameworkCore;

namespace Anouncements.Infrastructure;

public class Data:DbContext
{
    public Data(DbContextOptions<Data> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<WeatherForecast>().HasKey(wf => wf.Id);
        modelBuilder.Entity<WeatherForecast>().Property(wf => wf.Date).IsRequired();
        modelBuilder.Entity<WeatherForecast>().Property(wf => wf.TemperatureC).IsRequired();
        modelBuilder.Entity<WeatherForecast>().Property(wf => wf.Summary).IsRequired().HasMaxLength(100);
    }
    public DbSet<WeatherForecast> WeatherForecasts { get; set; }
}
