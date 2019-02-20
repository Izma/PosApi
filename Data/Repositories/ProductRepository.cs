using Dapper;
using Data.Models;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace Data
{
    /// <summary>
    /// ProductRepository class
    /// </summary>
    /// <seealso cref="BaseRepository" />
    /// <seealso cref="IProductRepository" />
    public class ProductRepository : BaseRepository, IProductRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductRepository"/> class.
        /// </summary>
        /// <param name="factory">The factory.</param>
        public ProductRepository(IConnectionFactory factory) : base(factory)
        {
        }

        /// <summary>
        /// Creates the product.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<int> CreateProduct(ProductModel model)
        {
            var parameters = new DynamicParameters();
            parameters.Add("productId", Guid.NewGuid().ToString().ToLower(), DbType.String, ParameterDirection.Input, 255);
            parameters.Add("name", model.Name, DbType.String, ParameterDirection.Input, 50);
            parameters.Add("barCode", model.BarCode, DbType.String, ParameterDirection.Input, 50);
            parameters.Add("salePrice", model.SalePrice, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("buyPrice", model.BuyPrice, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("stock", model.Stock, DbType.Int32, ParameterDirection.Input);
            parameters.Add("tax", model.Tax, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("measurementUnit", model.MeasurementUnit, DbType.String, ParameterDirection.Input, 50);
            parameters.Add("groupingId", model.GroupingId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("statusId", 1, DbType.Int32, ParameterDirection.Input);
            parameters.Add("userRegister", "Admin", DbType.String, ParameterDirection.Input, 50);
            return await WithConnection(async c => await c.ExecuteAsync(sql: "spCreateProduct", param: parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ConfigureAwait(false);
        }

        /// <summary>
        /// Deletes the product.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Task<int> DeleteProduct(string productId)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Gets the products.
        /// </summary>
        /// <returns></returns>
        public async Task<IList<ProductModel>> GetProducts()
        {
            return await WithConnection(async c =>
            {
                var result = await c.QueryAsync<ProductModel>(sql: "spGetProducts", commandType: CommandType.StoredProcedure, param: null).ConfigureAwait(false);
                return result.AsList();
            }).ConfigureAwait(false);
        }
    }
}
