using Email.Services.Models;
using System.Threading.Tasks;

namespace Email.Services.Interfaces
{
    public interface ISendService
    {
        Task<SendResponse> Send(SendRequest request);
    }
}
