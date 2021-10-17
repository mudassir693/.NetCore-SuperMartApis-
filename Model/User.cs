using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShopigStore.Model
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Column(TypeName="nvarchar(225)")]
        public string Name { get; set; }
        [Column(TypeName="nvarchar(225)")]
        public string Email { get; set; }
        [Column(TypeName="nvarchar(225)")]
        public string Password { get; set; }
        [Column(TypeName="nvarchar(225)")]
        public string Address { get; set; }
        public string Intrusts { get; set; }
        public List<Intrust> Intrust { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public IEnumerable<UserItem> UserItem { get; set; }
    }
}