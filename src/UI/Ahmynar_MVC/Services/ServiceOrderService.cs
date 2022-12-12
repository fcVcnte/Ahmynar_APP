using Ahmynar_MVC.Contracts;
using Ahmynar_MVC.Models;
using Ahmynar_MVC.Services.Base;
using AutoMapper;

namespace Ahmynar_MVC.Services
{
    public class ServiceOrderService : BaseHttpService, IServiceOrderService
    {
        private readonly ILocalStorageService _localStorageService;
        private readonly IMapper _mapper;
        private readonly IClient _httpclient;

        public ServiceOrderService(ILocalStorageService localStorageService, IMapper mapper, IClient httpclient) : base(localStorageService, httpclient)
        {
            this._localStorageService = localStorageService;
            this._mapper = mapper;
            this._httpclient = httpclient;
        }

        public async Task<Response<int>> CreateServiceOrder(CreateServiceOrderVM serviceOrder)
        {
            try
            {
                var response = new Response<int>();
                CreateServiceOrderDto createServiceOrder = _mapper.Map<CreateServiceOrderDto>(serviceOrder);
                AddBearerToken();
                var apiResponse = await _client.ServiceOrderPOSTAsync(createServiceOrder);

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

        public async Task<Response<int>> DeleteServiceOrder(int id)
        {
            try
            {
                AddBearerToken();
                await _client.ServiceOrderDELETEAsync(id);
                return new Response<int> { Success = false };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }

        public async Task<ServiceOrderVM> GetServiceOrderDetails(int id)
        {
            AddBearerToken();
            var serviceOrder = await _client.ServiceOrderGETAsync(id);
            serviceOrder.Budget = await _client.BudgetGETAsync((int)serviceOrder.BudgetId);
            return _mapper.Map<ServiceOrderVM>(serviceOrder);
        }

        public async Task<List<ServiceOrderVM>> GetServiceOrders()
        {
            AddBearerToken();
            var serviceOrders = await _client.ServiceOrderAllAsync();
            foreach (var serviceOrder in serviceOrders)
            {
                serviceOrder.Budget = await _client.BudgetGETAsync((int)serviceOrder.BudgetId);
            }
            return _mapper.Map<List<ServiceOrderVM>>(serviceOrders);
        }

        public async Task<Response<int>> UpdateServiceOrder(ServiceOrderVM serviceOrder)
        {
            try
            {
                UpdateServiceOrderDto serviceOrderDto = _mapper.Map<UpdateServiceOrderDto>(serviceOrder);
                AddBearerToken();
                await _client.ServiceOrderPUTAsync(serviceOrderDto);
                return new Response<int> { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }
    }
}
