using AutoMapper;
using Models.REST_API;
using Microsoft.Extensions.Options;
using Common.REST_API;
using Entity = Entities.REST_API;
using System;

namespace REST_API.Mapper
{
    public class ProductMapper : AutoMapper.Profile
    {
        public static string MapEnum<T>(int? enumValue) where T : Enumeration
        {
            if (enumValue.HasValue && enumValue.Value > 0)
                return Enumeration.FromValue<T>(enumValue.Value).Name;
            return string.Empty;

        }
        public ProductMapper()
        {

            #region Map from entity to model
            CreateMap<Entity.ProductMaster, ProductMaster>()
                .ForMember(m => m.Brand, e => e.MapFrom(o => MapEnum<Brand>(o.BrandId)))
                .ForMember(m => m.Processor, e => e.MapFrom(o => MapEnum<ProcessorType>(o.ProcessorId)))
                .ForMember(m => m.ComputerType, e => e.MapFrom(o => MapEnum<ProductType>(o.ComputerTypeId)));
            //.ForMember(d => d.ProductDetails, opt => opt.MapFrom(src => src.ProductDetails));

            CreateMap<Entity.ProductDetail, ProductDetail>()
                .ForMember(m => m.PropertyType, e => e.MapFrom(o => MapEnum<PropertyType>(o.PropertyTypeId)))
                .ForMember(m => m.LookUpSource, e => e.MapFrom(o => MapEnum<LookupSource>(o.LookUpSourceId)));
            //.ForMember(m => m.ComputerType, e => e.MapFrom(et => Enumeration.FromValue<ProductType>(et.Product.ComputerTypeId).Name))
            //.ForMember(m => m.PropertyType, e => e.MapFrom(et => Enumeration.FromValue<PropertyType>(et.PropertyTypeId).Name))
            //.ForMember(m => m.LookUpSource, e => e.MapFrom(et => Enumeration.FromValue<LookupSource>(et.LookUpSourceId).Name));
            #endregion

            #region Map from Model to Entity
            CreateMap<ProductMaster, Entity.ProductMaster>();
            CreateMap<ProductDetail, Entity.ProductDetail>();


            #endregion


        }

    }

}
