using DAL.Repositories.Interfaces.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Model.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Areas.Member.Views.Shared.Components.TotalCountx
{
    [ViewComponent(Name = "TotalCountx")]
    public class TotalCountx :ViewComponent
    {

        private readonly IAppUserRepository appUserRepository;
        private readonly IBasketRepository basketRepository;
        private readonly UserManager<IdentityUser> userManager;

        public TotalCountx(IAppUserRepository appUserRepository, IBasketRepository basketRepository, UserManager<IdentityUser> userManager)
        {
            this.appUserRepository = appUserRepository;
            this.basketRepository = basketRepository;
            this.userManager = userManager;
        }



        public async Task<IViewComponentResult> InvokeAsync()
        {
            IdentityUser identityUser = await userManager.GetUserAsync((System.Security.Claims.ClaimsPrincipal)User);
            AppUser appUser = appUserRepository.GetDefault(a => a.IdentityId == identityUser.Id);
            var sepet = basketRepository.GetDefaults(a => a.AppUserId == appUser.ID);
            if (User.Identity.IsAuthenticated)
            {


                var Count = basketRepository.GetDefaults(a => a.AppUserId == appUser.ID).Sum(a => a.Adet);
                ViewBag.Count = Count;
                if (Count == 0)
                {
                    ViewBag.Count = " ";
                }
                return View(Count);

            }


            return View();




        }


    }
}
