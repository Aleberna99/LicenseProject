using iTextSharp.text.pdf;
using ProvaConnessioneLicenze.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ProvaConnessioneLicenze.Models
{
    public class EmailEngine
    {
        public void SendEmail(Customer customer, string email, string pdfName)
        {
            try
            {
                using (SmtpClient client = new SmtpClient("smtp.gmail.com", 587))
                {
                    client.EnableSsl = true;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential("aleberna999@gmail.com", "pc4centro");

                    MailMessage msg = new MailMessage();
                    msg.To.Add(email);
                    msg.From = new MailAddress("aleberna999@gmail.com", "ImporterONE");
                    msg.Subject = "Licenza ImporterONE";
                    msg.Body = "Gentile cliente " + customer.Company.ToUpper() + ", \n" +
                        "ti inviamo in allegato l'elenco delle Licenze ImporterONE in tuo possesso. \n\n" +
                        "Ricordiamo che se sei in possesso di una licenza attiva con Supporto Tecnico scrivici all'indirizzo support@importerone.it per fissare un appuntamento,\n\n " +
                        "altrimenti è possibile acquistare pacchetti di assistenza all'indirizzo https://www.imprimis.it/prodotto/assistenza-software/ \n\n" +
                        "Per maggiori informazioni riguardo le condizioni di supporto consultare la pagina https://www.imprimis.it/importerone/support/ ";

                    Attachment att = new Attachment(@"..\wwwroot\document\PDF\" + pdfName);
                    msg.Attachments.Add(att);

                    client.Send(msg);
                    att.Dispose();
                }
                
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
        }
    }
}
