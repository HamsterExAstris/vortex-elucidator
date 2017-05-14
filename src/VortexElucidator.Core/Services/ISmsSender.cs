using System.Threading.Tasks;

namespace ShatteredTemple.VortexElucidator.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
