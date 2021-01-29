using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Business.REST_API;
using System.Threading.Tasks;
using ViewModels.REST_API;
using Common.REST_API;
using System.Collections.Generic;
using System;

namespace REST_API.Controllers
{
    /// <summary>
    /// The methods are not async methods because I am getting the values from the memory and not DB.
    /// If I have to fetch the values from DB, I will convert these to async Task methods.
    /// </summary>
    [ApiController]
    //[Produces("application/json")]
    [Route("api/v1/Enum")]
    public class EnumController : ControllerBase
    {
        private readonly ILogger<EnumController> _logger;
        private readonly IEnumBusiness _enumBL;

        public EnumController(IEnumBusiness enumBL,
            ILogger<EnumController> logger)
        {
            _enumBL = enumBL;
            _logger = logger;
        }

        [HttpGet("formfactor")]
        public IEnumerable<FormFactor> GetFormFactorList()
        {
            return _enumBL.GetList<FormFactor>();
        }

        [HttpGet("processortype")]
        public IEnumerable<ProcessorType> GetProcessorTypeList()
        {
            return _enumBL.GetList<ProcessorType>();
        }

        [HttpGet("producttype")]
        public IEnumerable<ProductType> GetProductTypeList()
        {
            return _enumBL.GetList<ProductType>();
        }

        [HttpGet("propertytype")]
        public IEnumerable<PropertyType> GetPropertyTypeList()
        {
            return _enumBL.GetList<PropertyType>();
        }

        [HttpGet("brand")]
        public IEnumerable<Brand> GetBrandList()
        {
            return _enumBL.GetList<Brand>();
        }

        [HttpGet("lookupsource")]
        public IEnumerable<LookupSource> GetLookUpSourceList()
        {
            return _enumBL.GetList<LookupSource>();
        }

    }
}
