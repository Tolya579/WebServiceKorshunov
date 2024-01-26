using System;
using System.Collections.Generic;

namespace WebServiceKorshunov
{
    /// <summary>
    /// Представляет запись о письме, сохраненную в базе данных.
    /// </summary>
    public class MailRecord
    {
        /// <summary>
        /// Получает или устанавливает уникальный идентификатор записи.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Получает или устанавливает тему письма.
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Получает или устанавливает текст письма.
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// Получает или устанавливает строку с адресатами письма.
        /// </summary>
        public string Recipients { get; set; }

        /// <summary>
        /// Получает или устанавливает дату и время создания записи.
        /// </summary>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Получает или устанавливает результат отправки письма (например, "OK" или "Failed").
        /// </summary>
        public string Result { get; set; }

        /// <summary>
        /// Получает или устанавливает сообщение об ошибке, если отправка не удалась.
        /// </summary>
        public string FailedMessage { get; set; }
    }
}
