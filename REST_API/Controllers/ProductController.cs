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
        [ProducesResponseType(typeof(ProductListResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProductListResponse), (int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<ProductListResponse>> Get()
        {
            //Create logs here
            var result = await _productBL.GetProducts();
            if (result.IsSuccess)
                return Ok(result);
            else
                return NotFound(result);
        }

        [HttpGet("GetProductById/{id}")]
        [ProducesResponseType(typeof(EnumResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(EnumResponse), (int)HttpStatusCode.NotFound)]
        public virtual async Task<ActionResult<EnumResponse>> GetProductById(int id)
        {
            //Create logs here
            var result = await _productBL.GetProductById<ProductMaster>(id);
            if (result.IsSuccess)
                return Ok(result);
            else
                return NotFound(result);
        }

        //Removed the post method because it is not tested yet
        //[HttpPost]
        //[ProducesResponseType(typeof(EnumResponse), (int)HttpStatusCode.OK)]
        //[ProducesResponseType(typeof(EnumResponse), (int)HttpStatusCode.BadRequest)]
        //public virtual async Task<ActionResult<EnumResponse>> Post(ProductMaster model)
        //{
        //    if (model == null)
        //    {
        //        return BadRequest("Check the values being passed!!!");
        //    }
        //    //Create logs here
        //    var result = await _productBL.AddProduct(model);
        //    if (result.IsSuccess)
        //        return Ok(result);
        //    else
        //    {
        //        return BadRequest(result);
        //    }
        //}

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(EnumResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(EnumResponse), (int)HttpStatusCode.BadRequest)]
        public virtual async Task<ActionResult<EnumResponse>> Put(int id, [FromBody] ProductMaster model)
        {
            if (model == null || id == 0 || model.ProductMasterId != id)
            {
                return BadRequest("Check the values being passed!!!");
            }
            //Create logs here
            var result = await _productBL.UpdateProduct(model);
            if (result.IsSuccess)
                return Ok(result);
            else
                return BadRequest(result);
        }
    }
}
