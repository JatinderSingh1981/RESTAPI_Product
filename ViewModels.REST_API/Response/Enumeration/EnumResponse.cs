using Common.REST_API;
using Models.REST_API;
using System.Collections.Generic;

namespace ViewModels.REST_API
{
    public class EnumResponse
    {
        public IEnumerable<Enumeration> Enum { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
