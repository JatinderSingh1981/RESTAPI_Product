using Common.REST_API;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.REST_API
{
    [Table("ProductDetails")]
    public class ProductDetail 
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("ProductMasterId")]
        public int ProductMasterId { get; set; }
        [Required]
        public string PropertyName { get; set; }
        [Required]
        public string PropertyValue { get; set; }
        [NotMapped]
        public PropertyType PropertyType { get; set; }
        [Required]
        public int PropertyTypeId { get; set; }
        [NotMapped]
        public LookupSource LookUpSource { get; set; }
        public int? LookUpSourceId { get; set; }
        [Timestamp]
        public byte[] Timestamp { get; set; }
        
        public ProductMaster ProductMaster { get; set; }

    }
}
