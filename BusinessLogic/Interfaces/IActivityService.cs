using PlayerActivity.BusinessLogic.Models;

namespace PlayerActivity.BusinessLogic.Interfaces
{
    public interface IActivityService
    {
        void ChangePlayerActivity(ActivityDto activity);
    }
}