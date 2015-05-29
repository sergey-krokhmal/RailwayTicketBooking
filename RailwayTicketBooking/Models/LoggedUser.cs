
namespace RailwayTicketBooking.Models
{
    public class LoggedUser
    {
        private int id;
        private string login;
        private string surname;
        private string name;

        public int Id { get { return id; } }
        public string Login { get { return login; } }
        public string Surname { get { return surname; } }
        public string Name { get { return name; } }

        public LoggedUser()
        {
            id = 0;
            login = "";
            surname = "";
            name = "";
        }

        public LoggedUser(int id, string login, string surname, string name)
        {
            this.id = id;
            this.login = login;
            this.name = name;
            this.surname = surname;
        }
    }
}