using Microsoft.AspNetCore.Identity;
using PracticeAPI.Entity;
using PracticeAPI.Model;

namespace PracticeAPI.Repository
{
    public interface IUserRepository
    {
        public Task<String> Login(UserEntity user);
        public Task<UserEntity> SignUp(UserEntity user);
        public Task<List<UserEntity>> GetUserEntities();
        public Task<bool> Delete(string id);
    }
}
