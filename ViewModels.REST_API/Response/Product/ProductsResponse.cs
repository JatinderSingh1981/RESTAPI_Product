using Models.REST_API;
using System.Collections.Generic;

namespace ViewModels.REST_API
{
    public class ProductsResponse
    {
        public IEnumerable<ProductMaster> Products { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
