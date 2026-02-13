using System;
using asp.net_crud.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace asp.net_crud.Context;

public class ApplicationDbContext:DbContext
{
     public ApplicationDbContext(DbContextOptions options):base(options)
    {
        
    }

    public DbSet<Employee> Employees { get; set; }
    public DbSet <Note> Notes { get; set; }
}
