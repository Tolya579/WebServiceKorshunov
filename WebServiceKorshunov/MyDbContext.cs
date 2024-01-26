using Microsoft.EntityFrameworkCore;
using WebServiceKorshunov;

/// <summary>
/// Контекст базы данных приложения, предоставляющий доступ к сущности <see cref="MailRecord"/>.
/// </summary>
public class MyDbContext : DbContext
{
    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="MyDbContext"/>.
    /// </summary>
    /// <param name="options">Параметры конфигурации контекста базы данных.</param>
    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }
    /// <summary>
    /// Получает или устанавливает набор данных для работы с записями почты в базе данных.
    /// </summary>
    public DbSet<MailRecord> MailRecords { get; set; }
}