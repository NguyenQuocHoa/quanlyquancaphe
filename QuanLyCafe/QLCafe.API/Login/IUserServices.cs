using Library;

using System.Threading.Tasks;

namespace QLCafe.API.Login
{
   public interface IUserServices
    {
        Task<string> Authenticate(LoginRequest request);

    }
}
