using DAL.Repositories.Interfaces.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Areas.Admin.Models.DTOs;

namespace WebApplication2.Areas.Admin.Views.Shared.Components.AllAnaGrup
{
    [ViewComponent(Name = "AllAnaGrup")]
    public class AllAnaGrup : ViewComponent
    {
        private readonly IReceteRepository receteRepository;
        private readonly IRec_CategoryRepository rec_CategoryRepository;

        public AllAnaGrup(IReceteRepository receteRepository, IRec_CategoryRepository rec_CategoryRepository)
        {
            this.receteRepository = receteRepository;
            this.rec_CategoryRepository = rec_CategoryRepository;
        }


        public IViewComponentResult Invoke()
        {

            var AllAnaGrup = rec_CategoryRepository.GetByDefaults
                (
                  selector: a => new AllAnaGrupDTO()
                  {
                      AnaGrupAd = a.UrunAnagrup,
                      ID = a.ID
                  },
                  expression: a => a.Statu != Model.Enums.Statu.Passive




                );
            return View(AllAnaGrup);


        }
    }
}
