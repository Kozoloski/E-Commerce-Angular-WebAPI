using AutoMapper;
using PlantShop.DTOs;
using PlantShop.Domain.Entities;


namespace PlantShop.Helpers.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Plant, PlantToReturnDto>()
                .ForMember(d => d.PlantCategory, o => o.MapFrom(s => s.PlantCategory.Name))
                .ForMember(d => d.PlantType, o => o.MapFrom(s => s.PlantType.Name))
                .ForMember(d => d.PictureUrl, o => o.MapFrom<PlantUrlResolver>());
            CreateMap<Domain.Entities.Identity.Address, AddressDto>().ReverseMap();
            CreateMap<CustomerBasketDto, CustomerBasket>();
            CreateMap<BasketItemDto, BasketItem>();

        }
    }
}
