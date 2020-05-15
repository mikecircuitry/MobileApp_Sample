using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.ConstrainedExecution;
namespace ProjectData.Models
{
    [Table("ProjectData")]
    public class Projectx
    {
        public string Company { get; set; }
        
        public int Id { get; set; }

        [Column("last_name")]
        public string LastName { get; set; }

        [Column("first_name")]
        public string FirstName { get; set; }
        
        public string Email { get; set; }
        
        [Column("ProjectName")]
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime ProjectDate { get; set; }

    }
}