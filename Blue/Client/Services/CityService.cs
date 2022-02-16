using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

using Blue.Shared;

namespace Blue.Client.Services
{
    public sealed class CityService : ICityService
    {
        private readonly HttpClient http;

        public CityService(HttpClient http)
        {
            this.http = http;
        }

        public async Task<CityViewModel> GetCityById(long id)
        {
            var response = await http.GetFromJsonAsync<CityViewModel>($"{EndpointsConst.CityJournal}/{id}");
            return response;
        }

        public async Task UpdateCity(CityViewModel city)
        {
            await http.PutAsJsonAsync($"{EndpointsConst.CityJournal}/{city.Id}", city);
        }

        public async Task<List<CityViewModel>> GetAllCities() => await http.GetFromJsonAsync<List<CityViewModel>>(EndpointsConst.CityJournal);

        public async Task<CityViewModel> CreateCity(CityViewModel city) => await (await http.PostAsJsonAsync(EndpointsConst.CityJournal, city)).Content.ReadFromJsonAsync<CityViewModel>();

        public async Task DeleteCityById(long id)
        {
            await http.DeleteAsync($"{EndpointsConst.CityJournal}/{id}");
        }
    }
}