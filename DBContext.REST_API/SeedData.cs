using Common.REST_API;
using Entities.REST_API;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBContext.REST_API
{
    public static class SeedData
    {
        public static readonly IEnumerable<ProductMaster> ProductMasterList = new ProductMaster[]
        {
            new ProductMaster {
                ProductMasterId = 1,
                ComputerTypeId = ProductType.Desktop.Id,
                ProcessorId = ProcessorType.i3.Id,
                BrandId = Brand.Dell.Id,
                USBPorts = 3,
                RamSlots = 4,
                Quantity = 100,
                Description = "Added the Desktop product through Seeding"
            },
            new ProductMaster {
                ProductMasterId = 2,
                ComputerTypeId = ProductType.Laptop.Id,
                ProcessorId = ProcessorType.i5.Id,
                BrandId = Brand.HP.Id,
                USBPorts = 3,
                RamSlots = 2,
                Quantity = 50,
                Description = "Added the Laptop product through Seeding"
            }
        };

        public static readonly IEnumerable<ProductDetail> ProductDetailList = new ProductDetail[]
        {
           new ProductDetail
                {
                    Id = 1,
                    ProductMasterId =1,
                    PropertyName ="FormFactor",
                    PropertyValue=FormFactor.MidTower.Name.ToString(),
                    PropertyTypeId = PropertyType.String.Id
                    //LookUpSourceId = LookupSource.FormFactor.Id
                },
           new ProductDetail
                {
                    Id = 2,
                    ProductMasterId =2,
                    PropertyName ="Size",
                    PropertyValue= "15",
                    PropertyTypeId = PropertyType.String.Id

                }

        };


    }
}
