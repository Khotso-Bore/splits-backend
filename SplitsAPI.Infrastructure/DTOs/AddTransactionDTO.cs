using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitsAPI.Infrastructure.DTOs
{
    public class AddTransactionDTO
    {
        public Guid CreditorId { get; set; }
        public Guid DebtorId { get; set; }
        public string Occassion { get; set; }
        public int Category { get; set; }
        public decimal Amount { get; set; }
    }
}
