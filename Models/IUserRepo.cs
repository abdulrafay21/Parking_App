using System;
namespace Parking_App.Models
{
    public interface IUserRepo
    {
        public User? CreateUser(string username, string email, string passwd);
        public User? Login(string email, string passwd);
        public void SaveProfileData(long id, string name, string email, string profileName);
        public User GetUser(long id);
    }

}