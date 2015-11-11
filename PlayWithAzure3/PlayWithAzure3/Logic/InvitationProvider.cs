using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using StackExchange.Redis;

namespace AngularJSWebApiEmpty.Logic
{
    public class InvitationProvider
    {
        private readonly ConnectionMultiplexer _connection;

        public InvitationProvider()
        {
            var config = new ConfigurationOptions
            {
                Ssl = true,
                Password = "zrCEoAMFMBrrJXRQwuE38o/ypwEKgjg2M0QF6HxiVX8=",
                EndPoints = { { "bizexperiments.redis.cache.windows.net", 6380 } }
            };
            _connection = ConnectionMultiplexer.Connect(config);
        }

        public void RequestSubscription(string email)
        {
            var invitationCode = GenerateRandomString();
            SaveCodeToReddis(invitationCode, email);
            SendCodetoEmail(invitationCode, email);
        }

        private void SendCodetoEmail(string invitationCode, string email)
        {
            string body =
                $"You asked to recive updates on the newsletter, if this is so please copy this code in the browser window {invitationCode}";
            var message = new MailMessage
            {
                From = new MailAddress("experiments@bizagi.com"),
                Subject = "Newsletter confirmation",
                Body = body,
                To = {email}
            };

            using (var smtp = new SmtpClient("smtp.mandrillapp.com", 587))
            {
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential("cloud-modeler@bizagi.com", "D1CqWjJdlOErYNxMIFmJzA");
                smtp.Send(message);
            }
        }

        public bool ValidateInvitationCode(string email, string invitationCode)
        {
            bool isValid = false;
            var db = _connection.GetDatabase();
            var storedCode = db.StringGet(email);
            if (storedCode.HasValue)
            {
                isValid = storedCode.ToString() == invitationCode;
                db.KeyDelete(email, CommandFlags.FireAndForget);
            }
            return isValid;
        }

        private void SaveCodeToReddis(string invitationCode, string email)
        {
            var db = _connection.GetDatabase();
            db.StringSet(email, invitationCode, TimeSpan.FromDays(2));
        }

        private string GenerateRandomString()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, 16)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
            return result;
        }

    }
}