using System.Net;
using System.Net.Mail;

namespace HueFestival.Middlewares
{
    public class GuiThongBao
    {
        public void ThongBaoDangNhap(string NoiDung, string ThongTin, string emailNhan )
        {
            string emailGui = "tealandtran1510@gmail.com";

            //email của người gửi
            string emailPassword = "tealand0506";
            string emailHost = "smtp.example.com";
            int emailPort = 993 ;

            // Tạo đối tượng MailMessage để gửi email
            MailMessage message = new MailMessage(emailGui, emailNhan, NoiDung, ThongTin);
            message.IsBodyHtml = true;

            // Khai báo đối tượng SmtpClient để gửi email
            SmtpClient smtpClient = new SmtpClient(emailHost, emailPort);
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(emailGui, emailPassword);
            smtpClient.EnableSsl = true;

            // Gửi email
            smtpClient.Send(message);
        }
    }
}