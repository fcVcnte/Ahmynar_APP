using Ahmynar_MVC.Contracts;
using Ahmynar_MVC.Models;
using Ahmynar_MVC.Services.Base;
using AutoMapper;

namespace Ahmynar_MVC.Services
{
    public class CustomerService : BaseHttpService, ICustomerService
    {
        private readonly ILocalStorageService _localStorageService;
        private readonly IMapper _mapper;
        private readonly IClient _httpclient;

        public CustomerService(ILocalStorageService localStorageService, IMapper mapper, IClient httpclient) : base(localStorageService, httpclient)
        {
            this._localStorageService = localStorageService;
            this._mapper = mapper;
            this._httpclient = httpclient;
        }

        public async Task<Response<int>> CreateCustomer(CreateCustomerVM customer)
        {
            try
            {
                var response = new Response<int>();
                if (customer.TypeCustomer == Ahmynar_Domain.Enums.TypeCustomer.LegalEntity)
                {
                    CreateLegalEntityCustomerDto createCustomer = _mapper.Map<CreateLegalEntityCustomerDto>(customer);
                    var apiResponse = await _client.LegalEntityPOSTAsync(createCustomer);
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
                else
                {
                    CreateNaturalPersonCustomerDto createCustomer = _mapper.Map<CreateNaturalPersonCustomerDto>(customer);
                    var apiResponse = await _client.NaturalPersonPOSTAsync(createCustomer);

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
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }

        public async Task<Response<int>> DeleteCustomer(int id)
        {
            try
            {
                await _client.CustomerDELETEAsync(id);
                return new Response<int>() { Success = false };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }

        public async Task<CustomerVM> GetCustomerDetails(int id)
        {
            var customer = await _client.CustomerGETAsync(id);
            return _mapper.Map<CustomerVM>(customer);
        }

        public async Task<List<CustomerVM>> GetCustomers()
        {
            var customers = await _client.CustomersAllAsync();
            return _mapper.Map<List<CustomerVM>>(customers);
        }

        public async Task<Response<int>> UpdateCustomer(CustomerVM customer)
        {
            try
            {
                if (customer.TypeCustomer == Ahmynar_Domain.Enums.TypeCustomer.LegalEntity)
                {
                    UpdateLegalEntityCustomerDto customerDto = _mapper.Map<UpdateLegalEntityCustomerDto>(customer);
                    await _client.LegalEntityPUTAsync(customerDto);
                    return new Response<int> { Success = true };
                }
                else
                {
                    UpdateNaturalPersonCustomerDto customerDto = _mapper.Map<UpdateNaturalPersonCustomerDto>(customer);
                    await _client.NaturalPersonPUTAsync(customerDto);
                    return new Response<int> { Success = true };
                }
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }
    }
}
