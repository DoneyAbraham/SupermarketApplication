using SuperMarketApplication.Data.DataAccess;
using SuperMarketApplication.Data.Helpers;
using SuperMarketApplication.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace SuperMarketApplication.DataAccess.Controllers
{
    public class UsersRepository : BaseRepository
    {
        public IList<User> GetAllUsers()
        {
            return IncludeChildren(this.Context.Users).ToList();
        }

        public User GetUser(Guid id)
        {
            return this.FindEntity(IncludeChildren(this.Context.Users), id);
        }

        public User GetUser(string email)
        {
            return IncludeChildren(this.Context.Users).FirstOrDefault(u => u.Email.Equals(email));
        }

        public bool ValidateUser(string email, string password)
        {
            var encryptedPassword = EncryptionHelper.EncryptPassword(password);

            return this.Context.Users.Any(u => u.Email.Equals(email) && u.Password.Equals(encryptedPassword));
        }

        public User CreateUser(string firstName, string email, string password)
        {
            var encryptedPassword = EncryptionHelper.EncryptPassword(password);

            var user = new User
            {
                FirstName = firstName,
                Email = email,
                Password = encryptedPassword
            };

            this.Context.Users.Add(user);

            this.Context.SaveChanges();

            return user;
        }

        public User UpdateUserEmail(Guid id, string email)
        {
            var user = this.GetUser(id);
            user.Email = email;

            this.Context.SaveChanges();

            return user;
        }

        public IList<ShoppingHistory> GetHistory(Guid userId)
        {
            return IncludeChildren(this.Context.ShoppingHistory).Where(s => s.UserId == userId).OrderBy(s => s.Created).ToList();
        }

        private static IQueryable<User> IncludeChildren(IQueryable<User> collection)
        {
            return collection.Include(u => u.ShoppingHistory);
        }

        private static IQueryable<ShoppingHistory> IncludeChildren(IQueryable<ShoppingHistory> collection)
        {
            return collection.Include(u => u.Recipes).Include(s => s.Ingredients);
        }
    }
}
