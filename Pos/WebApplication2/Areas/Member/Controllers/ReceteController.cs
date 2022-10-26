using DAL.Repositories.Interfaces.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Model.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Areas.Member.Controllers
{
    [Area("Member")]
    public class ReceteController : Controller
    {
        private readonly IAppUserRepository appUserRepository;
        private readonly IReceteRepository receteRepository;
       
        private readonly ISatisHrkRepository satisHrkRepository;
        private readonly IBasketRepository basketRepository;
        private readonly UserManager<IdentityUser> userManager;

        public ReceteController(IAppUserRepository appUserRepository,IReceteRepository receteRepository,ISatisHrkRepository satisHrkRepository, IBasketRepository basketRepository, UserManager<IdentityUser> userManager)
        {
            this.appUserRepository = appUserRepository;
            this.receteRepository = receteRepository;
          
            this.satisHrkRepository = satisHrkRepository;
            this.basketRepository = basketRepository;
            this.userManager = userManager;
        }




        public async Task<IActionResult> Sepet(decimal? tutar)
        {
            if (User.Identity.IsAuthenticated)
            {
                IdentityUser identityUser = await userManager.GetUserAsync(User);
                AppUser appUser = appUserRepository.GetDefault(a => a.IdentityId == identityUser.Id);
                var sepet = basketRepository.GetDefaults(a => a.AppUserId == appUser.ID);
                var x = basketRepository.GetDefault(a => a.AppUserId == appUser.ID);
                if (sepet != null)
                {
                    if (x == null)
                    {
                        ViewBag.Tutar = "Sepetinizde Ürün bulunmuyor...";
                    }
                    else if (x != null)
                    {
                        tutar = basketRepository.GetDefaults(a => a.AppUserId == appUser.ID).Sum(a => a.ToplamTutar);

                        ViewBag.Tutar = "Toplam Tutar=" + tutar + " TL";
                    }

                }
                return View(sepet);
            }
            return View();



        }




        public async Task<IActionResult> Sepetekle(int id)
        {
            IdentityUser identityUser = await userManager.GetUserAsync(User);
            AppUser appUser = appUserRepository.GetDefault(a => a.IdentityId == identityUser.Id); // içerdeki kişiyi tuttum

            Recete recete = receteRepository.GetDefault(a => a.ID == id); // ürünu buldum

            var sepet = basketRepository.GetDefault(a => a.AppUserId == appUser.ID && a.ReceteID == id); // sepetteki ürünü getir
            if (appUser != null) // kullanıcı var mı
            {
                if (sepet != null) // sepet dolu mu
                {
                    sepet.Adet++;
                    sepet.ToplamTutar = recete.UrunFiyat * sepet.Adet;
                    basketRepository.Update(sepet);

                    return RedirectToAction("Index", "AppUser");
                }

                var s = new Basket // sepet boş ise gelen ürünü ekle :))
                {
                    AppUserId = appUser.ID,
                    ReceteID = recete.ID,
                    Adet = 1,
                    Fiyat = recete.UrunFiyat,
                    ToplamTutar = recete.UrunFiyat,
                    CreatedDate = DateTime.Now,
                    UrunAdi = recete.UrunAdi,



                };
                basketRepository.Create(s);
                return RedirectToAction("Index", "AppUser");

            }
            return RedirectToAction("Index", "AppUser");




        }

        public IActionResult Sil(int id)
        {
            var sepet = basketRepository.GetDefault(a => a.ID == id);
            if (sepet.Adet == 1)
            {
                basketRepository.Remove(sepet);
                return RedirectToAction("sepet");
            }
            sepet.Adet--;
            sepet.ToplamTutar = sepet.Fiyat * sepet.Adet;
            basketRepository.Update(sepet);
            return RedirectToAction("sepet");

        }

    }
}
