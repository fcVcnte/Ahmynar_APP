using Ahmynar_Application.DTOs.Budget;
using Ahmynar_Application.DTOs.Customer;
using Ahmynar_Application.DTOs.Equipament;
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
            #region Customer
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<Customer, CustomerListDto>().ReverseMap();
            CreateMap<Customer, LegalEntityCustomerDto>().ReverseMap();
            CreateMap<Customer, NaturalPersonCustomerDto>().ReverseMap();
            CreateMap<Customer, CreateLegalEntityCustomerDto>().ReverseMap();
            CreateMap<Customer, CreateNaturalPersonCustomerDto>().ReverseMap();
            CreateMap<Customer, UpdateLegalEntityCustomerDto>().ReverseMap();
            CreateMap<Customer, UpdateNaturalPersonCustomerDto>().ReverseMap();
            #endregion Customer

            #region Budget
            CreateMap<Budget, BudgetDto>().ReverseMap();
            CreateMap<Budget, BudgetListDto>().ReverseMap();
            CreateMap<Budget, CreateBudgetDto>().ReverseMap();
            CreateMap<Budget, UpdateBudgetDto>().ReverseMap();
            #endregion Budget

            #region Equipament
            CreateMap<Equipament, EquipamentDto>().ReverseMap();
            CreateMap<Equipament, EquipamentListDto>().ReverseMap();
            CreateMap<Equipament, CreateEquipamentDto>().ReverseMap();
            CreateMap<Equipament, UpdateEquipamentDto>().ReverseMap();
            #endregion Equipament

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
