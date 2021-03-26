using API.Responses;
using AutoMapper;
using CORE.DTOs;
using CORE.Entities;
using CORE.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    //[Authorize]
    [ApiController]
    public class CompanyStatementController : ControllerBase
    {
        private readonly ICompanyStatementService _companyStatementService;
        private readonly IMapper _mapper;

        public CompanyStatementController(ICompanyStatementService companyStatementService,
            IMapper mapper)
        {
            _companyStatementService = companyStatementService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult CompanyStatementGetAll()
        {
            var _getAll = _companyStatementService.GetAll();
            var _companyStatementDto = _mapper.Map<IEnumerable<CompanyStatementDto>>(_getAll);

            var responseApi = new ApiResponse<IEnumerable<CompanyStatementDto>>(_companyStatementDto)
            {
                msg = "Resultados"
            };
            return Ok(responseApi);
        }

        [HttpPost]
        [Route("api/[controller]")]
        public async Task<IActionResult> InsertCompanyStatement(CompanyStatementDto companyStatementDto)
        {
            var _companyStatement = _mapper.Map<CompanyStatement>(companyStatementDto);
            var _companyStatementDto = _mapper.Map<CompanyStatementDto>(_companyStatement);
            await _companyStatementService.InsertCompanyStatement(_companyStatement);

            var _response = new ApiResponse<CompanyStatementDto>(companyStatementDto)
            {
                msg = "Usuario guardado exitosamente"
            };

            return Ok(_response);
        }

        [HttpGet("{id}")]
        [Route("api/[controller]")]
        public async Task<IActionResult> GetCompanyStatement(int id)
        {
            var _companyStatement = await _companyStatementService.GetCompanyStatement(id);
            var _companyStatementDto = _mapper.Map<CompanyStatementDto>(_companyStatement);
            return Ok(_companyStatementDto);
        }

        [HttpDelete("{id}")]
        [Route("api/[controller]")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _companyStatementService.DeleteCompanyStatement(id);
            return Ok(result);
        }

    }
}
