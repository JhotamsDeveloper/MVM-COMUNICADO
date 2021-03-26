using API.Responses;
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
    public class ConsultController : Controller
    {
        private readonly ICompanyStatementService _companyStatementService;
        private readonly IUserSystemService _userSystemService;
        private readonly IMapper _mapper;

        public ConsultController(ICompanyStatementService companyStatementService,
            IUserSystemService userSystemService,
            IMapper mapper)
        {
            _companyStatementService = companyStatementService;
            _userSystemService = userSystemService;
            _mapper = mapper;
        }

        [HttpGet()]
        [Route("api/GetCompanyStatementByRemitent/{id}")]
        public async Task<IActionResult> GetCompanyStatementByRemitent(int id)
        {
            var _getAllByRemitent = await _companyStatementService.GetAllByRemitent(id);
            var _companyStatementDto = _mapper.Map<IEnumerable<CompanyStatementDto>>(_getAllByRemitent);
            var responseApi = new ApiResponse<IEnumerable<CompanyStatementDto>>(_companyStatementDto)
            {
                msg = "Resultados"
            };
            return Ok(responseApi);
        }

        [HttpGet()]
        [Route("api/GetCompanyStatementByDestinatary/{id}")]
        public async Task<IActionResult> GetCompanyStatementByDestinatary(int id)
        {
            var _getAllByDestinatary = await _companyStatementService.GetAllByDestinatary(id);
            var _companyStatementDto = _mapper.Map<IEnumerable<CompanyStatementDto>>(_getAllByDestinatary);
            var responseApi = new ApiResponse<IEnumerable<CompanyStatementDto>>(_companyStatementDto)
            {
                msg = "Resultados"
            };
            return Ok(responseApi);
        }

        [HttpGet()]
        [Route("api/GetCompanyStatementByDocumento/{document}")]
        public async Task<IActionResult> GetCompanyStatementByDocumento(string document)
        {
            var _getAllUser = _userSystemService.GetAll().Where(x => x.Document == document).FirstOrDefault();
            var _getAllByDocument = _companyStatementService.GetAll().Where(x => x.Remitent == _getAllUser.Id || x.Destinatary == _getAllUser.Id);
            var _companyStatementDto = _mapper.Map<IEnumerable<CompanyStatementDto>>(_getAllByDocument);
            var responseApi = new ApiResponse<IEnumerable<CompanyStatementDto>>(_companyStatementDto)
            {
                msg = "Resultados"
            };
            return Ok(responseApi);
        }
    }
}
