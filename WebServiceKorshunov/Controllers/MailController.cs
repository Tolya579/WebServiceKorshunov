using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebServiceKorshunov
{
    /// <summary>
    /// Контроллер для работы с почтой.
    /// </summary>
    [ApiController]
    [Route("api/mails")]
    public class MailController : ControllerBase
    {
        private readonly IEmailSender _emailSender;
        private readonly MyDbContext _context;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="MailController"/>.
        /// </summary>
        /// <param name="emailSender">Сервис отправки электронной почты.</param>
        /// <param name="context">Контекст базы данных.</param>
        public MailController(IEmailSender emailSender, MyDbContext context)
        {
            _emailSender = emailSender;
            _context = context;
        }

        /// <summary>
        /// Отправляет почтовое сообщение.
        /// </summary>
        /// <param name="mailRequest">Запрос на отправку почты.</param>
        /// <returns>Результат операции отправки почты.</returns>
        [HttpPost]
        public async Task<IActionResult> SendMail([FromBody] MailRequest mailRequest)
        {
            var result = new MailRecord
            {
                Subject = mailRequest.Subject,
                Body = mailRequest.Body,
                Recipients = string.Join(";", mailRequest.Recipients),
                CreationDate = DateTime.UtcNow,
                Result = "OK",
                FailedMessage = string.Empty
            };

            try
            {
                await _emailSender.SendEmailAsync(mailRequest.Subject, mailRequest.Body, mailRequest.Recipients);
            }
            catch (Exception ex)
            {
                result.Result = "Failed";
                result.FailedMessage = ex.Message;
            }

            _context.MailRecords.Add(result);
            await _context.SaveChangesAsync();

            return result.Result == "OK" ? (IActionResult)Ok(result) : BadRequest(result);
        }

        /// <summary>
        /// Получает список записей почты.
        /// </summary>
        /// <returns>Список записей почты.</returns>
        [HttpGet]
        public async Task<IActionResult> GetMails()
        {
            var mailRecords = await _context.MailRecords.ToListAsync();

            return Ok(mailRecords);
        }
    }
}
