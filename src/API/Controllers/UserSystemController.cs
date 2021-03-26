using API.Responses;
using AutoMapper;
using CORE.DTOs;
using CORE.Entities;
using CORE.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserSystemController : ControllerBase
    {
        private readonly IUserSystemService _userSystemService;
        private readonly IMapper _mapper;

        public UserSystemController(IUserSystemService userSystemService,
            IMapper mapper)
        {
            _userSystemService = userSystemService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> InsertUserSystem(UserSystemDto userSystem )
        {
            var _userSystem = _mapper.Map<UserSystem>(userSystem);
            var _userSystemDto = _mapper.Map<UserSystemDto>(_userSystem);
            ApiResponse<UserSystemDto> response = new ApiResponse<UserSystemDto>(_userSystemDto);

            if (!_userSystemService.ValidadUserSystemByEmail(userSystem.Email))
            {
                await _userSystemService.InsertUserSystem(_userSystem);
                var responseApi = new ApiResponse<UserSystemDto>(_userSystemDto)
                {
                    msg = "Usuario guardado exitosamente"
                };

                response = responseApi;
            }
            else
            {
                var responseApi = new ApiResponse<UserSystemDto>(_userSystemDto)
                {
                    msg = "El Email ingresado ya existe"
                };
                response = responseApi;
            }

            return Ok(response);
        }

    }
}
