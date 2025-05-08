namespace Common.EmailHelper
{
    public class MailServiceConfiguration
    {
        public string NotificationMail { get; set; }
        public string NotificationPassword { get; set; }
        public string NotificationServer { get; set; }
        public int NotificationPort { get; set; }
        public bool EnableSsl { get; set; }
    }
}
