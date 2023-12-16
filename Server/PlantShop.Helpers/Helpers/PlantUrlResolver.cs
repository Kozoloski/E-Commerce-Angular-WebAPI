using AutoMapper;
using Microsoft.Extensions.Configuration;
using PlantShop.Domain.Entities;
using PlantShop.DTOs;


namespace PlantShop.Helpers.Helpers
{
    public class PlantUrlResolver : IValueResolver<Plant, PlantToReturnDto, string>
    {
        private readonly IConfiguration _config;

        public PlantUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(Plant source, PlantToReturnDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
            {
                return _config["ApiUrl"] + source.PictureUrl;
            }
            return null;
        }
    }
}
