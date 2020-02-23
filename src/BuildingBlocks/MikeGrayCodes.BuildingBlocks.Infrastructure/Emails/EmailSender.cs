using Serilog;

namespace MikeGrayCodes.BuildingBlocks.Infrastructure.Emails
{
    public class EmailSender : IEmailSender
    {
        private readonly ILogger logger;
        private readonly EmailsConfiguration _configuration;
        public EmailSender(ILogger logger, EmailsConfiguration configuration)
        {
            this.logger = logger;
            _configuration = configuration;
        }
        public void SendEmail(EmailMessage message)
        {
            logger.Information(
                "Email sent. From: {From}, To: {To}, Subject: {Subject}, Content: {Content}.",
                _configuration.FromEmail,
                message.To,
                message.Subject,
                message.Content);
        }
    }
}