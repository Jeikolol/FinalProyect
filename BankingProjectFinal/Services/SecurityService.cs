using BankingProject.Data;
using BankingProject.Entities;
using BankingProject.Infrastructure;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BankingProjectFinal.Pages.Security;
using BankingProjectFinal.Models;

namespace BankingProject.Services
{
    public class SecurityService : Service, ISecurityService
    {
        public SecurityService(ApplicationDbContext _Database) : base(_Database)
        {
        }

        public async Task<User> CreateUserAsync(RegisterViewModel parameter)
        {
            var userToCreate = new User
            {
                Correo = parameter.Email,
                Password = parameter.Password,
                Nombre = parameter.Nombre,
                Apellido = parameter.Apellido,
                Cedula = parameter.Cedula,
                Direccion = parameter.Direccion,
                Telefono = parameter.Telefono,
                Celular = parameter.Celular,
                FechaCreacion = DateTime.UtcNow,
                Activo = true
            };

            Database.Add(userToCreate);
            await Database.SaveChangesAsync();

            return userToCreate;
        }

        public async Task<User> Login(string email)
        {
            var user = await Database.Users
                .Where(x => x.Correo == email)
                .FirstOrDefaultAsync();

            return user;
        }

        public async Task IncrementarIntentosYChequearIntentosMaximos(User user, string passsword, int intentoMaximo)
        {
            var usuarioParaActualizar = await Database.Users
                .Where(x => x.Id == user.Id)
                .FirstOrDefaultAsync();

            usuarioParaActualizar.Intentos++;

            if (usuarioParaActualizar.Intentos > intentoMaximo)
            {
                usuarioParaActualizar.Activo = false;
            }

            Database.Update(usuarioParaActualizar);

            await Database.SaveChangesAsync();
        }

        public async Task ResetearIntentosDeUsuario(User user)
        {
            if (user.Intentos > 0)
            {
                var usuarioParaActualizar = await Database.Users
                    .Where(x => x.Id == user.Id)
                    .FirstOrDefaultAsync();

                user.Intentos = 0;
                usuarioParaActualizar.Intentos = 0;

                Database.Update(usuarioParaActualizar);
                await Database.SaveChangesAsync();
            }
        }
    }

    public interface ISecurityService : IService
    {
        Task<User> CreateUserAsync(RegisterViewModel parameter);
        Task<User> Login(string userName);
        Task IncrementarIntentosYChequearIntentosMaximos(User user, string passsword, int intentoMaximo);
        Task ResetearIntentosDeUsuario(User user);
    }
}
