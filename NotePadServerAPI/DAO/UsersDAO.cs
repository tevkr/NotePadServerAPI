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
        private static uint USERS_COUNT;
        private List<User> users;
        public UsersDAO()
        {
            //In the near future there will be a DB
            users = new List<User>();
            users.Add(new User(USERS_COUNT++, "Vlad"));
            users.Add(new User(USERS_COUNT++, "Petya"));
            users.Add(new User(USERS_COUNT++, "Vasya"));
        }
        public List<User> getUsers()
        {
            return users;
        }
        public void addUser(User user)
        {
            user.id = USERS_COUNT++;
            users.Add(user);
        }
        public void delUser(int id)
        {
            users.RemoveAll(u => u.id == id);
        }
    }
}
