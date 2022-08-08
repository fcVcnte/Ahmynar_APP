using Ahmynar_Application.DTOs.Product;
using Ahmynar_Application.DTOs.Supplier;
using Ahmynar_Domain;
using AutoMapper;

namespace Ahmynar_Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Product
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, ProductListDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            #endregion Product

            #region Supplier
            CreateMap<Supplier, SupplierDto>().ReverseMap();
            CreateMap<Supplier, SupplierListDto>().ReverseMap();
            CreateMap<Supplier, CreateSupplierDto>().ReverseMap();
            CreateMap<Supplier, UpdateSupplierDto>().ReverseMap();
            #endregion Supplier
        }
    }
}
