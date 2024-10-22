using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BusinessObject.Model;
using BusinessObject.ModelsDTO;

namespace ProductManagementAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDTO>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.CategoryName));
            CreateMap<ProductDTO, Product>()
                .ForMember(dest => dest.ProductId, opt => opt.Ignore());
            CreateMap<Category, CategoryDTO>();
            CreateMap<CategoryDTO, Category>()
                .ForMember(dest => dest.CategoryId, opt => opt.Ignore());
            CreateMap<ApplicationUser, MemberDTO>();
            CreateMap<MemberDTO, ApplicationUser>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<Register, ApplicationUser>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<ApplicationUser, LoginModel>();
            CreateMap<Order, OrderDTO>();
            CreateMap<OrderDTO, Order>() 
                .ForMember(dest => dest.OrderId, opt => opt.Ignore());
            CreateMap<OrderDetail, OrderDetailDTO>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.ProductName));
            CreateMap<OrderDetailDTO, OrderDetail>();
        }
    }
}
