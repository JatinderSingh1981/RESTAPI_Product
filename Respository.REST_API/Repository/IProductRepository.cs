using Entities.REST_API;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repository.REST_API
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductMaster>> GetProductList();
        Task<T> GetProduct<T>(Expression<Func<T, bool>> predicate, bool includeDetails = true) where T : class;
        Task<T> AddProduct<T>(T product) where T : class;
    }
}
