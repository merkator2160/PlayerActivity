using Contracts.Models;

namespace Contracts.Interfaces
{
    public interface IActivityRepository
    {
        void AddOrUpdate(Activity playerActivity);
    }
}