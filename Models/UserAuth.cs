using System.IO;

namespace Parking_App.Models
{
    public class UserAuth: IUserRepo
    {
        private ParkingAppContext db;

        public UserAuth()
        {
            db = new ParkingAppContext();
        }

        public User? CreateUser(string username, string email, string passwd)
        {
            int count = db.Users.Where(user => user.Email == email).Count();

            if (count == 0)
            {
                User newUser = new User
                {
                    Username = username,
                    Email = email,
                    Password = passwd,
                };

                db.Users.Add(newUser);
                db.SaveChanges();

                return newUser;
            }
            else
            {
                return null;
            }
        }

        public User? Login(string email, string passwd)
        {
            List<User> users = db.Users.Where(u => (u.Email == email && u.Password == passwd)).ToList();
            if (users.Any())
            {
                return users[0];
            }
            else
            {
                return null;
            }
        }

        public void SaveProfileData(long id,string name, string email, string profileName) {
            User user = db.Users.Where<User>(user => user.Id == id).ToList()[0];
            user.Username = name;
            user.Email = email;
            if (profileName != null) {
                user.ProfileName = profileName;
            }
            db.SaveChanges();
        }

        public User GetUser(long id) {
            User user = db.Users.First(user => user.Id == id);
            return user;
        }
    }
}