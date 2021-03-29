using AutoMapper;
using CORE.DTOs;
using CORE.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly ICompanyStatementService _companyStatementService;
        private readonly IUserSystemService _userSystemService;
        private readonly IMapper _mapper;

        public SecurityController(ICompanyStatementService companyStatementService,
            IUserSystemService userSystemService,
            IMapper mapper)
        {
            _companyStatementService = companyStatementService;
            _userSystemService = userSystemService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> GetUserSystem(LoginDto loginDto)
        {
            var _data = await _userSystemService.Login(loginDto.Email, loginDto.Password);
            return Ok(_data);
        }
    }
}
