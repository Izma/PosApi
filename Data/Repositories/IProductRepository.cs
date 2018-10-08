using Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data
{
    public interface IProductRepository
    {
        Task<IList<ProductModel>> GetProducts();
    }
}
