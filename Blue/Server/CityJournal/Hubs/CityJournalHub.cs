using System.Threading.Tasks;

using Blue.Shared;

using Microsoft.AspNetCore.SignalR;

namespace Blue.Server.CityJournal.Hubs
{
    public class CityJournalHub : Hub
    {
        public async Task AddCity(CityViewModel cityViewModel)
        {
            await Clients.All.SendAsync(HubConst.CityJournal.AddCityAction, cityViewModel);
        }
        public async Task UpdateCity(CityViewModel cityViewModel)
        {
            await Clients.All.SendAsync(HubConst.CityJournal.UpdateCityAction, cityViewModel);
        }
        public async Task DeleteCity(CityViewModel cityViewModel)
        {
            await Clients.All.SendAsync(HubConst.CityJournal.DeleteCityAction, cityViewModel);
        }
    }
}
