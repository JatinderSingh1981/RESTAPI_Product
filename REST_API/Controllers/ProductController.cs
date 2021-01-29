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
using System.Net;

namespace REST_API.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/v1/Product")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductBusiness _productBL;

        public ProductController(IProductBusiness productBL, ILogger<ProductController> logger)
        {
            _productBL = productBL;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ProductsResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProductsResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<ProductsResponse>> Get()
        {
            //Create logs here
            var result = await _productBL.GetProducts();
            if (result.IsSuccess)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpGet("GetProductById/{id}")]
        [ProducesResponseType(typeof(ProductResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProductResponse), (int)HttpStatusCode.BadRequest)]
        public virtual async Task<ActionResult<ProductResponse>> GetProductById(int id)
        {
            //Create logs here
            var result = await _productBL.GetProductById<ProductMaster>(id);
            if (result.IsSuccess)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ProductResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProductResponse), (int)HttpStatusCode.BadRequest)]
        public virtual async Task<ActionResult<ProductResponse>> Post(ProductMaster model)
        {
            //Create logs here
            var result = await _productBL.AddProduct(model);
            if (result.IsSuccess)
                return Ok(result);
            else
                return BadRequest(result);
        }
    }
}
