using A2SV.ProductHubManagement.Application.DTOs;
using A2SV.ProductHubManagement.Domain;
using AutoMapper;


namespace A2SV.ProductHubManagement.Application.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {

            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product,CreateProdcutDto>().ReverseMap();
            CreateMap<ProductDto, CreateProdcutDto>().ReverseMap();

            CreateMap<Category,CreateCategoryDto>().ReverseMap();
            CreateMap<Category,CategoryDto>().ReverseMap();

            CreateMap<Booking,BookingDto>().ReverseMap();
            

            CreateMap<AuthUser,UserDto>().ReverseMap(); 
           
        }
    }
}
