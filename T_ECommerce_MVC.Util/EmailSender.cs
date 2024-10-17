using Microsoft.AspNetCore.Identity.UI.Services;

namespace T_ECommerce_MVC.Util
{
    public class EmailSender : IEmailSender
    {

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return Task.CompletedTask;
        }
    }
}
