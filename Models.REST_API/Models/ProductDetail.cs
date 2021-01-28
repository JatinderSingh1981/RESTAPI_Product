using Common.REST_API;

namespace Models.REST_API
{
    public class ProductDetail
    {
        public int Id { get; set; }
        public int ProductMasterId { get; set; }
        public string PropertyName { get; set; }
       
        public string PropertyValue { get; set; }
       
        public int PropertyType { get; set; }
        public int LookUpSource { get; set; }

        public PropertyType PropertyTypeEnum { get; set; }
        public LookupSource LookUpSourceEnum { get; set; }
    }
}
