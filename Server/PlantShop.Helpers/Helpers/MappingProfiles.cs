using AutoMapper;
using PlantShop.DTOs;
using PlantShop.Domain.Entities;
using PlantShop.Domain.Entities.OrderAggregate;

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
            CreateMap<AddressDto, Address>();
            CreateMap<Order, OrderToReturnDto>()
                .ForMember(d => d.DeliveryMethod, o => o.MapFrom(s => s.DeliveryMethod.ShortName))
                .ForMember(d => d.ShippingPrice, o => o.MapFrom(s => s.DeliveryMethod.Price));
            CreateMap<OrderItem, OrderItemDto>()
                .ForMember(d => d.PlantId, o => o.MapFrom(s => s.ItemOrdered.PlantItemId))
                .ForMember(d => d.PlantName, o => o.MapFrom(s => s.ItemOrdered.PlantName))
                .ForMember(d => d.PictureUrl, o => o.MapFrom(s => s.ItemOrdered.PictureUrl))
                .ForMember(d => d.PictureUrl, o => o.MapFrom<OrderItemUrlResolver>());

        }
    }
}
