using ClientApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ClientApp.Service.Interface
{
    public interface IUser
    {
        Task<IEnumerable<UserViewModel>> getUsers();
        Task<HttpResponseMessage> addUser(UserViewModel data);
    }
}
