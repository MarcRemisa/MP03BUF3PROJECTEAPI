using Microsoft.EntityFrameworkCore;

namespace AstronautasApi.Models;

public class TodoContext : DbContext
{
    public TodoContext(DbContextOptions<TodoContext> options)
        : base(options)
    {
    }

    public DbSet<AstronautasItem> AstronautasItem { get; set; } = null!;
}