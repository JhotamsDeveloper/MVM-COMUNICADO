using CORE.Entities;
using CORE.Excepciones;
using CORE.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CORE.Services
{
    public class UserSystemService : IUserSystemService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserSystemService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<UserSystem> GetAll()
        {
            var _userSystem = _unitOfWork.UserSystemRepository.GetAll();
            return (_userSystem);
        }

        public async Task InsertUserSystem(UserSystem userSystem)
        {
            var user = await _unitOfWork.UserSystemRepository.GetById(userSystem.ID);
            if (user == null)
            {
                throw new BusinessException("User doesn't exist");
            }

            await _unitOfWork.UserSystemRepository.Add(user);
            await _unitOfWork.saveChangesAsync();
        }

        public Task<bool> DeleteUserSystem(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<UserSystem> GetUserSystem(int id)
        {
            throw new System.NotImplementedException();
        }


        public Task<bool> UpdateUserSystem(UserSystem userSystem)
        {
            throw new System.NotImplementedException();
        }
    }
}
