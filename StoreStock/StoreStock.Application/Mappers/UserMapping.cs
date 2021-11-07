using StoreStock.Application.Models.User;
using StoreStock.Domain.Entities;

namespace StoreStock.Application
{
    public class UserMapping
    {
        public static User MapUserRequestForUser(UserRequestModel request)
        {
            return new User(request.Name, request.Email, request.Password);
        }
    }
}
