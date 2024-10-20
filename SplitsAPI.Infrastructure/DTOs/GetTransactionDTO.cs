using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitsAPI.Infrastructure.DTOs
{
    public class GetTransactionDTO
    {
        public string DebtorId { get; set; }
        public string CreditorId { get; set; }
    }
}
