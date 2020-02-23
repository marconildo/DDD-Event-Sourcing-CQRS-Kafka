namespace MikeGrayCodes.BuildingBlocks.Infrastructure.Emails
{
    public interface IEmailSender
    {
        void SendEmail(EmailMessage message);
    }
}