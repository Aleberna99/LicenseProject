using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ProvaConnessioneLicenze.Models
{
    [Table("news_feed_users")]
    public partial class NewsFeedUser
    {
        [Key]
        [Column("newsid", TypeName = "int unsigned")]
        public int Newsid { get; set; }
        [Key]
        [Column("userid", TypeName = "int unsigned")]
        public int Userid { get; set; }
        [Column("readdate")]
        public DateTime Readdate { get; set; }
    }
}
