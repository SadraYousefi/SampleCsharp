using Api.core.Entities;

namespace Api.core.Interfaces
{

    public interface IUserRepository
    {
        User Get(int id);

        IEnumerable<User> GetAll();

        User Create(User user);

        User Update(User user);

        void Delete(User user);

        User FindOne(string username);
    }
}

