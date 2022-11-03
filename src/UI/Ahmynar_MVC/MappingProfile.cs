using Ahmynar_MVC.Models;
using Ahmynar_MVC.Services.Base;
using AutoMapper;

namespace Ahmynar_MVC
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BudgetDto, BudgetVM>().ReverseMap();
            CreateMap<CreateBudgetDto, CreateBudgetVM>().ReverseMap();

            CreateMap<CustomerDto, CustomerVM>().ReverseMap();
            CreateMap<CreateLegalEntityCustomerDto, CreateCustomerVM>().ReverseMap();
            CreateMap<CreateNaturalPersonCustomerDto, CreateCustomerVM>().ReverseMap();
            CreateMap<UpdateLegalEntityCustomerDto, CustomerVM>().ReverseMap();
            CreateMap<UpdateNaturalPersonCustomerDto, CustomerVM>().ReverseMap();

            CreateMap<EquipamentDto, EquipamentVM>().ReverseMap();
            CreateMap<CreateEquipamentDto, CreateEquipamentVM>().ReverseMap();
            CreateMap<UpdateEquipamentDto, EquipamentVM>().ReverseMap();

            CreateMap<ProductDto, ProductVM>().ReverseMap();
            CreateMap<CreateProductDto, CreateProductVM>().ReverseMap();
            CreateMap<UpdateProductDto, ProductVM>().ReverseMap();

            CreateMap<SaleDto, SaleVM>().ReverseMap();
            CreateMap<CreateSaleBudgetDto, CreateSaleBudgetVM>().ReverseMap();
            CreateMap<CreateSaleProductsDto, CreateSaleProductsVM>().ReverseMap();

            CreateMap<ServiceOrderDto, ServiceOrderVM>().ReverseMap();
            CreateMap<CreateServiceOrderDto, CreateServiceOrderVM>().ReverseMap();
            CreateMap<UpdateServiceOrderDto, ServiceOrderVM>().ReverseMap();

            CreateMap<ServiceDto, ServiceVM>().ReverseMap();
            CreateMap<CreateServiceDto, CreateServiceVM>().ReverseMap();
            CreateMap<UpdateServiceDto, ServiceVM>().ReverseMap();

            CreateMap<SupplierDto, SupplierVM>();
            CreateMap<CreateSupplierDto, CreateSupplierVM>().ReverseMap();
            CreateMap<UpdateSupplierDto, SupplierVM>().ReverseMap();
        }
    }
}
