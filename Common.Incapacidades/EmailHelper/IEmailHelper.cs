using System.Threading.Tasks;

namespace Common.EmailHelper
{
    public interface IEmailHelper
    {
        Task<MailResponse> SendEmail(EmailModel email);
    }
}
