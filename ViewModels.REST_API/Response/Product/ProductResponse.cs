using Models.REST_API;

namespace ViewModels.REST_API
{
    public class ProductResponse
    {
        public ProductMaster Product { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
