using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CORE.Entities;
using CORE.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserSystemRolesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserSystemRolesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return Ok(_unitOfWork.UserSystemRolesRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var roles = await _unitOfWork.UserSystemRolesRepository.GetById(id);
            if (roles == null)
            {
                return NotFound();
            }

            return Ok(roles);
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserSystemRoles _userSystemRoles)
        {
            await _unitOfWork.UserSystemRolesRepository.Add(_userSystemRoles);
            await _unitOfWork.saveChangesAsync();
            return Ok(true);
        }



        [HttpPut]
        public async Task<IActionResult> Edit(UserSystemRoles _userSystemRoles)
        {
            _unitOfWork.UserSystemRolesRepository.Update(_userSystemRoles);
            await _unitOfWork.saveChangesAsync();
            return Ok(true);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _unitOfWork.UserSystemRolesRepository.Delete(id);
            await _unitOfWork.saveChangesAsync();
            return Ok(true);
        }
    }
}