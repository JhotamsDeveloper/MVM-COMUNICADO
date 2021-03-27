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
        
        public HomeController(ILogger<HomeController> logger,
            IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index(UserSystemCompanyStatementModel userSystemCompanyStatementModel )
        {
            var ConsultUserRemitent = GlobalApp.GetUserSystemResponse(_httpContextAccessor.HttpContext.Session);
            return View(userSystemCompanyStatementModel);
        }

        public async Task<IActionResult> ConsultUserRemitent(string document)
        {
            APIConsumption _aPIConsumption = new APIConsumption(_configuration);
            var _user = await _aPIConsumption.ConsultUser(document);

            UserSystemModel userSystemModel = new UserSystemModel();
            userSystemModel.Id = _user.data.Id;
            userSystemModel.NameUser = _user.data.NameUser;
            userSystemModel.TypeDocument = _user.data.TypeDocument;
            userSystemModel.Document = _user.data.Document;
            userSystemModel.Phone = _user.data.Phone;
            userSystemModel.Email = _user.data.Email;
            userSystemModel.AddressUser = _user.data.AddressUser;

            GlobalApp.SetUserSystemResponse(_httpContextAccessor.HttpContext.Session, userSystemModel);

            return RedirectToAction("Index");
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
