using AutoMapper;
using Microsoft.Extensions.Logging;
using Models.REST_API;
using Repository.REST_API;
using ViewModels.REST_API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.REST_API;

namespace Business.REST_API
{
    public class EnumBusiness : IEnumBusiness
    {
        private readonly EnumResponse _enumResponse;
        private readonly ILogger<EnumBusiness> _logger;

        public EnumBusiness(EnumResponse enumResponse, ILogger<EnumBusiness> logger)
        {
            _enumResponse = enumResponse;
            _logger = logger;
        }
     
        public EnumResponse GetList<T>() where T : Enumeration
        {
            //log here if needed
            try
            {
                _enumResponse.Enum = Enumeration.GetAll<T>();
                _enumResponse.IsSuccess = true;
                _enumResponse.Message = "Enumeration returned successfully";
            }
            catch (Exception ex)
            {

                _logger.LogError("[GetList] -> {ErrorMessage}", ex.StackTrace);
                _enumResponse.IsSuccess = false;
                _enumResponse.Message = ex.Message;
            }
            return _enumResponse;
        }
    }
}
