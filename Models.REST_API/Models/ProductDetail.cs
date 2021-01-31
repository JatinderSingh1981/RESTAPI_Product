using Common.REST_API;

namespace Models.REST_API
{
    public class ProductDetail
    {
        public int Id { get; set; }
        public int ProductMasterId { get; set; }
        public string PropertyName { get; set; }
       
        public string PropertyValue { get; set; }

        public string LookupPropertyValue { get; set; }

        public int PropertyTypeId { get; set; }
        public string PropertyType { get; set; }
        public int? LookUpSourceId { get; set; }
        public string LookUpSource { get; set; }
    }
}
