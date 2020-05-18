using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankAccount.Core.Domain.Models
{
    public class Account : EntityBase
    {
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public User User { get; set; }

        [ForeignKey(nameof(Currency))]
        public int CurrencyId { get; set; }
        public Currency Currency { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime OpenedDate { get; set; }


        [Column(TypeName = "Money")]
        public decimal Balance { get; set; }
    }
}
