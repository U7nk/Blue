using AutoMapper;

using Blue.Server.CityJournal.Models;
using Blue.Shared;

namespace Blue.Server.CityJournal.Mapping
{
    public sealed class CityModelMappingProfile : Profile
    {
        public CityModelMappingProfile()
        {
            CreateMap<CityViewModel, CityModel>()
                .ForMember(model => model.Id, o => o.MapFrom(viewModel => viewModel.Id))
                .ForMember(model => model.Name, o => o.MapFrom(viewModel => viewModel.Name))
                .ForMember(model => model.CitizensCount, o => o.MapFrom(viewModel => viewModel.CitizensCount))
                .ForMember(model => model.FoundationDate, o => o.MapFrom(viewModel => viewModel.FoundationDate));
            
            CreateMap<CityModel, CityViewModel>()
                .ForMember(model => model.Id, o => o.MapFrom(viewModel => viewModel.Id))
                .ForMember(model => model.Name, o => o.MapFrom(viewModel => viewModel.Name))
                .ForMember(model => model.CitizensCount, o => o.MapFrom(viewModel => viewModel.CitizensCount))
                .ForMember(model => model.FoundationDate, o => o.MapFrom(viewModel => viewModel.FoundationDate));
        }
    }
}