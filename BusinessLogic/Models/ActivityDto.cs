using Contracts;
using System;

namespace BusinessLogic.Models
{
    public class ActivityDto
    {
        public Int32 PlayerId { get; set; }
        public String Name { get; set; }
        public ActivityType Type { get; set; }
    }
}