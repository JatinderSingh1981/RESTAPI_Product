using Common.REST_API;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.REST_API
{
    [Table("ProductMaster")]
    public class ProductMaster : IEntityTypeConfiguration<ProductMaster>
    {
        [Key]
        public int ProductMasterId { get; set; }
        [NotMapped]
        public ProductType ComputerType { get; set; }
        [Required]
        public int ComputerTypeId { get; set; }
        [NotMapped]
        public ProcessorType Processor { get; set; }
        [Required]
        public int ProcessorId { get; set; }
        [NotMapped]
        public Brand Brand { get; set; }
        [Required]
        public int BrandId { get; set; }
        [Required]
        public int USBPorts { get; set; }
        [Required]
        public int RamSlots { get; set; }
        [Required]
        public int Quantity { get; set; }
        public string Description { get; set; }
        [Timestamp]
        public byte[] Timestamp { get; set; }
        public IEnumerable<ProductDetail> ProductDetails { get; set; }

        public void Configure(EntityTypeBuilder<ProductMaster> builder)
        {
            builder.HasMany(c => c.ProductDetails)
                  .WithOne(e => e.ProductMaster);
        }
    }
}
