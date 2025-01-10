namespace AppointmentManagementAPI.Repositories
{
    public interface IUserRepository
    {
        void AddUser(string username, string password);
        User GetUserByUsername(string username);
    }

    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
