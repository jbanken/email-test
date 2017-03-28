using System.Threading.Tasks;
namespace Email.MailGunEmailProvider.Interfaces
{
    public interface IMailGunService
    {
        Task<Models.SendResponse> Send(Models.SendRequest request);
    }
}
