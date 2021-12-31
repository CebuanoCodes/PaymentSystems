using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentSystem

{
    public class UserConstants
    {
        public static List<UserModel> Users = new List<UserModel>()
        {
            new UserModel() { Username = "john_admin", EmailAddress = "john.admin@email.com", Password = "MyPass_w0rd", GivenName = "John", Surname = "Brown", Role = "Administrator" },
        };
    }
}
