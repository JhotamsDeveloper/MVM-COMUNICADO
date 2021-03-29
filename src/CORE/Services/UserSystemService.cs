using CORE.DTOs;
using CORE.Entities;
using CORE.Excepciones;
using CORE.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
            await _unitOfWork.UserSystemRepository.Add(userSystem);
            await _unitOfWork.saveChangesAsync();
        }

        public bool ValidadUserSystemByEmail(string email)
        {
            bool _result = false;
            var _data = _unitOfWork.UserSystemRepository.GetAll().Where(x => x.Email.Contains(email));
            if (_data.Any()){_result = true;}
            else { _result = false; }
            return _result;
        }

        public async Task<bool> DeleteUserSystem(int id)
        {
            await _unitOfWork.UserSystemRepository.Delete(id);
            await _unitOfWork.saveChangesAsync();
            return true;
        }

        public async Task<UserSystem> GetUserSystem(int id)
        {
            return await _unitOfWork.UserSystemRepository.GetById(id);
        }

        public async Task<bool> UpdateUserSystem(UserSystem userSystem)
        {
            var _existeUster = await _unitOfWork.UserSystemRepository.GetById(userSystem.Id);
            _existeUster.NameUser = userSystem.NameUser;
            _existeUster.TypeDocument = userSystem.TypeDocument;
            _existeUster.Document = userSystem.Document;
            _existeUster.Phone = userSystem.Phone;
            _existeUster.Email = userSystem.Email;
            _existeUster.AddressUser = userSystem.AddressUser;

            _unitOfWork.UserSystemRepository.Update(_existeUster);
            await _unitOfWork.saveChangesAsync();
            return true;
        }

        public async Task<LoginDto> Login(string email, string password)
        {
            LoginDto _loginDto = new LoginDto();

            var _data = _unitOfWork.UserSystemRepository.GetAll()
                .Where(x => x.Email.Contains(email) && x.Password.Contains(password)).FirstOrDefault();
            if (_data != null) {

                _loginDto.Email = _data.Email;
                var _getAllUR = _unitOfWork.UserSystemRolesRepository.GetAll();
                var _roles = _getAllUR.Where(x => x.UserSystem == _data.Id);

                if (_roles.Count() > 0)
                {
                    List<Permissions> permissionsList = new List<Permissions>();
                    foreach (var item in _roles)
                    {
                        Permissions permissions = new Permissions();
                        permissions.IdRoles = (int)item.Roles;
                        permissionsList.Add(permissions);
                    }
                    _loginDto.PermissionsRoles = permissionsList;
                }

            }

            return _loginDto;
        }
    }
}
