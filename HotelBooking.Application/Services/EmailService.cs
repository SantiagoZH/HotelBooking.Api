using MailKit.Net.Smtp;
using MimeKit;
using System.Net.Mail;
using System.Threading.Tasks;

public class EmailService
{
    //Email service disabled
    private readonly string _smtpServer = "";
    private readonly int _smtpPort = 000;
    private readonly string _username = "";
    private readonly string _password = "";

    public async Task SendConfirmationEmailAsync(string recipientEmail, string reservationDetails)
    {
        var emailMessage = new MimeMessage();
        emailMessage.From.Add(new MailboxAddress("Hotel Booking", _username));
        emailMessage.To.Add(new MailboxAddress("", recipientEmail));
        emailMessage.Subject = "Confirmación de Reserva";

        var bodyBuilder = new BodyBuilder
        {
            TextBody = $"Hola,\n\nTu reserva ha sido confirmada.\n\nDetalles de la reserva:\n{reservationDetails}\n\n¡Gracias por reservar con nosotros!"
        };

        emailMessage.Body = bodyBuilder.ToMessageBody();

        using (var client = new MailKit.Net.Smtp.SmtpClient())
        {
            await client.ConnectAsync(_smtpServer, _smtpPort, false);
            await client.AuthenticateAsync(_username, _password);
            await client.SendAsync(emailMessage);
            await client.DisconnectAsync(true);
        }
    }
}
