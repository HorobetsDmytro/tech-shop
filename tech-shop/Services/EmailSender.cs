using Microsoft.AspNetCore.Identity.UI.Services;

namespace tech_shop.Services
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            // Реалізуйте логіку відправки електронної пошти тут
            return Task.CompletedTask;
        }
    }
}
