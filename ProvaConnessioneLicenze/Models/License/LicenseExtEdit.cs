using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProvaConnessioneLicenze.Models
{
    public class LicenseExtEdit
    {
        public License License { get; set; }
        public User User { get; set; }
        public IDictionary<string, string> CustomerDict { get; set; }
        public IDictionary<string, string> LicenseDict { get; set; }
        public IDictionary<string, string> UserDict { get; set; }

    }
}
