using System;
using BookServer.Models;

namespace BookServer.DAO
{
    public interface IUserDAO
    {
        User GetUser(string username);
        User AddUser(string username, string password);
    }
}

