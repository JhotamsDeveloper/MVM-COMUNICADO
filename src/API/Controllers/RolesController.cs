using AutoMapper;
using CORE.Entities;
using CORE.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public RolesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return Ok(_unitOfWork.RolesRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var roles = await _unitOfWork.RolesRepository.GetById(id);
            if (roles == null)
            {
                return NotFound();
            }

            return Ok(roles);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Roles roles)
        {
            await _unitOfWork.RolesRepository.Add(roles);
            await _unitOfWork.saveChangesAsync();
            return Ok(true);
        }



        [HttpPut]
        public async Task<IActionResult> Edit(Roles roles)
        {
            _unitOfWork.RolesRepository.Update(roles);
            await _unitOfWork.saveChangesAsync();
            return Ok(true);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _unitOfWork.RolesRepository.Delete(id);
            await _unitOfWork.saveChangesAsync();
            return Ok(true);
        }

    }
}
