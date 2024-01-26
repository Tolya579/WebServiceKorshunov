using System.Collections.Generic;

namespace WebServiceKorshunov
{
    /// <summary>
    /// Представляет запрос на отправку почты.
    /// </summary>
    public class MailRequest
    {
        /// <summary>
        /// Получает или устанавливает тему письма.
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// Получает или устанавливает текст письма.
        /// </summary>
        public string Body { get; set; }
        /// <summary>
        /// Получает или устанавливает список адресатов письма.
        /// </summary>
        public List<string> Recipients { get; set; }
    }
}
