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
            var result = Session.Query<Usuario>()
                .Any(u => u.email == email && u.password == password);
            return result;
        }

        public void SendEmail(string clientEmail, int newCode)
        {
            var serverEmail = "devops.authenticator@gmail.com";
            var fromEmail = new MailAddress(serverEmail, "GoogleKeep Code 2Factor");
            var toEmail = new MailAddress(clientEmail);
            var message = new MailMessage(fromEmail, toEmail);
            message.Subject = "GoogleKeep Code";
            var htmlTag = @"<!DOCTYPE html>
                            <html>
                            <head>
                              <meta charset=""UTF-8"">
                              <title>Verificación de Seguridad</title>
                            </head>
                            <body style=""font-family: Arial, sans-serif; background-color: #f4f4f4; margin:0; padding:0;"">
                              <table width=""100%"" cellpadding=""0"" cellspacing=""0"" style=""background-color:#f4f4f4; padding:20px;"">
                                <tr>
                                  <td align=""center"">
                                    <table width=""600"" cellpadding=""0"" cellspacing=""0"" style=""background-color:#ffffff; border-radius:8px; overflow:hidden;"">
                                      <tr>
                                        <td style=""background-color:#004080; color:#ffffff; text-align:center; padding:20px; font-size:20px; font-weight:bold;"">
                                          Verificación en Dos Pasos
                                        </td>
                                      </tr>
                                      <tr>
                                        <td style=""padding:30px; text-align:center; color:#333333;"">
                                          <p style=""font-size:16px; margin-bottom:20px;"">
                                            Hola, tu código de verificación es:
                                          </p>
                                          <p style=""font-size:32px; font-weight:bold; letter-spacing:8px; color:#004080; margin:20px 0;"">
                                            {0}
                                          </p>
                                          <p style=""font-size:14px; color:#666666;"">
                                            Ingresa este código en la aplicación para completar tu inicio de sesión seguro.
                                          </p>
                                        </td>
                                      </tr>
                                      <tr>
                                        <td style=""background-color:#f0f0f0; text-align:center; padding:15px; font-size:12px; color:#888888;"">
                                          Este código expira en 5 minutos. Si no solicitaste este código, ignora este mensaje.
                                        </td>
                                      </tr>
                                    </table>
                                  </td>
                                </tr>
                              </table>
                            </body>
                            </html>";
            message.Body = string.Format(htmlTag, newCode);
            message.IsBodyHtml = true;

            var service = new SmtpClient("smtp.gmail.com", 587);
            service.EnableSsl = true;
            service.Credentials = new NetworkCredential(serverEmail, "mqsu ccdd puqd avqo");
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
