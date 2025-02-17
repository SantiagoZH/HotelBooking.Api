using System.Threading.Tasks;

namespace HotelBooking.Application.Interfaces
{
    public interface IUserService
    {
        Task<bool> RegisterAsync(string name, string email, string password, string role);
        Task<string?> AuthenticateAsync(string email, string password);
    }
}
