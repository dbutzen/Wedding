using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DTB.Wedding.API.Models
{
    [Table("tblFamily")]
    public partial class TblFamily
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string Code { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
    }
}
