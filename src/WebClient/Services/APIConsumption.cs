using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
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

        internal async Task<UserSystemResponse> ConsultUser(string document)
        {
            string _getUserSystemByDocumento = $"{_configuration.GetValue<string>("GetAllApis:GetUserSystemByDocumento")}{document}";
            var _httpClient = new HttpClient();
            var _json = await _httpClient.GetStringAsync(_getUserSystemByDocumento);

            UserSystemResponse _userSystemModel = JsonConvert.DeserializeObject<UserSystemResponse>(_json);
            return _userSystemModel;
        }

        internal async Task<bool> PostUserSystemAsync(UserSystemModel userSystemModel)
        {
            Uri _urlAddRoles = new Uri($"{_configuration.GetValue<string>("GetAllApis:UserSystem")}");
            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage(HttpMethod.Post, _urlAddRoles))
            {
                var json = JsonConvert.SerializeObject(userSystemModel);

                HttpContent c = new StringContent(json, Encoding.UTF8, "application/json");
                var t = Task.Run(() => PostURI(_urlAddRoles, c));
                t.Wait();
            }
            return true;
        }

        internal async Task<bool> PostUserRrolesSystemAsync(UserSystemRolesModel _userSystemRolesModel)
        {
            Uri _urlAddRoles = new Uri($"{_configuration.GetValue<string>("GetAllApis:UserSystemRoles")}");
            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage(HttpMethod.Post, _urlAddRoles))
            {
                var json = JsonConvert.SerializeObject(_userSystemRolesModel);

                HttpContent c = new StringContent(json, Encoding.UTF8, "application/json");
                var t = Task.Run(() => PostURI(_urlAddRoles, c));
                t.Wait();
            }
            return true;
        }

        internal async Task<IEnumerable<RolesModel>> ConsultRol()
        {
            string _rol = $"{_configuration.GetValue<string>("GetAllApis:Roles")}";
            var _httpClient = new HttpClient();
            var _json = await _httpClient.GetStringAsync(_rol);

            IEnumerable<RolesModel> _rolResponse = JsonConvert.DeserializeObject<IEnumerable<RolesModel>>(_json);
            return _rolResponse;
        }

        private async Task<string> PostURI(Uri u, HttpContent c)
        {
            var response = string.Empty;
            using (var client = new HttpClient())
            {
                HttpResponseMessage result = await client.PostAsync(u, c);
                if (result.IsSuccessStatusCode)
                {
                    response = result.StatusCode.ToString();
                }
            }
            return response;
        }
    }
}
