using CORE.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE.Interfaces
{
    public interface IUserSystemService
    {
        Task<UserSystem> GetUserSystem(int id);

        Task InsertUserSystem(UserSystem userSystem);

        Task<bool> UpdateUserSystem(UserSystem userSystem);

        Task<bool> DeleteUserSystem(int id);
    }
}
