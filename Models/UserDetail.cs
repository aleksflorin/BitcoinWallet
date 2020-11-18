using NBitcoin;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BitcoinWallet.Models
{
    public class UserDetail
    {
        [Key]
        public Guid id { get; set; }
        [Required]
        public Guid user_id { get; set; }

        public String user_adress { get; set; }
    }
}
