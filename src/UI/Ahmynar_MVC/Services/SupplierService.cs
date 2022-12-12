using Ahmynar_MVC.Contracts;
using Ahmynar_MVC.Models;
using Ahmynar_MVC.Services.Base;
using AutoMapper;

namespace Ahmynar_MVC.Services
{
    public class SupplierService : BaseHttpService, ISupplierService
    {
        private readonly ILocalStorageService _localStorageService;
        private readonly IMapper _mapper;
        private readonly IClient _httpclient;

        public SupplierService(ILocalStorageService localStorageService, IMapper mapper, IClient httpclient) : base (localStorageService, httpclient)
        {
            this._localStorageService = localStorageService;
            this._mapper = mapper;
            this._httpclient = httpclient;
        }

        public async Task<Response<int>> CreateSupplier(CreateSupplierVM supplier)
        {
            try
            {
                var response = new Response<int>();
                CreateSupplierDto createSupplier = _mapper.Map<CreateSupplierDto>(supplier);
                AddBearerToken();
                var apiResponse = await _client.SupplierPOSTAsync(createSupplier);
                
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

        public async Task<Response<int>> DeleteSupplier(int id)
        {
            try
            {
                AddBearerToken();
                await _client.SupplierDELETEAsync(id);
                return new Response<int>() { Success = false };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }

        public async Task<SupplierVM> GetSupplierDetails(int id)
        {
            AddBearerToken();
            var supplier = await _client.SupplierGETAsync(id);
            return _mapper.Map<SupplierVM>(supplier);
        }

        public async Task<List<SupplierVM>> GetSuppliers()
        {
            AddBearerToken();
            var suppliers = await _client.SupplierAllAsync();
            return _mapper.Map<List<SupplierVM>>(suppliers);
        }

        public async Task<Response<int>> UpdateSupplier(SupplierVM supplier)
        {
            try
            {
                UpdateSupplierDto supplierDto = _mapper.Map<UpdateSupplierDto>(supplier);
                AddBearerToken();
                await _client.SupplierPUTAsync(supplierDto);
                return new Response<int> { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }
    }
}
