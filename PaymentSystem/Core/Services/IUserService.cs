using System.Threading.Tasks;
using PaymentSystem.Core.Models;

namespace PaymentSystem.Core.Services
{
    public interface IUserService
    {
        Task<User> GetUserById(int id);
        bool CheckValidUserKey(string reqkey);


    }
}