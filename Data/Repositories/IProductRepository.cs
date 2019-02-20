using Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data
{
    /// <summary>
    /// IProductRepository interface
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        /// Gets the products.
        /// </summary>
        /// <returns></returns>
        Task<IList<ProductModel>> GetProducts();

        /// <summary>
        /// Deletes the product.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <returns></returns>
        Task<int> DeleteProduct(string productId);

        /// <summary>
        /// Creates the product.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        Task<int> CreateProduct(ProductModel model);
    }
}
