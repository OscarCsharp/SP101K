using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using ClientApp.Service.Interface;
using ClientApp.Models;
using ClientApp.Helpers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Reflection.Metadata;
using System.Text;
using System.Reflection.Metadata.Ecma335;
using System.Net;

namespace ClientApp.Service
{
    public class UserService : IUser
    {
        private readonly HttpClient _client;
        public const string BasePath = "/api/users";

        public UserService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IEnumerable<UserViewModel>> getUsers()
        {
            var response = await _client.GetAsync(BasePath);

            return await response.ReadContentAsync<List<UserViewModel>>();
        }

        public async Task<HttpResponseMessage> addUser(UserViewModel data)
        {
            try
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
                var response = await _client.PostAsync(BasePath, content);

                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }
    }
}
