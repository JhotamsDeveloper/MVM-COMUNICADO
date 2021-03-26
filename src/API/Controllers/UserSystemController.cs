using API.Responses;
using AutoMapper;
using CORE.DTOs;
using CORE.Entities;
using CORE.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
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

        [HttpGet]
        public IActionResult UserSystemGetAll()
        {
            var _getAll = _userSystemService.GetAll();
            var _userSystemDto = _mapper.Map<IEnumerable<UserSystemDto>>(_getAll);
            
            var responseApi = new ApiResponse<IEnumerable<UserSystemDto>>(_userSystemDto)
            {
                msg = "Resultados"
            };
            return Ok(responseApi);
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserSystem(int id)
        {
            var _getUserSystem = await _userSystemService.GetUserSystem(id);
            var _userSystemDto = _mapper.Map<UserSystemDto>(_getUserSystem);
            return Ok(_userSystemDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UserSystemDto userSystemDto)
        {
            var _userSystemDto = _mapper.Map<UserSystem>(userSystemDto);
            userSystemDto.Id = id;
            var result = await _userSystemService.UpdateUserSystem(_userSystemDto);
            ApiResponse<UserSystemDto> response = new ApiResponse<UserSystemDto>(userSystemDto);
            if (result)
            {

                var responseApi = new ApiResponse<UserSystemDto>(userSystemDto)
                {
                    msg = "Se actualizo correctamente"
                };
                response = responseApi;
            }

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _userSystemService.DeleteUserSystem(id);

            return Ok(result);
        }
    }
}
