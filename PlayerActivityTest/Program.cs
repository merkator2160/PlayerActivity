using PlayerActivity.BusinessLogic.Enums;
using PlayerActivity.BusinessLogic.Infrastructure;
using PlayerActivity.BusinessLogic.Interfaces;
using PlayerActivity.BusinessLogic.Models;
using System;
using System.Collections.Generic;

namespace PlayerActivity.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var players = GetPlayers();
            using (var services = new ServiceLocator())
            {
                try
                {
                    AddPlayerActivity(services.ActivityService, players);
                    ChangePlayerActivity(services.ActivityService, players);
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                    System.Console.ReadKey();
                }
            }
        }
        private static IDictionary<String, PlayerDto> GetPlayers()
        {
            return new Dictionary<String, PlayerDto>()
            {
                {
                    "Deadpool", new PlayerDto()
                    {
                        Id = 1,
                        Name = "Deadpool"
                    }
                },
                {
                    "Thanos", new PlayerDto()
                    {
                        Id = 2,
                        Name = "Thanos"
                    }
                },
                {
                    "Ultron", new PlayerDto()
                    {
                        Id = 3,
                        Name = "Ultron"
                    }
                }
            };
        }
        private static void AddPlayerActivity(IActivityService activityService, IDictionary<String, PlayerDto> playerDictionary)
        {
            var player = playerDictionary["Deadpool"];
            activityService.ChangePlayerActivity(new ActivityDto()
            {
                Name = $"{player.Name}Activity",
                PlayerId = player.Id,
                Type = ActivityType.Login
            });
            player = playerDictionary["Thanos"];
            activityService.ChangePlayerActivity(new ActivityDto()
            {
                Name = $"{player.Name}Activity",
                PlayerId = player.Id,
                Type = ActivityType.Login
            });
            player = playerDictionary["Ultron"];
            activityService.ChangePlayerActivity(new ActivityDto()
            {
                Name = $"{player.Name}Activity",
                PlayerId = player.Id,
                Type = ActivityType.Login
            });
        }
        private static void ChangePlayerActivity(IActivityService activityService, IDictionary<String, PlayerDto> playerDictionary)
        {
            var player = playerDictionary["Deadpool"];
            activityService.ChangePlayerActivity(new ActivityDto()
            {
                Name = $"{player.Name}Activity",
                PlayerId = player.Id,
                Type = ActivityType.Playing
            });
            player = playerDictionary["Thanos"];
            activityService.ChangePlayerActivity(new ActivityDto()
            {
                Name = $"{player.Name}Activity",
                PlayerId = player.Id,
                Type = ActivityType.Playing
            });
            player = playerDictionary["Ultron"];
            activityService.ChangePlayerActivity(new ActivityDto()
            {
                Name = $"{player.Name}Activity",
                PlayerId = player.Id,
                Type = ActivityType.Logout
            });
        }
    }
}
