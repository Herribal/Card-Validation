using Card.Validation.Core.Attributes;

namespace Card.Validation.Core.Domain.Cards
{
    public class NewCardModel : IDomainModel
    {
        [Column("CardRefNo")]
        public string CardRefNo { get; set; }
        [Column("CardNumber")]
        public string CardNumber { get; set; }
        [Column("CardCreateDate")]
        public string CardCreateDate { get; set; }
        [Column("CardTypeRefNo")]
        public string CardTypeRefNo { get; set; }
    }
}
