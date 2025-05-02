using AutoMapper;
using Business.DTOs.Carts;
using Entities.Concretes;

namespace Business.Profiles;

public class CartMappingProfiles : Profile
{
    public CartMappingProfiles()
    {
        CreateMap<Cart, CartResponse>()
            .ForMember(dest => dest.TotalPrice,
                opt => opt.MapFrom(src =>
                    src.CartItems.Sum(ci => ci.Product != null ? ci.Product.Price * ci.Quantity : 0)))
            .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.CustomerId))
            .ForMember(dest => dest.CartId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Size, opt => opt.MapFrom(src => src.CartItems.Sum(ci => ci.Quantity)))
            .ForMember(dest => dest.CartItems, opt => opt.MapFrom(src => src.CartItems)).ReverseMap();

        CreateMap<CartItem, CartItemDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
            .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
            .ForMember(dest => dest.ProductName,
                opt => opt.MapFrom(src => src.Product != null ? src.Product.Name : string.Empty))
            .ForMember(dest => dest.ProductDescription,
                opt => opt.MapFrom(src => src.Product != null ? src.Product.Description : string.Empty))
            .ForMember(dest => dest.ProductImageUrl,
                opt => opt.MapFrom(src => src.Product != null ? src.Product.ImageUrl : string.Empty)).ReverseMap();
    }
}
