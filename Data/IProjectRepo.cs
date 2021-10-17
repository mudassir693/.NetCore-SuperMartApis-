using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopigStore.Model;

namespace ShopigStore.Data
{
    public interface IProjectRepo
    {
        // User
        IEnumerable<User> getAllUser();
        User GetUserById(int id);
        User SignInRoute(string email,string password);
        bool CreateUser(User user);
        void UpdateUser(User user);

        // Item
        IEnumerable<Item> getAllItems();
        IEnumerable<Item> GetAllItemsForSpecificUser(int id);
        Item GetItemById(int id);
        bool CreateItem(Item item);
        void UpdateItem(Item item);
        // Add Intrust
        bool CreateIntrust(Intrust item);

        // bool AnOtherWayToCreateUserIntrust( );
        // AuthenticationManager
        string AuthenticationManager(string email,string password);

        // SaveChanges
        bool SaveChanges();
    }
}