using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProvaConnessioneLicenze.Models
{
    public class LicenseExt
    {
        [Key]
        [StringLength(50)]
        [Display(Name = "Chiave")]
        public string Activationcode { get; set; }
   
        [Display(Name = "Scadenza")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime Duedate { get; set; }
        [Display(Name = "Tipo Prodotto")]
        public string Producttitle { get; set; }
        [Display(Name = "Cliente")]
        public string Company { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        [Display(Name = "Locked")]
        public bool Locked { get; set; }



    }
}
