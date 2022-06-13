using Card.Validation.Core.Domain.Cards;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Card.Validation.Web.App.DataAccess.Repository.DB
{
    public interface IDBRepository
    {
        // GET
        Task<IEnumerable<CardModel>> GetCardsAsync();
        Task<CardModel> GetCardByIdAsync(string id);
        Task<CardModel> GetCardByNumberAsync(string number);
        Task<CardTypeModel> GetCardTypeByCodeAsync(string code);

        // ADD
        //Task<bool> InsertCardAsync(CardModel model);
        Task<bool> InsertCardAsync(string tableName, NewCardModel model);

        // DELETE
        Task<IEnumerable<CardModel>> DeleteCardAsync();
    }
}
