using NotePadServerAPI.Data;
using NotePadServerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotePadServerAPI.DAO
{
    public interface IUsersDAO
    {
        //Returns all users
        List<User> getUsers();
        //Adds a user to the database
        void addUser(User user);
        //Deletes a user from the database
        void delUser(int id);
    }
    public class UsersDAO : IUsersDAO
    {
        private readonly NotePadServerAPIDBContext _dbContext;
        private static int getLastId(NotePadServerAPIDBContext context)
        {
            if (context.users.ToList().FirstOrDefault() == null)
                return 1;
            else
                return context.users.ToList().Last().id + 1;
        }
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
            user.id = getLastId(_dbContext);
            _dbContext.users.Add(user);
            _dbContext.SaveChanges();
        }
        public void delUser(int id)
        {
            _dbContext.users.Remove(_dbContext.users.Find(id));
            _dbContext.SaveChanges();
        }
    }
}
