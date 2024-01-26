using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebServiceKorshunov
{
    /// <summary>
    /// Предоставляет интерфейс для отправки электронной почты.
    /// </summary>
    public interface IEmailSender
    {
        /// <summary>
        /// Асинхронно отправляет электронное письмо с указанной темой, текстом сообщения и адресатами.
        /// </summary>
        /// <param name="subject">Тема письма.</param>
        /// <param name="message">Текст сообщения.</param>
        /// <param name="recipients">Перечисление адресатов.</param>
        /// <returns>Задача, представляющая отправку письма.</returns>
        Task SendEmailAsync(string subject, string message, IEnumerable<string> recipients);
    }
}
