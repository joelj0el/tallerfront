using googlekeep.Business.Contracts;
using googlekeep.Entity;
using System.Net;
using System.Net.Mail;

namespace googlekeep.Data
{
    public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
    {
        public List<Usuario> filterByName(string data)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> getAll()
        {
            var result = Session.Query<Usuario>().ToList();
            return result;
        }

        public bool verifyCredential(string email, string password)
        {
            var result = Session.QueryOver<Usuario>()
                .Where(src => src.password.ToUpper() == password && src.email.ToUpper() == email);
            return result != null;
        }

        public void SendEmail(string clientEmail)
        {
            var serverEmail = "clientEmail@gmail.com";
            var fromEmail = new MailAddress(serverEmail, "GoogleKeep Code 2Factor");
            var toEmail = new MailAddress(clientEmail);

            var message = new MailMessage(fromEmail, toEmail);
            message.Subject = "GoogleKeep Code";
            message.Body = "Your code is: <strong>3839</strong>";
            message.Priority = MailPriority.High;
            message.IsBodyHtml = true;

            var service = new SmtpClient("smtp.gmail.com", 587);
            service.EnableSsl = true;
            service.Credentials = new NetworkCredential(serverEmail, "password_16_digitos");
            try
            {
                service.Send(message);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
