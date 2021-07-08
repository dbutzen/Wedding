using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DTB.Wedding.WebApp.Models
{
    public class Family
    {
        [Key]
        public Guid Id { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public string Name { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public string Code { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Email { get; set; }
    }
}
