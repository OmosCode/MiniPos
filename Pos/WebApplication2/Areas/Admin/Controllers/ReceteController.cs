using AutoMapper;
using DAL.Repositories.Interfaces.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Model.Entities.Concrete;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Areas.Admin.Models.DTOs;
using WebApplication2.Areas.Admin.Models.VMs;


namespace WebApplication2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ReceteController : Controller
    {
        private readonly IAppUserRepository appUserRepository;
        private readonly IReceteRepository receteRepository;
        private readonly IMapper mapper;
        private readonly IRec_CategoryRepository rec_CategoryRepository;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IBasketRepository basketRepository;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ISatisHrkRepository satisHrkRepository;

        public ReceteController(IAppUserRepository appUserRepository, IReceteRepository receteRepository, IMapper mapper, IRec_CategoryRepository rec_CategoryRepository, UserManager<IdentityUser> userManager, IBasketRepository basketRepository, IHttpContextAccessor httpContextAccessor,ISatisHrkRepository satisHrkRepository)
        {
            this.appUserRepository = appUserRepository;
            this.receteRepository = receteRepository;
            this.mapper = mapper;
            this.rec_CategoryRepository = rec_CategoryRepository;
            this.userManager = userManager;
            this.basketRepository = basketRepository;
            this.httpContextAccessor = httpContextAccessor;
            this.satisHrkRepository = satisHrkRepository;
        }
        public IActionResult Index()
        {
            return View();
        }



        public IActionResult AnaGrupCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AnaGrupCreate(CreateAnaGrupDTO dto)
        {
            if (ModelState.IsValid)
            {
                Rec_Category rec_Category = new Rec_Category();
                rec_Category.UrunAnagrup = dto.UrunAnagrup;


                rec_CategoryRepository.Create(rec_Category);

                return RedirectToAction("ReceteList");


            }

            return View(dto);
        }




        public IActionResult ReceteCreate()
        {
            CreateReceteVM vm = new CreateReceteVM()
            {
                Anagrup = rec_CategoryRepository.GetByDefaults
                (
                    selector: a => new GetAnaGrupDTO { AnaGrupAdi = a.UrunAnagrup, ID = a.ID },
                    expression: a => a.Statu != Model.Enums.Statu.Passive
                )

            };
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> ReceteCreate(CreateReceteVM vm)
        {
            IdentityUser identityUser = await userManager.GetUserAsync(User);
            AppUser appUser = appUserRepository.GetDefault(a => a.IdentityId == identityUser.Id);

            if (ModelState.IsValid)
            {
                Recete recete = new Recete();
                recete.UrunAdi = vm.UrunAdi;
                recete.UrunFiyat = vm.UrunFiyat;
                recete.AppUserId = appUser.ID;
                recete.AnaGrupID = vm.AnaGrupID;


                using var image = Image.Load(vm.Image.OpenReadStream()); // dosyayı oku al
                image.Mutate(a => a.Resize(80, 80));   // mutate: değiştirmek , foto yeniden şekilediriliyor.
                Guid guid = Guid.NewGuid();

                image.Save($"wwwroot/images/{guid}.jpg");  // dosyayı images altına kaydet
                recete.ImagePath = $"/images/{guid}.jpg"; // ama biz kaydettiğimi




                receteRepository.Create(recete);
                return RedirectToAction("ReceteList");
            }

            return View(vm);
        }



        public IActionResult ReceteList()
        {
            List<Recete> list = receteRepository.GetDefaults(a => a.Statu != Model.Enums.Statu.Passive);
            return View(list);
        }

        public IActionResult ReceteDelete(int id)
        {
            var x = receteRepository.GetDefault(a => a.ID == id);
            receteRepository.Remove(x);
            return RedirectToAction("ReceteList");
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
                    else if(x!=null)
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

                    return RedirectToAction("Index","AppUser");
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

