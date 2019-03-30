namespace ProductShop
{
    using AutoMapper;
    using ProductShop.Dtos.Export;
    using ProductShop.Dtos.Import;
    using ProductShop.Models;

    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            this.CreateMap<UserImportDto, User>();

            this.CreateMap<ProductImportDto, Product>();

            this.CreateMap<CategoryImportDto, Category>();

            this.CreateMap<CategoryProductImportDto, CategoryProduct>();

            this.CreateMap<Product, ProductInRangeDto>();
        }
    }
}
