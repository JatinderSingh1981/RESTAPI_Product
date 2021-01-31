using Models.REST_API;
using System.Collections.Generic;

namespace ViewModels.REST_API
{
    public class ProductListResponse
    {
        public IEnumerable<ProductMaster> ProductList { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
