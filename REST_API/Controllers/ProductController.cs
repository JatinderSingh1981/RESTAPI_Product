using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Business.REST_API;
using System.Threading.Tasks;
using ViewModels.REST_API;
using Models.REST_API;
using System.Reflection;
using Entity = Entities.REST_API;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
namespace REST_API.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/v1/{controller}")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductBusiness _productBL;

        public ProductController(IProductBusiness productBL,
            ILogger<ProductController> logger)
        {

            _productBL = productBL;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<ProductsResponse>> Get()
        {
            //Create logs here
            var result = await _productBL.GetProducts();
            //Check if result does not return any products then instead of Ok, return Not Found
            return Ok(result);

            //return NotFound()
        }

        [HttpGet("GetProductById/{id}")]
        public virtual async Task<ActionResult<ProductResponse>> GetProductById(int id)
        {

            //Create logs here
            var result = await _productBL.GetProductById<ProductMaster>(id);
            //Check if result does not return any products then instead of Ok, return Not Found
            return Ok(result);

            //return NotFound()
        }

        [HttpPost]
        public virtual async Task<ActionResult<ProductResponse>> Post(ProductMaster model)
        {
            //Create logs here
            var result = await _productBL.AddProduct<ProductMaster>(model);
            //Check if result does not return any products then instead of Ok, return Not Found
            return Ok(result);
        }
    }
}
