using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Business.REST_API;
using System.Threading.Tasks;
using ViewModels.REST_API;
using Common.REST_API;
using System.Collections.Generic;
using System;
using System.Net;

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
        [ProducesResponseType(typeof(EnumResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(EnumResponse), (int)HttpStatusCode.BadRequest)]
        public EnumResponse GetFormFactorList()
        {
            return _enumBL.GetList<FormFactor>();
        }

        [HttpGet("processortype")]
        [ProducesResponseType(typeof(EnumResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(EnumResponse), (int)HttpStatusCode.BadRequest)]
        public EnumResponse GetProcessorTypeList()
        {
            return _enumBL.GetList<ProcessorType>();
        }

        [HttpGet("producttype")]
        [ProducesResponseType(typeof(EnumResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(EnumResponse), (int)HttpStatusCode.BadRequest)]
        public EnumResponse GetProductTypeList()
        {
            return _enumBL.GetList<ProductType>();
        }

        [HttpGet("propertytype")]
        [ProducesResponseType(typeof(EnumResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(EnumResponse), (int)HttpStatusCode.BadRequest)]
        public EnumResponse GetPropertyTypeList()
        {
            return _enumBL.GetList<PropertyType>();
        }

        [HttpGet("brand")]
        [ProducesResponseType(typeof(EnumResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(EnumResponse), (int)HttpStatusCode.BadRequest)]
        public EnumResponse GetBrandList()
        {
            return _enumBL.GetList<Brand>();
        }

        [HttpGet("lookupsource")]
        [ProducesResponseType(typeof(EnumResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(EnumResponse), (int)HttpStatusCode.BadRequest)]
        public EnumResponse GetLookUpSourceList()
        {
            return _enumBL.GetList<LookupSource>();
        }

    }
}
