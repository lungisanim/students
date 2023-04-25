using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using University.Models;     

public class StudentContext : DbContext
{
    
    public StudentContext(DbContextOptions<StudentContext> options)
        : base(options)
    {
    }

    public DbSet<University.Models.Student>? Student { get; set; }
}
