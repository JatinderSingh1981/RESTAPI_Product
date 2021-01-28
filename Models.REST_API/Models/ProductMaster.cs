using Common.REST_API;
using System.Collections.Generic;

namespace Models.REST_API
{
    public class ProductMaster
    {
        public int ProductMasterId { get; set; }
        
        public string ComputerType { get; set; }
        public int ComputerTypeId { get; set; }
        public string Processor { get; set; }
        public int ProcessorId { get; set; }
        public string Brand { get; set; }
        public int BrandId { get; set; }
        public int USBPorts { get; set; }
        public int RamSlots { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }

        public IEnumerable<ProductDetail> ProductDetails { get; set; }
    }
}
