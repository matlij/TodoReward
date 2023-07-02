using TodoReward.BusinessLayer.Models;

namespace TodoReward.BusinessLayer.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetAsync();
        Task<bool> UpdateAsync(User user);
    }
}
