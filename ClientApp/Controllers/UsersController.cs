using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using ClientApp.Service.Interface;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Text;
using ClientApp.Models;
using Newtonsoft.Json;

namespace ClientApp.Controllers
{
    public class UsersController : Controller
    {

        private readonly IUser userService;

        public UsersController(IUser service)
        {
            userService = service ?? throw new ArgumentNullException(nameof(service));
        }

        public async Task<IActionResult> Index()
        {
            var users = await userService.getUsers();
            return View(users);
        }

        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(UserViewModel user)
        {
            if (ModelState.IsValid)
            {
                var postUserData = await userService.addUser(user);
                if (postUserData.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    // TempData["Profile"] = JsonConvert.SerializeObject(user);
                    return RedirectToAction("Index");
                }
                else if (postUserData.StatusCode == System.Net.HttpStatusCode.Conflict)
                {
                    ModelState.Clear();
                    ModelState.AddModelError("Error", "Client already exist");
                    return View();
                }
            }
           
            return View(user);
            
        }
    }
}
