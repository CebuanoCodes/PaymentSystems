using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PaymentSystem.Core.Models;
using PaymentSystem.Core.Repositories;

namespace PaymentSystem.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        //injecting the UserDB Context
        private readonly UserDbContext _context;

        public UserRepository(UserDbContext context)
        {
            _context = context;
        }

        //method that will retrieve data from the database
        public Task<User> GetWithPaymentsByIdAsync(int id)
        {
            return _context.Users
                .Include(a => a.Payments)//.OrderByDescending(x => x.Date)
                .SingleOrDefaultAsync(a => a.Id == id);
        }
        //Method that will check if the user-key value is true/valid
        public bool CheckValidUserKey(string reqkey)
        {
            var userkeyList = new List<string>
            {
                "28236d8ec201df516d0f6472d516d72d",
                "38236d8ec201df516d0f6472d516d72c",
                "48236d8ec201df516d0f6472d516d72b"
            };

            if (userkeyList.Contains(reqkey))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}

