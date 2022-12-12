using Ahmynar_MVC.Contracts;
using Ahmynar_MVC.Models;
using Ahmynar_MVC.Services.Base;
using AutoMapper;

namespace Ahmynar_MVC.Services
{
    public class SaleService : BaseHttpService, ISaleService
    {
        private readonly ILocalStorageService _localStorageService;
        private readonly IMapper _mapper;
        private readonly IClient _httpclient;

        public SaleService(ILocalStorageService localStorageService, IMapper mapper, IClient httpclient) : base(localStorageService, httpclient)
        {
            this._localStorageService = localStorageService;
            this._mapper = mapper;
            this._httpclient = httpclient;
        }

        public async Task<Response<int>> CreateSale(CreateSaleVM sale)
        {
            try
            {
                var response = new Response<int>();
                if (sale.TypeSale == Ahmynar_Domain.Enums.TypeSale.BudgetSale)
                {
                    CreateSaleBudgetDto createSale = _mapper.Map<CreateSaleBudgetDto>(sale);
                    AddBearerToken();
                    var apiResponse = await _client.SaleBudgetAsync(createSale);
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
                    CreateSaleProductsDto createSale = _mapper.Map<CreateSaleProductsDto>(sale);
                    AddBearerToken();
                    var apiResponse = await _client.SaleProductsAsync(createSale);

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

        public async Task<SaleVM> GetSaleDetails(int id)
        {
            AddBearerToken();
            var sale = await _client.SaleAsync(id);
            return _mapper.Map<SaleVM>(sale);
        }

        public async Task<List<SaleVM>> GetSales()
        {
            AddBearerToken();
            var sales = await _client.SaleAllAsync();
            return _mapper.Map<List<SaleVM>>(sales);
        }
    }
}
