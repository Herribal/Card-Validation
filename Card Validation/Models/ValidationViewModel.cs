using Card.Validation.Web.App.Attributes;

namespace Card.Validation.Web.App.Models
{
    public class ValidationViewModel
    {
        [ValidateCardInfo]
        public string CardNumber { get; set; }
        public string CardTypeCode { get; set; }
    }
}