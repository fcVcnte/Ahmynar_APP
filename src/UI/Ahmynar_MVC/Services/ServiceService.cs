using Ahmynar_MVC.Contracts;
using Ahmynar_MVC.Models;
using Ahmynar_MVC.Services.Base;
using AutoMapper;

namespace Ahmynar_MVC.Services
{
    public class ServiceService : BaseHttpService, IServiceService
    {
        private readonly ILocalStorageService _localStorageService;
        private readonly IMapper _mapper;
        private readonly IClient _httpclient;

        public ServiceService(ILocalStorageService localStorageService, IMapper mapper, IClient httpclient) : base(localStorageService, httpclient)
        {
            this._localStorageService = localStorageService;
            this._mapper = mapper;
            this._httpclient = httpclient;
        }

        public async Task<Response<int>> CreateService(CreateServiceVM service)
        {
            try
            {
                var response = new Response<int>();
                CreateServiceDto createService = _mapper.Map<CreateServiceDto>(service);
                AddBearerToken();
                var apiResponse = await _client.ServicePOSTAsync(createService);

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

        public async Task<Response<int>> DeleteService(int id)
        {
            try
            {
                AddBearerToken();
                await _client.ServiceDELETEAsync(id);
                return new Response<int> { Success = false };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }

        public async Task<ServiceVM> GetServiceDetails(int id)
        {
            AddBearerToken();
            var service = await _client.ServiceGETAsync(id);
            return _mapper.Map<ServiceVM>(service);
        }

        public async Task<List<ServiceVM>> GetServices()
        {
            AddBearerToken();
            var services = await _client.ServiceAllAsync();
            return _mapper.Map<List<ServiceVM>>(services);
        }

        public async Task<Response<int>> UpdateService(ServiceVM service)
        {
            try
            {
                UpdateServiceDto serviceDto = _mapper.Map<UpdateServiceDto>(service);
                AddBearerToken();
                await _client.ServicePUTAsync(serviceDto);
                return new Response<int> { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }
    }
}
