using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Common.REST_API;
using Entities.REST_API;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using DBContext.REST_API;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;

namespace Repository.REST_API
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;
        private readonly ILogger<ProductRepository> _logger;

        public ProductRepository(DataContext context, IOptions<AppSettings> settings,
            ILogger<ProductRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<ProductMaster>> GetProductList()
        {
            _logger.LogDebug("[GetProducts] -> Getting products list from DB");
            //var productDetails = _context.ProductDetail.ToListAsync();
            return await _context.ProductMaster.Include(x => x.ProductDetails).ToListAsync();
        }
        public async Task<T> GetProduct<T>(Expression<Func<T, bool>> predicate, bool includeDetails = true) where T : class
        {
            if (includeDetails)
                return await _context.Set<T>().Include("ProductDetails").FirstOrDefaultAsync(predicate);
            else
                return await _context.Set<T>().FirstOrDefaultAsync(predicate);
        }

        public async Task<T> AddProduct<T>(T product) where T : class
        {
            await _context.Set<T>().AddAsync(product);
            var id = await _context.SaveChangesAsync();
            return await _context.Set<T>().FindAsync(id);

        }
    }
}
