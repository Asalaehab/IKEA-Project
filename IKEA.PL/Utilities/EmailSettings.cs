using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.Net;
using System.Net.Mail;

namespace IKEA.PL.Utilities
{
    public static class EmailSettings
    {
        public static void sendEmail(Email email)
        {

            //Send Email Process

            //1-create client you will send to him
            var client=new SmtpClient("smtp.gmail.com",587);



            //2-Configure Client
            // forces the connection to be secure — it encrypts the data sent over the internet so that no one can easily read or steal it.
            client.EnableSsl = true;

            //3-who you will send from?
            client.Credentials = new NetworkCredential("asalaehab824@gmail.com", "fmohrlgfwszucanq");


            client.Send("asalaehab824@gmail.com", email.To, email.subject, email.body);
        }
    }
}
