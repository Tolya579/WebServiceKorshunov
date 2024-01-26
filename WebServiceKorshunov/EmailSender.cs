using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using WebServiceKorshunov;

/// <summary>
/// Реализация интерфейса для отправки электронной почты.
/// </summary>
public class EmailSender : IEmailSender
{
    private readonly SmtpSettings _smtpSettings;

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="EmailSender"/>.
    /// </summary>
    /// <param name="smtpSettings">Настройки SMTP-сервера.</param>
    public EmailSender(IOptions<SmtpSettings> smtpSettings)
    {
        _smtpSettings = smtpSettings.Value;
    }

    /// <summary>
    /// Асинхронно отправляет электронное письмо с указанной темой, текстом сообщения и адресатами.
    /// </summary>
    /// <param name="subject">Тема письма.</param>
    /// <param name="message">Текст сообщения.</param>
    /// <param name="recipients">Перечисление адресатов.</param>
    /// <returns>Задача, представляющая отправку письма.</returns>
    public async Task SendEmailAsync(string subject, string message, IEnumerable<string> recipients)
    {
        using (var client = new SmtpClient())
        {
            client.Host = _smtpSettings.Host;
            client.Port = _smtpSettings.Port;
            client.EnableSsl = _smtpSettings.EnableSsl;
            client.Credentials = new NetworkCredential(_smtpSettings.Username, _smtpSettings.Password);

            var mailMessage = new MailMessage
            {
                From = new MailAddress(_smtpSettings.FromAddress),
                Subject = subject,
                Body = message,
                IsBodyHtml = true
            };

            foreach (var recipient in recipients)
            {
                mailMessage.To.Add(recipient);
            }

            try
            {
                await client.SendMailAsync(mailMessage);
            }
            catch (Exception ex)
            {
                // Обработка исключений, если возникла ошибка при отправке
                throw;
            }
        }
    }
}
