using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaConnessioneLicenze.Models
{
    public class LicenseExtAdd
    {

        [Column("customerid", TypeName = "int unsigned")]
        [Display(Name = "Cliente")]
        [Required(ErrorMessage = "Campo CLIENTE obbligatorio")]
        public int Customerid { get; set; }

        [Key]
        [StringLength(50)]
        [Display(Name = "Chiave")]
        [Required]
        public string Activationcode { get; set; }
        [Display(Name = "Tipo Licenza")]
        [Required(ErrorMessage = "Campo TIPO LICENZA obbligatorio")]
        public byte Licensetype { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Campo NOME obbligatorio")]
        public string Name { get; set; }

        [Display(Name = "Cognome")]
        [Required(ErrorMessage = "Campo COGNOME obbligatorio")]
        public string Surname { get; set; }

        [Display(Name = "Scadenza")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        [Required]
        public DateTime Duedate { get; set; }

        [Display(Name = "Locked")]
        [Required]
        public bool Locked { get; set; }

        [Required]
        public bool Onlyforbeta { get; set; }

        [Display(Name = "Note")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Notes { get; set; }

        [StringLength(250)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Apiendpoint { get; set; }


        public IDictionary<string,string> CustomerDict { get; set; }

        public IDictionary<string, string> LicenseDict { get; set; }


        public string GeneraCodiceAttivazione()
        {
            string result;

            result = GeneraValori() + "-" + GeneraValori() + "-" + GeneraValori() + "-" + GeneraValori() + "-" + GeneraValori() + "-" + GeneraValori();

            return result;
        }

        private string GeneraValori()
        {
            int len = 5;
            const string ValidChar = "QWERTYUIOPLKJHGFDSAZXCVBNM1234567890";

            StringBuilder result = new StringBuilder();

            Random rnd = new Random();

            while (0 < len--)
            {
                result.Append(ValidChar[rnd.Next(ValidChar.Length)]);
            }

            return result.ToString();
        }


    }
}
