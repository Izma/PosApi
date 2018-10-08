using Dapper;
using Data.Models;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Data
{
    public class ProductRepository: BaseRepository, IProductRepository
    {
        public ProductRepository(IConnectionFactory factory) : base(factory)
        {
        }

        public async Task<IList<ProductModel>> GetProducts()
        {
            return await WithConnection(async c=> {
                var result = await c.QueryAsync<ProductModel>(sql: "CALL spGetProducts()", commandType: CommandType.Text, param: null).ConfigureAwait(false);
                return result.AsList();
            }).ConfigureAwait(false);
        }
    }
}
