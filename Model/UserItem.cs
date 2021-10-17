namespace ShopigStore.Model
{
    public class UserItem
    {
        public int UserId { get; set; }
        public int ItemId { get; set; }
        public User Users { get; set; }
        public Item Items { get; set; }
    }
}