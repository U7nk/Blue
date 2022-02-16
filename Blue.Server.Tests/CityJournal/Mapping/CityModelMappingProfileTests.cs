using System;

using AutoMapper;

using Blue.Server.CityJournal.Mapping;
using Blue.Server.CityJournal.Models;
using Blue.Shared;

using FluentAssertions;

using Xunit;

namespace Blue.Server.Tests.CityJournal.Mapping;

public sealed class CityModelMappingProfileTests
{
    [Fact]
    public void AutoMapperConfigurationIsValid()
    {
        var config = new MapperConfiguration(cfg => cfg.AddProfile<CityModelMappingProfile>());
        config.AssertConfigurationIsValid();
    }

    [Fact]
    public void AutoMapperConvertCityViewModelToCityModelIsValid()
    {
        var config = new MapperConfiguration(cfg => cfg.AddProfile<CityModelMappingProfile>());
        var mapper = config.CreateMapper();
        var cityViewModel = new CityViewModel
        {
            Id = 444,
            Name = "151515",
            CitizensCount = 8686,
            FoundationDate = DateTime.UtcNow,
        };

        var cityModel = mapper.Map<CityModel>(cityViewModel);

        cityModel.Id.Should().Be(cityViewModel.Id);
        cityModel.Name.Should().Be(cityViewModel.Name);
        cityModel.CitizensCount.Should().Be(cityViewModel.CitizensCount);
        cityModel.FoundationDate.Should().Be(cityViewModel.FoundationDate);
    }
    
    [Fact]
    public void AutoMapperConvertCityModelToCityViewModelIsValid()
    {
        var config = new MapperConfiguration(cfg => cfg.AddProfile<CityModelMappingProfile>());
        var mapper = config.CreateMapper();
        var cityModel = new CityModel
        {
            Id = 444,
            Name = "151515",
            CitizensCount = 8686,
            FoundationDate = DateTime.UtcNow,
        };

        var cityViewModel = mapper.Map<CityViewModel>(cityModel);

        cityViewModel.Id.Should().Be(cityModel.Id);
        cityViewModel.Name.Should().Be(cityModel.Name);
        cityViewModel.CitizensCount.Should().Be(cityModel.CitizensCount);
        cityViewModel.FoundationDate.Should().Be(cityModel.FoundationDate);
    }
}