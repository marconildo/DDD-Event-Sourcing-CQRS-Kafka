using MikeGrayCodes.BuildingBlocks.Application;

namespace MikeGrayCodes.Authentication.Application.Users
{
    public class CreateUserCommand : CommandBase
    {
        public CreateUserCommand(string login, string password, string email, string firstName, string lastName)
        {
            Login = login;
            Password = password;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
        }

        public string Login { get; }

        public string Password { get; }

        public string Email { get; }

        public string FirstName { get; }

        public string LastName { get; }
    }
}
