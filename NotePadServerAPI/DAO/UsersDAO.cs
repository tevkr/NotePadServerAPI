using NotePadServerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotePadServerAPI.DAO
{
    public interface IUsersDAO
    {
        List<User> getUsers();
        void addUser(User user);
        void delUser(int id);
    }
    public class UsersDAO : IUsersDAO
    {
        private static uint USERS_COUNT;
        private List<User> users;
        public UsersDAO()
        {
            //Пока используем лист, как все будет работать перейдем на бд
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
