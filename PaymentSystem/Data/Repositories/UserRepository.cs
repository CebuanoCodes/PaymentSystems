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
        
        private readonly UserDbContext _context;

        public UserRepository(UserDbContext context)
        {
            _context = context;
        }

        public Task<User> GetWithPaymentsByIdAsync(int id)
        {
            return _context.Users
                .Include(a => a.Payments)
                .SingleOrDefaultAsync(a => a.Id == id);
            //.OrderBy(x => x.DateQ
        }

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

