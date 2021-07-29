using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ProvaConnessioneLicenze.Models
{
    [Table("news_feed")]
    public partial class NewsFeed
    {
        [Key]
        [Column("newsid", TypeName = "int unsigned")]
        public int Newsid { get; set; }
        [Column("newsdate")]
        public DateTime Newsdate { get; set; }
        [Column("newstype")]
        public byte Newstype { get; set; }
        [Required]
        [Column("title")]
        public string Title { get; set; }
        [Required]
        [Column("message")]
        public string Message { get; set; }
        [Column("priority", TypeName = "tinyint")]
        public byte Priority { get; set; }
    }
}
