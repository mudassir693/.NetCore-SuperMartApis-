using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShopigStore.Model
{
    public class UserCred
    {
        [Column(TypeName="nvarchar(225)")]
        public string Email { get; set; }
        [Column(TypeName="nvarchar(225)")]
        public string Password { get; set; }
    }
}