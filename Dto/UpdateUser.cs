using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShopigStore.Dto
{
    public class UpdateUser
    {
         [Column(TypeName="nvarchar(225)")]
        public string Name { get; set; }
        [Column(TypeName="nvarchar(225)")]
        public string Email { get; set; }
        [Column(TypeName="nvarchar(225)")]
        public string Password { get; set; }
        [Column(TypeName="nvarchar(225)")]
        public string Address { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}