using BusinessLogic.Models;

namespace BusinessLogic.Interfaces
{
    public interface IActivityService
    {
        void ChangePlayerActivity(ActivityDto activity);
    }
}