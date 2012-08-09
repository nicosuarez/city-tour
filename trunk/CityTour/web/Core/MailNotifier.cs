using System.Net;
using System.Net.Mail;
using System.Text;
using web.Models;

namespace web.Core
{
    public class MailNotifier : IClientNotifier
    {
        private const string senderName = "City Tour";

        public void NotifyReservationConfirmed(Reservation reservation, string name, string email, string message)
        {
            if (reservation.Accepted)
            {                
                const string subject = "Confirmación de reserva";
                var fromAddress = new MailAddress(Configuration.GetNotifierEmailAddress(), senderName);
                var toAddress = new MailAddress(email, name);
                string fromPassword = Configuration.GetNotifierEmailPass();

                StringBuilder body = new StringBuilder();
                body.AppendFormat("Su reserva en el {0} para la fecha {1} en el horario {2} ha sido confirmada.", reservation.BookingCommerce.Commerce.Name, reservation.ReservationDate.ToShortDateString(), reservation.ReservationDate.ToShortTimeString());
                body.AppendLine(" ");
                body.AppendLine(string.Format("Recuerde que el costo es de {0}", reservation.Price.ToString("C")));
                body.AppendLine(" ");
                body.AppendLine(string.Format("El responsable dice: {0}", message));
                body.AppendLine(" ");
                body.AppendLine("Para contactarse con el lugar puede hacerlo a: ");
                body.AppendLine(" ");
                body.AppendLine(string.Format("Email: {0}", reservation.BookingCommerce.ContactMail));
                body.AppendLine(string.Format("Telefono: {0}", reservation.BookingCommerce.ContactPhone));

                var smtp = new SmtpClient
                {
                    Host = Configuration.GetSMTPServer(),
                    Port = Configuration.GetSMTPPort(),
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };

                using (var mailMessage = new MailMessage(fromAddress, toAddress) { Subject = subject, Body = body.ToString() })
                {
                    smtp.Send(mailMessage);
                } 
            }                       
        }

        public void NotifyReservationCancelled(Reservation reservation, string name, string email, string message)
        {
            const string subject = "Cancelación de reserva";
            var fromAddress = new MailAddress(Configuration.GetNotifierEmailAddress(), senderName);
            var toAddress = new MailAddress(email, name);
            string fromPassword = Configuration.GetNotifierEmailPass();

            StringBuilder body = new StringBuilder();
            body.AppendFormat("Su reserva en el {0} para la fecha {1} en el horario {2} ha sido cancelada.", reservation.BookingCommerce.Commerce.Name, reservation.ReservationDate.ToShortDateString(), reservation.ReservationDate.ToShortTimeString());
            body.AppendLine(" ");
            body.AppendLine(string.Format("El responsable dice: {0}", message));
            body.AppendLine(" ");
            body.AppendLine("Para contactarse con el lugar puede hacerlo a: ");
            body.AppendLine(" ");
            body.AppendLine(string.Format("Email: {0}", reservation.BookingCommerce.ContactMail));
            body.AppendLine(string.Format("Telefono: {0}", reservation.BookingCommerce.ContactPhone));

            var smtp = new SmtpClient
            {
                Host = Configuration.GetSMTPServer(),
                Port = Configuration.GetSMTPPort(),
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };

            using (var mailMessage = new MailMessage(fromAddress, toAddress) { Subject = subject, Body = body.ToString() })
            {
                smtp.Send(mailMessage);
            } 
        }
    }
}