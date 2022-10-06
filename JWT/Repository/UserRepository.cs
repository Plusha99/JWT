using JWT.Models;

namespace JWT.Repository
{
    public class UserRepository
    {
        public static List<User> Users = new()
        {
            new() { Username = "ilia_admin", EmailAddress = "ilia.admin@email.com", Password = "MyPass_w0rd", GivenName = "Ilia", Surname = "Martinov", Role = "Administrator" },
            new() { Username = "anna_standard", EmailAddress = "anna.standard@email.com", Password = "MyPass_w0rd", GivenName = "Anna", Surname = "Eskina", Role = "Standard" },
        };
    }
}
