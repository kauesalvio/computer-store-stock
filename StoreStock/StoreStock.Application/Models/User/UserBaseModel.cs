namespace StoreStock.Application.Models.User
{
    public abstract class UserBaseModel
    {
        public string Email { get; private set; }
        public string Password { get; private set; }
    }
}
