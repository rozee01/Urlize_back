﻿namespace Urlize_back.Services
{
    public interface IEmailService
    {
        Task SendEmailAsync(string toEmail, string subject, string body, bool isBodyHTML);
    }
}
