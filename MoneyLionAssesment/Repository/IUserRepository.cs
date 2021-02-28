using MoneyLionAssesment.Models;

namespace MoneyLionAssesment.Repository
{
    public interface IUserRepository
    {
        bool SaveChanges();

        void CreateUser(User user);
    }
}
