﻿namespace FastFood.Web.MappingConfiguration
{
    using AutoMapper;
    using FastFood.Web.ViewModels.Categories;
    using FastFood.Web.ViewModels.Employees;
    using FastFood.Web.ViewModels.Items;
    using FastFood.Web.ViewModels.Orders;
    using Models;

    using ViewModels.Positions;

    public class FastFoodProfile : Profile
    {
        public FastFoodProfile()
        {
            //Positions
            this.CreateMap<CreatePositionInputModel, Position>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.PositionName));

            this.CreateMap<Position, PositionsAllViewModel>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.Name));

            //Employees
            this.CreateMap<Position, RegisterEmployeeViewModel>()
                .ForMember(x => x.PositionName, y => y.MapFrom(z => z.Name));

            this.CreateMap<RegisterEmployeeInputModel, Employee>();
                
            this.CreateMap<Employee, EmployeesAllViewModel>()
                .ForMember(x => x.Position, y => y.MapFrom(z => z.Position.Name));

            //Categories
            this.CreateMap<CreateCategoryInputModel, Category>()
               .ForMember(x => x.Name, y => y.MapFrom(z => z.CategoryName));

            this.CreateMap<Category, CategoryAllViewModel>();

            //Items
            this.CreateMap<Category, CreateItemViewModel>()
                 .ForMember(x => x.CategoryName, y => y.MapFrom(z => z.Name));

            this.CreateMap<CreateItemInputModel, Item>();

            this.CreateMap<Item, ItemsAllViewModels>()
                .ForMember(x => x.Category, y => y.MapFrom(z => z.Category.Name));

            //Orders
            this.CreateMap<CreateOrderInputModel, Order>();

            this.CreateMap<Order, OrderAllViewModel>()
                .ForMember(x => x.TotalPrice, y => y.MapFrom(z => z.TotalPrice))
                .ForMember(x => x.OrderId, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Employee, y => y.MapFrom(z => z.Employee.Name))
                .ForMember(x => x.DateTime, y => y.MapFrom(z => z.DateTime.ToString("dd-MMMM-yyyy HH:mm")));
        }
    }
}
