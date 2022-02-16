using System.Collections.Generic;
using System.Threading.Tasks;

using Blue.Shared;

namespace Blue.Client.Services
{
    public interface ICityService
    {
        Task<CityViewModel> GetCityById(long id);
        Task DeleteCityById(long id);
        Task UpdateCity(CityViewModel city);

        Task<List<CityViewModel>> GetAllCities();
        Task<CityViewModel> CreateCity(CityViewModel city);
    }
}