using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ShopigStore.Model;

namespace ShopigStore.Data
{
    public class ProjectRepo : IProjectRepo
    {
        private readonly ProjectContext _context;
        private readonly IConfiguration _config;

        public ProjectRepo(ProjectContext context,IConfiguration config)
        {
            _context=context;
            _config=config;
        }

        public string AuthenticationManager(string email, string password)
        {
            if(!_context.Users.Any(x=>x.Email == email && x.Password == password)) return null;

            var TokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(_config["Key"]);
            var TokenDescriptor = new SecurityTokenDescriptor{
                Subject= new ClaimsIdentity(new Claim[]{
                    new Claim(ClaimTypes.Name,email),
                }),
                Expires=DateTime.UtcNow.AddDays(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey),SecurityAlgorithms.HmacSha256Signature)
            };
            var token = TokenHandler.CreateToken(TokenDescriptor);
            return TokenHandler.WriteToken(token);
        }

        public bool CreateIntrust(Intrust item)
        {
            _context.Intrust.Add(item);
            return true;
        }

        public bool CreateItem(Item item)
        {
            item.EntryDate= DateTime.Now;
            item.UpdateEntry= DateTime.Now;
            _context.Items.Add(item);
            return true;
        }

        public bool CreateUser(User user)
        {
            if(_context.Users.Any(x=>x.Email == user.Email)) return false;
            user.CreatedAt = DateTime.Now;
            user.UpdatedAt = DateTime.Now;

            _context.Users.Add(user);
            return true;
        }

        public IEnumerable<Item> getAllItems()
        {
            return _context.Items;
        }

        public IEnumerable<Item> GetAllItemsForSpecificUser(int id)
        {
            try{
            var user =_context.Users.FirstOrDefault(x=>x.UserId == id);
            var userIntrust = user.Intrusts.Split(',');
            var resp = _context.Items.Where(u => u.Category == userIntrust[0]  );

            for (int i=1; i<=userIntrust.Length; i++)
			{
				// sum = sum + i;
				 var resp2 = _context.Items.Where(u => u.Category == userIntrust[i]);
                 resp.Concat(resp2);
			}

            return resp;
            // var category = _context.Users.FirstOrDefault(x=>x.UserId == id);
            // var category2 = _context.Intrust.Where(x=>x.UserId == id);
            // return _context.Items.Where(x =>x.Category == "Crockry");
            }  catch (Exception e)
        {
            Console.WriteLine("{0} Exception caught.", e);
           return  _context.Items;
        };
        }

        public IEnumerable<User> getAllUser()
        {
            return _context.Users;
        }

        public Item GetItemById(int id)
        {
            return _context.Items.Include(x=>x.UserItem ).ThenInclude(x=>x.Users).FirstOrDefault(it => it.ItemId == id);
        }

        public User GetUserById(int id)
        {
           return _context.Users.Include(x=>x.UserItem).ThenInclude(x=>x.Items).Include(x=>x.Intrust).FirstOrDefault(u => u.UserId == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges()>=0);
        }

        public User SignInRoute(string email, string password)
        {
            var resp = _context.Users.FirstOrDefault(x=>x.Email == email && x.Password == password);
            return resp;
        }

        public void UpdateItem(Item item)
        {
        }

        public void UpdateUser(User user)
        {
            
        }
    }
}