using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DTB.Wedding.API.Models
{
    [Table("tblGuest")]
    public partial class TblGuest
    {
        [Key]
        public Guid Id { get; set; }
        public Guid FamilyId { get; set; }
        public Guid TableId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public bool PlusOne { get; set; }
        public bool Attendance { get; set; }
        public bool PlusOneAttendance { get; set; }
        public bool Responded { get; set; }
    }
}
