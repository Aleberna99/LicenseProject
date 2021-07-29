using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ProvaConnessioneLicenze.Models
{
    public class CustomerEmail
    {
        public int Customerid { get; set; }
        
        public string Company { get; set; }

        [Required(ErrorMessage = "Campo E-MAIL obbligatorio")]
        [StringLength(250)]
        [Display(Name = "E-Mail")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [EmailAddress(ErrorMessage = "Inserire un e-mail valida")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo E-MAIL obbligatorio")]
        [StringLength(250)]
        [Display(Name = "E-Mail2")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [EmailAddress(ErrorMessage = "Inserire un e-mail valida")]
        public string Email2 { get; set; }
    
        public string FileName;

        public object ExploreFile()
        {
            Process.Start(FileName);
            return 1;
        }

    }
}
