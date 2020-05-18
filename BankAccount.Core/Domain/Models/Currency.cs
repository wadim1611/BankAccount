using System;
using System.ComponentModel.DataAnnotations;

namespace BankAccount.Core.Domain.Models
{
    public class Currency : EntityBase
    {
        [DataType(DataType.Text), MaxLength(3), Required]
        public string Code { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Created { get; set; }
    }
}
