using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShopigStore.Model
{
    public class Item
    {
        public int ItemId { get; set; }
        [Column(TypeName="varchar(225)")]
        public string Title { get; set; }
        public int Price { get; set; }
        [Column(TypeName="varchar(225)")]
        public string Category { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime UpdateEntry { get; set; }
        public IEnumerable<UserItem> UserItem { get; set; }
    }
}