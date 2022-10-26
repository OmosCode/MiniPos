using DAL.Repositories.Interfaces.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Model.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Areas.Member.Models.VMs;

namespace WebApplication2.Areas.Member.Controllers
{
    [Area("Member")]
    public class AppUserController : Controller
    {
        private readonly IAppUserRepository appUserRepository;
       
        private readonly IReceteRepository receteRepository;
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AppUserController(IAppUserRepository appUserRepository,  IReceteRepository receteRepository,UserManager<IdentityUser> userManager,SignInManager<IdentityUser> signInManager)
        {
            this.appUserRepository = appUserRepository;
           
            this.receteRepository = receteRepository;
            this.userManager = userManager;
            this.signInManager = signInManager;
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
                          AppUser = a.AppUser,
                          AppUserId = a.AppUserId,
                          ImagePath = a.ImagePath,
                          UrunAdi = a.UrunAdi,
                          UrunFiyat = a.UrunFiyat,


                      },
                      expression: a => a.Statu != Model.Enums.Statu.Passive



                    ); ;


                return View(List);

            }
            return Redirect("~/");
        }


        public async Task<IActionResult> LogOut()
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
