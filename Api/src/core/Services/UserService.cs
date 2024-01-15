using Api.core.Entities;
using Api.core.Interfaces ;
namespace Api.core.Services
{
    public class UserService 
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public User Get(int id)
        {
            return _repository.Get(id);
        }

        public IEnumerable<User> GetAll()
        {
            return _repository.GetAll();
        }

        public User Create(User user)
        {
            _repository.Create(user);
            return user;
        }

        public User Update(User user)
        {
            _repository.Update(user);
            return user;
        }

        public User Delete(User user)
        {
            _repository.Delete(user);
            return user;
        }

        public User FindOne(string username)
        {
            return _repository.FindOne(username);
        }
    }
}