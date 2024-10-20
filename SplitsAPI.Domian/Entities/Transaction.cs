using SplitsAPI.Domian.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitsAPI.Domian.Entities
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public Guid CreditorId { get; set; }
        public Guid DebtorId { get; set; }
        public string Occassion { get; set; }
        public Category Category {  get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public TransactionState TransactionState { get; set; }
        public User CreditorUser { get; set; }
        public User DebtorUser { get; set; }


        

    }
}
