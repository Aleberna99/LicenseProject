using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ProvaConnessioneLicenze.Models
{
    [Table("modules")]
    public partial class Module
    {
        [Key]
        [Column("modulecode")]
        [StringLength(10)]
        public string Modulecode { get; set; }
        [Required]
        [Column("modulename")]
        [StringLength(100)]
        public string Modulename { get; set; }
        [Required]
        [Column("moduledescription")]
        [StringLength(250)]
        public string Moduledescription { get; set; }
        [Required]
        [Column("active")]
        public bool? Active { get; set; }
        [Required]
        [Column("filename")]
        [StringLength(100)]
        public string Filename { get; set; }
        [Column("moduletype", TypeName = "tinyint")]
        public byte Moduletype { get; set; }
    }
}
