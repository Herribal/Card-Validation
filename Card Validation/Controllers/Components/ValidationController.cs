using Card.Validation.Core.Domain.Cards;
using Card.Validation.Web.App.Config;
using Card.Validation.Web.App.Helpers;
using Card.Validation.Web.App.Models;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Card.Validation.Web.App.Controllers.Components
{
    public class ValidationController : BaseController
    {
        private readonly CardHelper _cardHelper;

        public ValidationController()
        {
            _cardHelper = new CardHelper();
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(ValidationViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (model.CardTypeCode.Equals(CardType.OT.ToString()))
            {
                model.CardTypeCode = _cardHelper.GetCardType(model.CardNumber).ToString();
            }

            try
            {
                using (var uow = AppConfig.DBRepositoryUow)
                {
                    var checkExisting = await uow.DBRepository.GetCardByNumberAsync(model.CardNumber)
                        .ConfigureAwait(false);

                    if (checkExisting != null && !string.IsNullOrWhiteSpace(checkExisting.CardNumber))
                    {
                        ModelState.AddModelError("CardNumber", "Credit Card already exists");
                        return View(model);
                    }

                    var type = await uow.DBRepository.GetCardTypeByCodeAsync(model.CardTypeCode)
                        .ConfigureAwait(false);

                    var card = new CardModel
                    {
                        CardRefNo = Guid.NewGuid().ToString(),
                        CardNumber = model.CardNumber,
                        CardCreateDate = DateTime.Now.ToString("yyyy/dd/MM H:mm:ss"),
                        CardTypeRefNo = type.CardTypeRefNo
                    };

                    var newCard = AppConfig.AutoMapper.Map<NewCardModel>(card);
                
                    var result = await uow.DBRepository.InsertCardAsync("card", newCard)
                        .ConfigureAwait(false);

                    if (!result)
                        return View(model);

                    // MySql Syntax error -  You have an error in your SQL syntax;
                    // check the manual that corresponds to your MySQL server version for the right syntax to use near '' Line 1
                    uow.Commit();

                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception ex)
            {
                var message = ex.Message;           
                
                return View(model);
            }                          
        }
    }
}