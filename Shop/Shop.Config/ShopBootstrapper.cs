using Microsoft.Extensions.DependencyInjection;
using Shop.Application._Utilities;
using Shop.Domain.CategoryAgg.Services;
using Shop.Domain.ProductAgg.Services;
using Shop.Domain.UserAgg.Services;
using Shop.Domain.SellerAgg.Services;
using Shop.Infrastructure;
using Shop.Query.Categories.GetById;
using Shop.Application.Products;
using Shop.Application.Categories;
using Shop.Application.Users;
using Shop.Application.Roles.Create;
using FluentValidation;
using MediatR;
using Shop.Application.Sellers;
using Shop.Presentation.Facade;


namespace Shop.Config;

public static class ShopBootstrapper
{
    public static void RegisterShopDependency(this IServiceCollection services, string connectionString)
    {
        InfrastructureBootstrapper.Init(services, connectionString);

        //services.AddMediatR(typeof(Directories).Assembly);

        //services.AddMediatR(typeof(GetCategoryByIdQuery).Assembly);

        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(Directories).Assembly);
            cfg.RegisterServicesFromAssembly(typeof(GetCategoryByIdQuery).Assembly);
        });

        services.AddTransient<IProductDomainService, ProductDomainService>();
        services.AddTransient<IUserDomainService, UserDomainService>();
        services.AddTransient<ICategoryDomainService, CategoryDomainService>();
        services.AddTransient<ISellerDomainService, SellerDomainService>();


        services.AddValidatorsFromAssembly(typeof(CreateRoleCommandValidator).Assembly);

       services.InitFacadeDependency();
    }
}


