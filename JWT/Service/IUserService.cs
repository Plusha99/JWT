using JWT.Models;

namespace JWT.Service
{
    public interface IUserService
    {
        public User Get(UserLogin userLogin);
    }
}
