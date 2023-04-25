using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;  

namespace University.Models
{
    [Table("student")]
    public class Student
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("first_name")]
        public string? FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("last_name")]
        public string? LastName { get; set; }

        [Required]
        [Column("age")]
        public int Age { get; set; }

        [MaxLength(10)]
        [Column("gender")]
        public string? Gender { get; set; }

        [MaxLength(10)]
        [Column("grade")]
        public string? Grade { get; set; }
}

}