using Ahmynar_MVC.Contracts;
using Ahmynar_MVC.Models;
using Ahmynar_MVC.Services.Base;
using AutoMapper;

namespace Ahmynar_MVC.Services
{
    public class BudgetService : BaseHttpService, IBudgetService
    {
        private readonly ILocalStorageService _localStorageService;
        private readonly IMapper _mapper;
        private readonly IClient _httpclient;

        public BudgetService(ILocalStorageService localStorageService, IMapper mapper, IClient httpclient) : base(localStorageService, httpclient)
        {
            this._localStorageService = localStorageService;
            this._mapper = mapper;
            this._httpclient = httpclient;
        }

        public async Task<Response<int>> CreateBudget(CreateBudgetVM budget)
        {
            try
            {
                var response = new Response<int>();
                CreateBudgetDto createBudget = _mapper.Map<CreateBudgetDto>(budget);
                AddBearerToken();
                var apiResponse = await _client.BudgetPOSTAsync(createBudget);

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

        public async Task<Response<int>> CancelBudget(int id)
        {
            try
            {
                AddBearerToken();
                await _client.CancelAsync(id);
                return new Response<int> { Success = false };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }

        public async Task<Response<int>> DeleteBudget(int id)
        {
            try
            {
                AddBearerToken();
                await _client.BudgetDELETEAsync(id);
                return new Response<int> { Success = false };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }

        public async Task<BudgetVM> GetBudgetDetails(int id)
        {
            AddBearerToken();
            var budget = await _client.BudgetGETAsync(id);
            return _mapper.Map<BudgetVM>(budget);
        }

        public async Task<List<BudgetVM>> GetBudgets()
        {
            AddBearerToken();
            var budgets = await _client.BudgetAllAsync();
            return _mapper.Map<List<BudgetVM>>(budgets);
        }
    }
}
