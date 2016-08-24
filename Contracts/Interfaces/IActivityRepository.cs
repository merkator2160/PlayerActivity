using PlayerActivity.Contracts.Models;

namespace PlayerActivity.Contracts.Interfaces
{
    public interface IActivityRepository
    {
        void AddOrUpdate(Activity playerActivity);
    }
}