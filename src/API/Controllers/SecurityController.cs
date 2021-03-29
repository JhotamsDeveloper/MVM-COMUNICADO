using CORE.DTOs;
using CORE.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly IUserSystemService _userSystemService;

        public SecurityController(IUserSystemService userSystemService)
        {
            _userSystemService = userSystemService;
        }

        [HttpPost]
        public async Task<IActionResult> GetUserSystem(LoginDto loginDto)
        {
            var _data = await _userSystemService.Login(loginDto.Email, loginDto.Password);

            List<int> _rolesAuthorize = new List<int>();

            foreach (var item in _data.PermissionsRoles)
            {
                _rolesAuthorize.Add(item.IdRoles);
            }
            GlobalApp.RolesAuthirize = _rolesAuthorize;
            return Ok(_data);
        }
    }
}
