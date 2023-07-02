using TodoReward.BusinessLayer.Interfaces;
using TodoReward.BusinessLayer.Models;

namespace TodoReward.BusinessLayer.Repositories
{
    public class UserRepository : IUserRepository
    {
        private User _user = new();

        public Task<User> GetAsync()
        {
            return Task.FromResult(_user);
        }

        public Task<bool> UpdateAsync(User user)
        {
            _user = user;

            return Task.FromResult(true);
        }
    }
}
