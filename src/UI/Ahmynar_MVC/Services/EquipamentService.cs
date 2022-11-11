using Ahmynar_MVC.Contracts;
using Ahmynar_MVC.Models;
using Ahmynar_MVC.Services.Base;
using AutoMapper;

namespace Ahmynar_MVC.Services
{
    public class EquipamentService : BaseHttpService, IEquipamentService
    {
        private readonly ILocalStorageService _localStorageService;
        private readonly IMapper _mapper;
        private readonly IClient _httpclient;

        public EquipamentService(ILocalStorageService localStorageService, IMapper mapper, IClient httpclient) : base(localStorageService, httpclient)
        {
            this._localStorageService = localStorageService;
            this._mapper = mapper;
            this._httpclient = httpclient;
        }

        public async Task<Response<int>> CreateEquipament(CreateEquipamentVM equipament)
        {
            try
            {
                var response = new Response<int>();
                CreateEquipamentDto createEquipament = _mapper.Map<CreateEquipamentDto>(equipament);
                var apiResponse = await _client.EquipamentPOSTAsync(createEquipament);

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

        public async Task<Response<int>> DeleteEquipament(int id)
        {
            try
            {
                await _client.EquipamentDELETEAsync(id);
                return new Response<int> { Success = false };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }

        public async Task<EquipamentVM> GetEquipamentDetails(int id)
        {
            var equipament = await _client.EquipamentGETAsync(id);
            return _mapper.Map<EquipamentVM>(equipament);
        }

        public async Task<List<EquipamentVM>> GetEquipaments()
        {
            var equipaments = await _client.EquipamentAllAsync();
            return _mapper.Map<List<EquipamentVM>>(equipaments);
        }

        public async Task<Response<int>> UpdateEquipament(EquipamentVM equipament)
        {
            try
            {
                UpdateEquipamentDto equipamentDto = _mapper.Map<UpdateEquipamentDto>(equipament);
                await _client.EquipamentPUTAsync(equipamentDto);
                return new Response<int> { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }
    }
}
