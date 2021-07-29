using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

namespace ProvaConnessioneLicenze.Models
{
    public class UserExtAdd
    {
        [Key]
        [Column("userid", TypeName = "int unsigned")]
        [Display(Name = "ID User")]
        public int Userid { get; set; }
        [Column("customerid", TypeName = "int unsigned")]
        [Display(Name = "Cliente")]
        [Required(ErrorMessage = "Campo CLIENTE obbligatorio")]
        public int Customerid { get; set; }
        [Required(ErrorMessage = "Campo USERNAME obbligatorio")]
        [Column("username")]
        [StringLength(50)]
        public string Username { get; set; }
        [Required(ErrorMessage = "Campo PASSWORD obbligatorio")]
        [Column("password")]
        [StringLength(100)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Campo NOME obbligatorio")]
        [Column("name")]
        [StringLength(100)]
        [Display(Name = "Nome")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Campo COGNOME obbligatorio")]
        [Column("surname")]
        [StringLength(100)]
        [Display(Name = "Cognome")]
        public string Surname { get; set; }
        [Column("email")]
        [StringLength(250)]
        [EmailAddress(ErrorMessage ="Inserire una e-mail valida !")]
        [Required(ErrorMessage = "Campo E-MAIL obbligatorio")]
        public string Email { get; set; }

        public IDictionary<string, string> CustomerDict { get; set; }

        public string GeneraPassword()
        {
            int len = 12;
            const string ValidChar = "qwertyuioplkjhgfdsazxcvbnm:!?/%&$@#QWERTYUIOPLKJHGFDSAZXCVBNM1234567890";

            StringBuilder result = new StringBuilder();

            Random rnd = new Random();

            while (0 < len--)
            {
                result.Append(ValidChar[rnd.Next(ValidChar.Length)]);
            }

            return result.ToString();
        }

        public string GeneraUsername()
        {
            int len = 4;
            const string ValidChar = "1234567890";

            StringBuilder result = new StringBuilder();

            Random rnd = new Random();

            while (0 < len--)
            {
                result.Append(ValidChar[rnd.Next(ValidChar.Length)]);
            }

            return "IMP-" + result.ToString();
        }
    }
}
