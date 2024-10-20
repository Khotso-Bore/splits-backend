using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitsAPI.Domian.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }

        public string Number { get; set; }

        public ICollection<Transaction> DebtTransactions { get; set; }
        public ICollection<Transaction> CreditTransactions { get; set; }
        public ICollection<Contact> Contacts { get; set; }
    }
}
