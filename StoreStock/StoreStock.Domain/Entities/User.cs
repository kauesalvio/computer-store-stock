namespace StoreStock.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Email { get; private set; }
        public string Password { get; private set; }

        public User() { }

        public User(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
