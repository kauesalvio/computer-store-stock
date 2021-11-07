namespace StoreStock.Application.Models.User
{
    public abstract class UserBaseModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
