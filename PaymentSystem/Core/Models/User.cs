using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PaymentSystem.Core.Models
{
    public class User
    {
        public User()
        {
            Payments = new Collection<Payments>();
        }

        public int Id { get; set; }
        public decimal AccountBalance { get; set; }
        public ICollection<Payments> Payments { get; set; }
    }
}