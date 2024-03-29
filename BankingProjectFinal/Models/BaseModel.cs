﻿using BankingProject.core.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.IO;

namespace BankingProjectFinal.Models
{
    public class BaseModel : PageModel
    {
        protected void ShowNotification(string message, string title, NotificationType type)
        {
            var msg = new
            {
                message = message,
                title = title,
                icon = type.ToString(),
                type = type.ToString(),
                provider = GetProvider()
            };

            TempData["Message"] = JsonConvert.SerializeObject(msg);
        }

        private string GetProvider()
        {
            var builder = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                            .AddEnvironmentVariables();

            IConfigurationRoot configuration = builder.Build();

            var value = configuration["NotificationProvider"];

            return value;
        }
    }
}
