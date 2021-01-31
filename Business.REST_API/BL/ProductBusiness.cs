using AutoMapper;
using Microsoft.Extensions.Logging;
using Models.REST_API;
using Repository.REST_API;
using ViewModels.REST_API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using Entity = Entities.REST_API;

namespace Business.REST_API
{
    public class ProductBusiness : IProductBusiness
    {
        private readonly IProductRepository _productRepository;
        private readonly ProductListResponse _productsResponse;
        private readonly ProductResponse _productResponse;
        private readonly ILogger<ProductBusiness> _logger;
        private readonly IMapper _mapper;

        public ProductBusiness(IProductRepository productRepository,
            ProductResponse productResponse, ProductListResponse productsResponse,
            IMapper mapper, ILogger<ProductBusiness> logger)
        {
            _productRepository = productRepository;
            _productsResponse = productsResponse;
            _productResponse = productResponse;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ProductListResponse> GetProducts()
        {
            try
            {
                _productsResponse.IsSuccess = false;
                _productsResponse.Message = "Some error Occurred while fetching the data";
                var products = await _productRepository.GetProductList();
                if (products != null && products.Any())
                {
                    //<Source, Destination>
                    //IEnumerable<Entity.ProductMaster>, 
                    var result = _mapper.Map<IEnumerable<ProductMaster>>(products);
                    _productsResponse.ProductList = result;
                    _productsResponse.IsSuccess = true;
                    _productsResponse.Message = "Products Returned Successfully";
                }

            }
            catch (Exception ex)
            {
                _logger.LogError("[GetProducts] -> {ErrorMessage}", ex.StackTrace);
                _productsResponse.Message = ex.Message;
            }
            _logger.LogDebug("[GetProducts] -> {Message}", _productsResponse.Message);
            return _productsResponse;
        }

        public virtual async Task<ProductResponse> GetProductById<T>(int productId) where T : class
        {

            try
            {
                _productResponse.IsSuccess = false;
                _productResponse.Message = "Product Not Found";

                var product = await _productRepository.GetProduct<Entity.ProductMaster>(x => x.ProductMasterId == productId);

                if (product != null)
                {
                    var result = _mapper.Map<ProductMaster>(product);
                    _productResponse.Product = result;
                    _productResponse.IsSuccess = true;
                    _productResponse.Message = "Product Returned Successfully";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("[GetProductById] -> {ErrorMessage}", ex.StackTrace);
                _productResponse.Message = ex.Message;
            }
            _logger.LogDebug("[GetProductById] -> {Message}", _productResponse.Message);
            return _productResponse;
        }

        public virtual async Task<ProductResponse> AddProduct<T>(T model) where T : class
        {
            //throw new Exception("Not implemented");
            try
            {
                _productResponse.IsSuccess = false;
                _productResponse.Message = "Product Not Saved";

                
                var mappedProduct = _mapper.Map<Entity.ProductMaster>(model);
                //Add Business Validation here so that same product cannot be added twice
                //var existingProduct = await _productRepository.GetProduct
                //    (x => x.Product.ComputerTypeId == mappedProduct.Product.ComputerTypeId
                //        && x.Product.ProcessorId == mappedProduct.Product.ProcessorId
                //        && x.Product.BrandId == mappedProduct.Product.BrandId
                //        && x.FormFactorId == mappedProduct.FormFactorId);
                ////Similar product already exists, return from here
                //if (existingProduct != null)
                //{
                //    _productResponse.Message = "Inventory for the same product already exists, please change the product details or update the existing product!!!";
                //    return _productResponse;
                //}

                var newProduct = await _productRepository.AddProduct(mappedProduct);

                if (newProduct != null)
                {
                    var result = _mapper.Map<ProductMaster>(newProduct);
                    _productResponse.Product = result;
                    _productResponse.IsSuccess = true;
                    _productResponse.Message = "Product Saved Successfully";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("[AddProduct] -> {ErrorMessage}", ex.StackTrace);
                _productResponse.Message = ex.Message;
            }
            _logger.LogDebug("[AddProduct] -> {Message}", _productResponse.Message);
            return _productResponse;


        }

        public virtual async Task<ProductResponse> UpdateProduct<T>(T model) where T : class
        {
            //throw new Exception("Not implemented");
            try
            {
                _productResponse.IsSuccess = false;
                _productResponse.Message = "Product Not Saved";


                var mappedProduct = _mapper.Map<Entity.ProductMaster>(model);
                //Add Business Validation here so that same product cannot be added twice
                //var existingProduct = await _productRepository.GetProduct
                //    (x => x.Product.ComputerTypeId == mappedProduct.Product.ComputerTypeId
                //        && x.Product.ProcessorId == mappedProduct.Product.ProcessorId
                //        && x.Product.BrandId == mappedProduct.Product.BrandId
                //        && x.FormFactorId == mappedProduct.FormFactorId);
                ////Similar product already exists, return from here
                //if (existingProduct != null)
                //{
                //    _productResponse.Message = "Inventory for the same product already exists, please change the product details or update the existing product!!!";
                //    return _productResponse;
                //}

                var newProduct = await _productRepository.UpdateProduct(mappedProduct);

                if (newProduct != null)
                {
                    var result = _mapper.Map<ProductMaster>(newProduct);
                    _productResponse.Product = result;
                    _productResponse.IsSuccess = true;
                    _productResponse.Message = "Product Saved Successfully";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("[UpdateProduct] -> {ErrorMessage}", ex.StackTrace);
                _productResponse.Message = ex.Message;
            }
            _logger.LogDebug("[UpdateProduct] -> {Message}", _productResponse.Message);
            return _productResponse;


        }

    }
}
