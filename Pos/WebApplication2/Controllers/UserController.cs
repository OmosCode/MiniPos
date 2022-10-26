
using AutoMapper;
using DAL.Repositories.Interfaces.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Model.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models.DTOs;

namespace WebApplication2.Controllers
{
    public class UserController : Controller
    {
        private readonly IAppUserRepository appUserRepository;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IMapper mapper;

        public UserController(UserManager<IdentityUser> userManager,IMapper mapper,IAppUserRepository appUserRepository)
        {
            this.userManager = userManager;
            this.mapper = mapper;
            this.appUserRepository = appUserRepository;
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task< IActionResult> Create(CreateUserDTO dto)
        {
            if (ModelState.IsValid)  // herşey tamamsa
            {
                string newId = Guid.NewGuid().ToString();
                IdentityUser identityUser = new IdentityUser { Email = dto.Mail,UserName=dto.UserName,Id=newId };

                IdentityResult result = await userManager.CreateAsync(identityUser, dto.Password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(identityUser, "Member");

                    var user = mapper.Map<AppUser>(dto);
                    user.IdentityId = newId;

                    appUserRepository.Create(user);


                    return RedirectToAction("Login","Home");

                }



            }
            return View(dto);

        }


    }
}
