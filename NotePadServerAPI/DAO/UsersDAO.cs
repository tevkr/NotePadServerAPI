using NotePadServerAPI.Data;
using NotePadServerAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace NotePadServerAPI.DAO
{
    public interface IUsersDAO
    {
        //Returns all users
        List<User> getUsers();
        //Adds a user to the database
        void addUser(User user);
        //Deletes a user from the database
        User delUser(int id);
    }
    public class UsersDAO : IUsersDAO
    {
        private readonly NotePadServerAPIDBContext _dbContext;
        public UsersDAO(NotePadServerAPIDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<User> getUsers()
        {
            return _dbContext.users.ToList();
        }
        public void addUser(User user)
        {
            _dbContext.users.Add(user);
            _dbContext.SaveChanges();
        }
        public User delUser(int id)
        {
            var userToDelete = _dbContext.users.Find(id);
            _dbContext.users.Remove(userToDelete);
            _dbContext.SaveChanges();
            return userToDelete;
        }
    }
}
