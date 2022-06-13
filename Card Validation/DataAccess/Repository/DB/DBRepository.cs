using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Card.Validation.Core.DataAccess.Repository;
using Card.Validation.Core.Domain.Cards;

namespace Card.Validation.Web.App.DataAccess.Repository.DB
{
    internal class DBRepository : RepositoryBase, IDBRepository
    {
        public DBRepository(IDbTransaction transaction) 
            : base(transaction)
        { }

        // GET
        public async Task<IEnumerable<CardModel>> GetCardsAsync()
        {
            const string sql = @"SELECT `c`.`CardRefNo`,
                                        `c`.`CardNumber`,
                                        `c`.`CardCreateDate`,
                                        `c`.`CardTypeRefNo`,
                                        `ct`.`CardType`
                                    FROM `card` `c`
                                    LEFT JOIN `cardtype` `ct` ON `ct`.`CardTypeRefNo` = `c`.`CardTypeRefNo`";

            return await Connection.QueryAsync<CardModel>(sql, Transaction).ConfigureAwait(false);
        }

        public async Task<CardModel> GetCardByIdAsync(string id)
        {
            const string sql = @"SELECT `card`.`CardRefNo`,
                                        `card`.`CardNumber`,
                                        `card`.`CardCreateDate`,
                                        `card`.`CardTypeRefNo`
                                    FROM `card` 
                                    WHERE `card`.`CardRefNo` = @id";

            return await Connection.QueryFirstOrDefaultAsync<CardModel>(sql, new
            {
                id
            }, Transaction).ConfigureAwait(false);
        }

        public async Task<CardModel> GetCardByNumberAsync(string number)
        {
            const string sql = @"SELECT `card`.`CardRefNo`,
                                        `card`.`CardNumber`,
                                        `card`.`CardCreateDate`,
                                        `card`.`CardTypeRefNo`
                                    FROM `card` 
                                    WHERE `card`.`CardNumber` = @number";

            return await Connection.QueryFirstOrDefaultAsync<CardModel>(sql, new
            {
                number
            }, Transaction).ConfigureAwait(false);
        }

        public async Task<CardTypeModel> GetCardTypeByCodeAsync(string code)
        {
            const string sql = @"SELECT `cardtype`.`CardTypeRefNo`,
                                        `cardtype`.`CardType`,
                                        `cardtype`.`CardCode`
                                    FROM `cardtype` 
                                    WHERE `cardtype`.`CardCode` = @code";

            return await Connection.QueryFirstOrDefaultAsync<CardTypeModel>(sql, new
            {
                code
            }, Transaction).ConfigureAwait(false);
        }

        // ADD
        public async Task<bool> InsertCardAsync(CardModel model)
        {
            const string sql = @"INSERT INTO `card`
                                    (
                                        `CardRefNo`,
                                        `CardNumber`,
                                        `CardCreateDate`,
                                        `CardTypeRefNo`
                                    )
                                    VALUES
                                    (
                                        @NewId,
                                        @CardNumber,
                                        @CardCreateDate,
                                        @CardTypeRefNo
                                    );";

            return await Connection.ExecuteAsync(sql, new
            {
                NewId = model.CardRefNo,
                CardNumber = model.CardNumber,
                CardCreateDate = model.CardCreateDate,
                CardTypeRefNo = model.CardTypeRefNo

            }, Transaction).ConfigureAwait(false) > 0;
        }

        // DELETE
        public async Task<IEnumerable<CardModel>> DeleteCardAsync()
        {
            const string sql = "";

            return await Connection.QueryAsync<CardModel>(sql, Transaction).ConfigureAwait(false);
        }
    }
}
