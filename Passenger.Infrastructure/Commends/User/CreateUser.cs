
namespace Passenger.Infrastructure.Commends.User
{
    public class CreateUser : ICommand
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
    }
}
