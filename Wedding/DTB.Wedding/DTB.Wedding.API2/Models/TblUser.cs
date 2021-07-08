using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DTB.Wedding.API2.Models
{
    [Table("tblUser")]
    public partial class TblUser
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Username { get; set; }
        [Required]
        [StringLength(64)]
        public string Password { get; set; }
        public Guid UniqueKey { get; set; }
        public Guid? SessionKey { get; set; }
    }
}
