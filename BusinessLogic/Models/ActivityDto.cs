using PlayerActivity.BusinessLogic.Enums;
using System;

namespace PlayerActivity.BusinessLogic.Models
{
    public class ActivityDto
    {
        public Int32 PlayerId { get; set; }
        public String Name { get; set; }
        public ActivityType Type { get; set; }
    }
}