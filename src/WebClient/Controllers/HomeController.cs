using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebClient.Models;
using WebClient.Services;

namespace WebClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger,
            IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index() {

            return View();
        }

        public IActionResult Radicar()
        {
            UserSystemCompanyStatementModel userSystemCompanyStatementModel = new UserSystemCompanyStatementModel();
            var ConsultUserRemitent = GlobalApp.GetUserSystemResponseR(_httpContextAccessor.HttpContext.Session);
            userSystemCompanyStatementModel.UserSystemRemitent = ConsultUserRemitent;
            var ConsultUserDestinate = GlobalApp.GetUserSystemResponseD(_httpContextAccessor.HttpContext.Session);
            userSystemCompanyStatementModel.UserSystemDestinate= ConsultUserDestinate;

            CompanyStatementModel companyStatementModel = new CompanyStatementModel();
            userSystemCompanyStatementModel.CompanyStatement = companyStatementModel;
            return View(userSystemCompanyStatementModel);
        }

        [HttpGet]
        public IActionResult User()
        {
            ViewBag.GetDocument = GlobalApp.GetDocument(_httpContextAccessor.HttpContext.Session);
            ViewBag.GetTypeUser = GlobalApp.GetTypeUser(_httpContextAccessor.HttpContext.Session);
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> User(UserSystemModel userSystemModel)
        {
            if (ModelState.IsValid)
            {
                APIConsumption _aPIConsumption = new APIConsumption(_configuration);
                var _user = await _aPIConsumption.ConsultUser(userSystemModel.Document);

                //Usuario ya registrado
                if (_user.data != null)
                {
                    UserSystemModel _userSystemModel = new UserSystemModel();
                    _userSystemModel.Id = _user.data.Id;
                    _userSystemModel.NameUser = _user.data.NameUser;
                    _userSystemModel.TypeDocument = _user.data.TypeDocument;
                    _userSystemModel.Document = _user.data.Document;
                    _userSystemModel.Phone = _user.data.Phone;
                    _userSystemModel.Email = _user.data.Email;
                    _userSystemModel.AddressUser = _user.data.AddressUser;

                    if (userSystemModel.TypeUser == "Remitente")
                    {
                        GlobalApp.SetUserSystemResponseR(_httpContextAccessor.HttpContext.Session, _userSystemModel);
                    }else if(userSystemModel.TypeUser == "Destinatario")
                    {
                        //Se puede implementar el rol de destinatario
                        UserSystemRolesModel _userSystemRolesModel = new UserSystemRolesModel();
                        _userSystemRolesModel.Roles = 1;
                        _userSystemRolesModel.UserSystem = _userSystemModel.Id;

                        await _aPIConsumption.PostUserRrolesSystemAsync(_userSystemRolesModel);

                        GlobalApp.SetUserSystemResponseD(_httpContextAccessor.HttpContext.Session, _userSystemModel);
                    }
                    return RedirectToAction("Radicar");
                }
                else if(userSystemModel.Email == null)
                {
                    GlobalApp.SetTypeUser(_httpContextAccessor.HttpContext.Session, userSystemModel.TypeUser);
                    GlobalApp.SetDocument(_httpContextAccessor.HttpContext.Session, userSystemModel.Document);
                    return RedirectToAction("User");
                }

                //Registrando Usuario
                if (await _aPIConsumption.PostUserSystemAsync(userSystemModel))
                {
                    var _user1 = await _aPIConsumption.ConsultUser(userSystemModel.Document);
                    if (_user1.data != null)
                    {
                        UserSystemModel _userSystemModel = new UserSystemModel();
                        _userSystemModel.Id = _user1.data.Id;
                        _userSystemModel.NameUser = _user1.data.NameUser;
                        _userSystemModel.TypeDocument = _user1.data.TypeDocument;
                        _userSystemModel.Document = _user1.data.Document;
                        _userSystemModel.Phone = _user1.data.Phone;
                        _userSystemModel.Email = _user1.data.Email;
                        _userSystemModel.AddressUser = _user1.data.AddressUser;

                        if (userSystemModel.TypeUser == "Remitente")
                        {
                            GlobalApp.SetUserSystemResponseR(_httpContextAccessor.HttpContext.Session, _userSystemModel);
                        }
                        else if (userSystemModel.TypeUser == "Destinatario")
                        {
                            GlobalApp.SetUserSystemResponseD(_httpContextAccessor.HttpContext.Session, _userSystemModel);
                        }
                    }


                }
            }

            return RedirectToAction("Radicar");
        }


        [HttpPost]
        public async Task<IActionResult> CompanyStatement(CompanyStatementModel companyStatementModel)
        {
            var ConsultUserRemitent = GlobalApp.GetUserSystemResponseR(_httpContextAccessor.HttpContext.Session);
            var ConsultUserDestinate = GlobalApp.GetUserSystemResponseD(_httpContextAccessor.HttpContext.Session);

            CompanyStatementModel _companyStatementModel = new CompanyStatementModel();
            _companyStatementModel.NameFile = companyStatementModel.NameFile;
            _companyStatementModel.Remitent = ConsultUserRemitent.Id;
            _companyStatementModel.Destinatary = ConsultUserDestinate.Id;
            _companyStatementModel.IsItInternally = companyStatementModel.IsItInternally;

            APIConsumption _aPIConsumption = new APIConsumption(_configuration);
            if (await _aPIConsumption.PostCompanyStatement(_companyStatementModel)) {

                var _companyStatementConvertJsonResponse =
                    await _aPIConsumption.ConsultCompanyStatement();

                List<CompanyStatementModel> _companyStatementConvert = new List<CompanyStatementModel>();

                foreach (var item in _companyStatementConvertJsonResponse.data)
                {
                    CompanyStatementModel _model = new CompanyStatementModel();
                    _model.Id = item.Id;
                    _model.NameFile = item.NameFile;
                    _model.Remitent = item.Remitent;
                    _model.Destinatary = item.Destinatary;
                    _model.IsItInternally = item.IsItInternally;
                    _model.FilingNumber = item.FilingNumber;
                    _companyStatementConvert.Add(_model);
                }

                ViewBag.listCompanyStatement = _companyStatementConvert;

                return View(_companyStatementConvert);

            };


            return RedirectToAction("Radicar");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
