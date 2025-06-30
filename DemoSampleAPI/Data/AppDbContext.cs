using System;
using Microsoft.EntityFrameworkCore;

namespace DemoSampleAPI.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options) { }
}
