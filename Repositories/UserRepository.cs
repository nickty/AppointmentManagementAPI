using System.Linq;

namespace AppointmentManagementAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _users = new();

        public void AddUser(string username, string password)
        {
            _users.Add(new User { Username = username, Password = password });
        }

        public User GetUserByUsername(string username)
        {
            return _users.FirstOrDefault(u => u.Username == username);
        }
    }
}
