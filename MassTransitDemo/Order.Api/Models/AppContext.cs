using Microsoft.EntityFrameworkCore;

namespace Order.Api.Models;

public class AppContext : DbContext
{
    public AppContext(DbContextOptions<AppContext> options) : base(options)
    {
        
    }
}