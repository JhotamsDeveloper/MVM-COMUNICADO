using CORE.DTOs;
using CORE.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE.Interfaces
{
    public interface IUserSystemService
    {
        IEnumerable<UserSystem> GetAll();
        Task<UserSystem> GetUserSystem(int id);

        Task InsertUserSystem(UserSystem userSystem);
        bool ValidadUserSystemByEmail(string email);
        Task<bool> UpdateUserSystem(UserSystem userSystem);

        Task<bool> DeleteUserSystem(int id);
        Task<LoginDto> Login(string email, string password);

    }
}
