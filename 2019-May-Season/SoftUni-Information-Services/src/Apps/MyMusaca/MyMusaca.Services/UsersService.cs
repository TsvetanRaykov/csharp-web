using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using MyMusaca.Data;
using MyMusaca.Models;

namespace MyMusaca.Services
{
    public class UsersService : IUsersService
    {
        private readonly MyMusacaDbContext dbContext;
        private readonly IOrdersService ordersService;

        public UsersService(MyMusacaDbContext dbContext, IOrdersService ordersService)
        {
            this.dbContext = dbContext;
            this.ordersService = ordersService;
        }

        public string CreateUser(string username, string email, string password)
        {
            var user = new User
            {
                Id = Guid.NewGuid().ToString(),
                Username = username,
                Email = email,
                Password = this.HashPassword(password)
            };

            //using (var transaction = dbContext.Database.BeginTransaction())
            //{
            //    try
            //    {
            //        this.dbContext.Add(user);
            //        this.dbContext.Add(activeOrder);
            //        this.dbContext.SaveChanges();

            //        transaction.Commit();
            //    }
            //    catch (Exception)
            //    {
            //        transaction.Rollback();
            //        user.Id = null;
            //    }
            //}

            this.dbContext.Add(user);
            this.dbContext.SaveChanges();

            return user.Id;
        }

        public User GetUserOrNull(string username, string password)
        {
            var user = this.dbContext.Users.FirstOrDefault(u =>
                u.Username == username && u.Password == this.HashPassword(password));
            return user;
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                return Encoding.UTF8.GetString(sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password)));
            }
        }
    }
}