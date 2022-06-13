using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Card.Validation.Core.Domain.Cards
{
    public class CardModel
    {
        public string CardRefNo { get; set; }
        public string CardNumber { get; set; }
        public string CardCreateDate { get; set; }
        public string CardTypeRefNo { get; set; }
        public string CardType { get; set; }
    }

    public class CardTypeModel
    {
        public string CardTypeRefNo { get; set; }
        public string CardType { get; set; }
        public string CardCode { get; set; }
    }
}
