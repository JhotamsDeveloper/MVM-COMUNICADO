using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebClient.ModelResponse;
using WebClient.Models;

namespace WebClient.Services
{
    public class APIConsumption
    {
        private readonly IConfiguration _configuration;

        public APIConsumption(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<UserSystemResponse> ConsultUser(string document)
        {
            string _getUserSystemByDocumento = $"{_configuration.GetValue<string>("GetAllApis:GetUserSystemByDocumento")}{document}";
            var _httpClient = new HttpClient();
            var _json = await _httpClient.GetStringAsync(_getUserSystemByDocumento);

            UserSystemResponse _userSystemModel = JsonConvert.DeserializeObject<UserSystemResponse>(_json);
            return _userSystemModel;
        }
    }
}
