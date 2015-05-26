
namespace RailwayTicketBooking.Models
{
    public class LoggedUser
    {
        private int id;
        private string login;
        private string password;

        public int Id { get { return id; } }
        public string Login { get { return login; } }
        public string Password { get { return password; } }

        public LoggedUser()
        {
            id = 0;
            login = "";
            password = "";
        }

        public LoggedUser(int id, string login, string password)
        {
            this.id = id;
            this.login = login;
            this.password = password;
        }
    }
}