using DAL.Repositories.Interfaces.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Model.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Areas.Member.Models.DTOs;

namespace WebApplication2.Areas.Member.Controllers
{
    [Area("Member")]
    public class SatisController : Controller
    {
        private readonly IAppUserRepository appUserRepository;
        private readonly IReceteRepository receteRepository;
        private readonly ISatisHrkRepository satisHrkRepository;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IBasketRepository basketRepository;

        public SatisController(IAppUserRepository appUserRepository,IReceteRepository receteRepository, ISatisHrkRepository satisHrkRepository,UserManager<IdentityUser> userManager,IBasketRepository basketRepository)
        {
            this.appUserRepository = appUserRepository;
            this.receteRepository = receteRepository;
            this.satisHrkRepository = satisHrkRepository;
            this.userManager = userManager;
            this.basketRepository = basketRepository;
        }




        public IActionResult SatinAl(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var sepet = basketRepository.GetDefault(a => a.ID == id);

                    var Satis = new SatisHrk
                    {
                        Fiyat = sepet.Fiyat,
                        Adet = sepet.Adet,
                        ReceteID = sepet.ReceteID,
                        AppUser = sepet.AppUser,
                        AppUserId = sepet.AppUserId,
                        ToplamTutar = sepet.ToplamTutar,
                        CreatedDate = DateTime.Now,
                        Recete = sepet.Recete,

                    };
                    basketRepository.Remove(sepet);
                    satisHrkRepository.Create(Satis);
                    ViewBag.islem = "Tebrikler Başarılır bir şekilde Alındı.";
                    return View(Satis);
                }

            }
            catch (Exception)
            {

                ViewBag.islem = "Başarısız lütfen tekrar deneyin..";
            }

            return RedirectToAction("Sepet", "Recete");
        }



        public async Task<IActionResult> TumSatis()
        {
            IdentityUser identityUser = await userManager.GetUserAsync(User);

            AppUser appUser = appUserRepository.GetDefault(a => a.IdentityId == identityUser.Id);
            var sepet = basketRepository.GetDefaults(a => a.AppUserId == appUser.ID);
            int row = 0;

            foreach (var item in sepet)
            {
                var satis = new SatisHrk
                {
                    Adet = sepet[row].Adet,
                    AppUser = appUser,
                    AppUserId = sepet[row].AppUserId,
                    CreatedDate = DateTime.Now,
                    Fiyat = sepet[row].Fiyat,
                    Recete = sepet[row].Recete,
                    ReceteID = sepet[row].ReceteID,
                    ToplamTutar = sepet[row].ToplamTutar,


                };

                satisHrkRepository.Create(satis);
                row++;
                ViewBag.satis = "Satis Başarılı";


            }


            basketRepository.RemoveRange(sepet);
            return View(sepet);

        }





        [HttpGet]
        public async Task<IActionResult> Rapor()
        {

            IdentityUser identityUser = await userManager.GetUserAsync(User);

            AppUser appUser = appUserRepository.GetDefault(a => a.IdentityId == identityUser.Id);


            var rapor = satisHrkRepository.GetByDefaults
                (
                  selector: a => new RaporUrunDTO { ReceteID = a.ReceteID, UrunAdi = a.Recete.UrunAdi, CreatedDate = a.CreatedDate, Adet = a.Adet, Fiyat = a.Fiyat, ToplamTutar = a.ToplamTutar, Recete = a.Recete },
                  expression: a => a.CreatedDate.Date == DateTime.Today

                );

            var raporUrun = rapor.GroupBy(t => t.Recete.UrunAdi).Select(t => new RaporUrunDTO { UrunAdi = t.Key, Adet = t.Sum(a => a.Adet) }).ToList();
            return View(raporUrun);


        }

        
     








        [HttpGet]
        public async Task<IActionResult> Rapor2(DateTime dto )
        {

            IdentityUser identityUser = await userManager.GetUserAsync(User);

            AppUser appUser = appUserRepository.GetDefault(a => a.IdentityId == identityUser.Id);


            var rapor = satisHrkRepository.GetByDefaults
                (
                  selector: a => new RaporUrunDTO { ReceteID = a.ReceteID, UrunAdi = a.Recete.UrunAdi, CreatedDate = a.CreatedDate, Adet = a.Adet, Fiyat = a.Fiyat, ToplamTutar = a.ToplamTutar, Recete = a.Recete },
                  expression: a => a.CreatedDate.Date == DateTime.Today

                ) ;

            var adet = rapor.Where(a => a.ReceteID == a.ReceteID).Sum(a => a.Adet);
            ViewBag.adet = adet;
            var total = rapor.Where(a => a.ReceteID == a.ReceteID).Sum(a => a.ToplamTutar);
            ViewBag.total = total;
            return View(rapor);


        }






        public async Task< IActionResult> Search(DateListDTO dto)
        {

            IdentityUser identityUser = await userManager.GetUserAsync(User);

            AppUser appUser = appUserRepository.GetDefault(a => a.IdentityId == identityUser.Id);


            var rapor = satisHrkRepository.GetByDefaults
                (
                  selector: a => new RaporUrunDTO { ReceteID = a.ReceteID, UrunAdi = a.Recete.UrunAdi, CreatedDate = a.CreatedDate, Adet = a.Adet, Fiyat = a.Fiyat, ToplamTutar = a.ToplamTutar, Recete = a.Recete },
                  expression: a => a.CreatedDate.Date==dto.Baslangic 
                );



            var raporUrun = rapor.GroupBy(t => t.Recete.UrunAdi).Select(t => new RaporUrunDTO { UrunAdi = t.Key, Adet = t.Sum(a => a.Adet) }).ToList();
            return View(raporUrun);

        }






    }



}




