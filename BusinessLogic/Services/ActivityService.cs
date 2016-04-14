using AutoMapper;
using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using Contracts.Interfaces;
using Contracts.Models;

namespace BusinessLogic.Services
{
    internal class ActivityService : IActivityService
    {
        private readonly IActivityRepository _activityRepository;
        private readonly IMapper _mapper;


        public ActivityService(IActivityRepository activityRepository, IMapper mapper)
        {
            _activityRepository = activityRepository;
            _mapper = mapper;
        }


        // FUNCTIONS //////////////////////////////////////////////////////////////////////////////
        public void ChangePlayerActivity(ActivityDto activity)
        {
            _activityRepository.AddOrUpdate(_mapper.Map<Activity>(activity));
        }
    }
}