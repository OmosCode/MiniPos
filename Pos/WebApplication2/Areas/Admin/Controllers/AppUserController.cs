using DAL.Repositories.Interfaces.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Model.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Areas.Admin.Models.VMs;

namespace WebApplication2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AppUserController : Controller
    {
        private readonly IAppUserRepository appUserRepository;
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly IReceteRepository receteRepository;

        public AppUserController(IAppUserRepository appUserRepository, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager,IReceteRepository receteRepository )
        {
            this.appUserRepository = appUserRepository;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.receteRepository = receteRepository;
        }
        public async Task< IActionResult> Index()
        {
            IdentityUser identityUser = await userManager.GetUserAsync(User);

            AppUser appUser = appUserRepository.GetDefault(a => a.IdentityId == identityUser.Id);
            if (appUser != null)
            {
                var List = receteRepository.GetByDefaults
                    (
                      selector: a => new UrunListVM
                      {
                          ID = a.ID,
                          AnaGrupID = a.AnaGrupID,
                           AppUser=a.AppUser,
                            AppUserId=a.AppUserId,
                             ImagePath=a.ImagePath,
                              UrunAdi=a.UrunAdi,
                               UrunFiyat=a.UrunFiyat,


                      },
                      expression:a=>a.Statu!=Model.Enums.Statu.Passive

                      

                    ); ;


                return View(List);

            }
            return Redirect("~/");
        }


        public async Task< IActionResult> LogOut()
        {

            await signInManager.SignOutAsync();
             return Redirect("~/");

        }


        public IActionResult AllAnaGrup(int id)
        {
            var list = receteRepository.GetByDefaults
                (
                  selector: a => new UrunListVM()
                  {
                      AnaGrupID = id,
                      AppUser = a.AppUser,
                      AppUserId = a.AppUserId,
                      ID = a.ID,
                      ImagePath = a.ImagePath,
                      UrunAdi = a.UrunAdi,
                      UrunFiyat = a.UrunFiyat

                  },
                  expression: a => a.Rec_Category.ID == id,
                     orderBy: a => a.OrderByDescending(a => a.CreatedDate)





                );
            return View(list);

        }

    }
}
