using PaymentSystem.Core.Models;
using PaymentSystem.Core.Repositories;
using PaymentSystem.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace PaymentSystem.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        //method that will invoke the GetWithPaymentsByIdAsync from the UserRepository
        public async Task<User> GetUserById(int id)
        {
            return await _userRepository.GetWithPaymentsByIdAsync(id);
        }
        //method that wil invoke the CheckValidUserKey from the UserRepository
        public bool CheckValidUserKey(string reqkey)
        {
            return _userRepository.CheckValidUserKey(reqkey);
        }
    }
}
