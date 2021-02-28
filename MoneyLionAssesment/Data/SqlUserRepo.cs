using Microsoft.AspNetCore.Http;
using MoneyLionAssesment.Models;
using MoneyLionAssesment.Repository;
using System.Linq;

namespace MoneyLionAssesment.Data
{
    public class SqlUserRepo : IUserRepository
    {
        private readonly DatabaseContext dbContext;

        public SqlUserRepo(DatabaseContext databaseContext)
        {
            dbContext = databaseContext;
        }

        public void CreateUser(User user)
        {
            if (dbContext.Users.Any(u => u.Email == user.Email))
            {
                throw new BadHttpRequestException("User already exists");
            }

            dbContext.Users.Add(user);
        }

        public bool SaveChanges()
        {
            return dbContext.SaveChanges() > 0;
        }
    }
}
