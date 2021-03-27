using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
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

        [TempData]
        public bool userExistRemitent { get; set; }

        public HomeController(ILogger<HomeController> logger,
            IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            var ConsultUserRemitent = GlobalApp.GetUserSystemResponse(_httpContextAccessor.HttpContext.Session);
            UserSystemCompanyStatementModel userSystemCompanyStatementModel = new UserSystemCompanyStatementModel();
            userSystemCompanyStatementModel.UserSystemRemitent = ConsultUserRemitent;
            return View(userSystemCompanyStatementModel);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult User()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> User(UserSystemModel userSystemModel)
        {
            if (ModelState.IsValid)
            {

                int _valueRole = 0;
                APIConsumption _aPIConsumption = new APIConsumption(_configuration);
                var _user = await _aPIConsumption.ConsultUser(userSystemModel.Document);

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

                    GlobalApp.SetUserSystemResponse(_httpContextAccessor.HttpContext.Session, _userSystemModel);
                    return RedirectToAction("Index");
                }
                else if(userSystemModel.Email == null)
                {

                    return RedirectToAction("User");

                }

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

                        GlobalApp.SetUserSystemResponse(_httpContextAccessor.HttpContext.Session, _userSystemModel);
                    }

                    //Agregar Roles
                    if (userSystemModel.UserExistRemitent.Contains("remitente"))
                    {
                        _valueRole = 3;
                    }

                    UserSystemRolesModel _userSystemRolesModel = new UserSystemRolesModel();
                    _userSystemRolesModel.Roles = _valueRole;
                    _userSystemRolesModel.UserSystem = _user1.data.Id;
                    await _aPIConsumption.PostUserRrolesSystemAsync(_userSystemRolesModel);

                }
            }

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
