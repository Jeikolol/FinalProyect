﻿using BankingProject.Data;
using BankingProject.Entities;
using BankingProject.Infrastructure;
using BankingProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BankingProject.Services
{
    public class SecurityService : Service, ISecurityService
    {
        public SecurityService(ApplicationDbContext _Database) : base(_Database)
        {
        }

        public async Task<User> CreateUserAsync(RegisterModel parameter)
        {
            var userToCreate = new User
            {
                Correo = parameter.UserName,
                Password = parameter.Password
            };

            Database.Add(userToCreate);
            await Database.SaveChangesAsync();

            return userToCreate;
        }

        public async Task<User> Login(string userName, string password)
        {
            var user = await Database.Users
                .Where(x => x.Correo == userName &&
                            x.Password == password)
                .FirstOrDefaultAsync();

            return user;
        }
    }

    public interface ISecurityService : IService
    {
        Task<User> CreateUserAsync(RegisterModel parameter);
        Task<User> Login(string userName, string password);
    }
}
