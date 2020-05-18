using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankAccount.Core.Domain.Models
{
    public class User : EntityBase
    {
        [DataType(DataType.Text), MaxLength(50), Required]
        public string Name { get; set; }

        [DataType(DataType.Text), MaxLength(50), Required]
        public string Email { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Created { get; set; }

        public List<Account> Accounts { get; set; }
    }
}
