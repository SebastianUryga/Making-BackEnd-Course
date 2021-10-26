using System;

namespace Passenger.Core.Domain
{
    public class User
    {
        public Guid Id { get; protected set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string FullName { get; set; }
        public string Username { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }
        protected User()
        {

        }
        public User(string email, string username, string password, string salt)
        {
            Id = Guid.NewGuid();
            SetEmail(email);
            SetUsername(username);
            SetPassword(password);
            Salt = salt;
            CreatedAt = DateTime.UtcNow;
        }
        public void SetUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new Exception("Username can not be empty.");
            }
            if (username == Username) return;
            Username = username;
            UpdatedAt = DateTime.UtcNow;
        }
        public void SetEmail(string email)
        {
            if(string.IsNullOrWhiteSpace(email))
            {
                throw new Exception("Email can not be empty.");
            }
            if (email == Email) return;
            Email = email.ToLowerInvariant();
            UpdatedAt = DateTime.UtcNow;
        }
        public void SetPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new Exception("Password can not be empty");
            }
            if (password.Length < 4)
            {
                throw new Exception("Password must contain at least 4 characters.");
            }
            if (password.Length > 100)
            {
                throw new Exception("Password can not contain more then 100 characters.");
            }
            if (password == Password) return;
            Password = password;

        }

    }
}
