using Ahmynar_MVC.Contracts;
using Ahmynar_MVC.Models;
using Ahmynar_MVC.Services.Base;
using AutoMapper;

namespace Ahmynar_MVC.Services
{
    public class ProductService : BaseHttpService, IProductService
    {
        private readonly ILocalStorageService _localStorageService;
        private readonly IMapper _mapper;
        private readonly IClient _httpclient;

        public ProductService(ILocalStorageService localStorageService, IMapper mapper, IClient httpclient) : base(localStorageService, httpclient)
        {
            this._localStorageService = localStorageService;
            this._mapper = mapper;
            this._httpclient = httpclient;
        }

        public async Task<Response<int>> CreateProduct(CreateProductVM product)
        {
            try
            {
                var response = new Response<int>();
                CreateProductDto createProduct = _mapper.Map<CreateProductDto>(product);
                var apiResponse = await _client.ProductPOSTAsync(createProduct);

                if (apiResponse.Success)
                {
                    response.Data = apiResponse.Id;
                    response.Success = true;
                }
                else
                {
                    foreach (var error in apiResponse.Errors)
                    {
                        response.ValidationErrors += error + Environment.NewLine;
                    }
                }
                return response;
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }

        public async Task<Response<int>> DeleteProduct(int id)
        {
            try
            {
                await _client.ProductDELETEAsync(id);
                return new Response<int> { Success = false };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }

        public async Task<ProductVM> GetProductDetails(int id)
        {
            var product = await _client.ProductGETAsync(id);
            return _mapper.Map<ProductVM>(product);
        }

        public async Task<List<ProductVM>> GetProducts()
        {
            var products = await _client.ProductAllAsync();
            return _mapper.Map<List<ProductVM>>(products);
        }

        public async Task<Response<int>> UpdateProduct(ProductVM product)
        {
            try
            {
                UpdateProductDto productDto = _mapper.Map<UpdateProductDto>(product);
                await _client.ProductPUTAsync(productDto);
                return new Response<int> { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }

        public async Task<Response<int>> CheckInProduct(int id, int quantityIn)
        {
            try
            {
                await _client.CheckInAsync(id, quantityIn);
                return new Response<int> { Success = false };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }

        public async Task<Response<int>> CheckOutProduct(int id, int quantityOut)
        {
            try
            {
                await _client.CheckOutAsync(id, quantityOut);
                return new Response<int> { Success = false };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }
    }
}
