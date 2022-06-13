using Card.Validation.Core.Domain.Cards;
using Card.Validation.Web.App.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Card.Validation.Web.App.Controllers
{
    public class HomeController : BaseController
    {
        [HttpGet]
        public ActionResult Index() 
        {
            return View();
        }

        #region Ajax

        [HttpPost]
        public async Task<ActionResult> CardData()
        {
            try
            {
                using (var uow = AppConfig.DBRepositoryUow)
                {
                    var cards = await uow.DBRepository.GetCardsAsync();

                    return Json(new 
                    { 
                        Data = cards ?? Array.Empty<CardModel>().AsEnumerable()
                    });
                }
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    Data = Array.Empty<CardModel>().AsEnumerable()
                });
            }
        }

        #endregion
    }
}