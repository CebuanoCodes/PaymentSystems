using System.Threading.Tasks;
using PaymentSystem.Core.Models;

namespace PaymentSystem.Core.Repositories
{
    public interface IUserRepository 
    {       
        Task<User> GetWithPaymentsByIdAsync(int id);
        bool CheckValidUserKey(string reqkey);
    }
}
