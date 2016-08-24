using System;

namespace PlayerActivity.Contracts.Models
{
    public class Activity
    {
        public Int32 PlayerId { get; set; }
        public String Name { get; set; }
        public Int32 Type { get; set; }
    }
}