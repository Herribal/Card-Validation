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

        // GET: Validation
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            return View();
        }

        // POST: Validation/card
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
                
                    var result = await uow.DBRepository.InsertCardAsync(card);

                    if (!result)
                        return View(model);

                    uow.Commit();

                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception ex)
            {
                var message = ex.Message;
            }

            return View();
        }
    }
}