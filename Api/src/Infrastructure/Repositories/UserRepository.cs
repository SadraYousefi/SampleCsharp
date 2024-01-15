using Api.core.Entities;
using Api.core.Interfaces;
using Api.Infrastructure.Data;

namespace Api.Infrastructure.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly DataContextEf _dataContext;

        public UserRepository(DataContextEf dataContext)
        {
            _dataContext = dataContext;
        }

        public User Create(User user)
        {
            _dataContext.Users.Add(user);
            _dataContext.SaveChanges();
            return user;
        }

        public User Get(int id)
        {
            User user =  _dataContext.Users.Find(id);
            if (user != null)
            {
                return user;
            }

            throw new Exception("There is no user by this id");
        }

        public IEnumerable<User> GetAll()
        {
            return _dataContext.Users.ToList();
        }

        public void Delete(User user)
        {
            User record = _dataContext.Users.Find(user.UserId);
            if (record != null)
            {
                _dataContext.Users.Remove(record);
                _dataContext.SaveChanges();
            }
        }

        public User Update(User user)
        {
            _dataContext.Users.Update(user);
            _dataContext.SaveChanges();
            return user;
        }

        public User FindOne(string username)
        {
            User user = _dataContext.Users.Find(username);
            if (user != null)
            {
                return user; 
            }

            throw new Exception("User not found ");
        }
    }
    
}

