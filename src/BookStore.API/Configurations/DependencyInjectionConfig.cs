using BookStore.Domain.Interfaces;
using BookStore.Domain.Services;
using BookStore.Infrastructure.Context;
using BookStore.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BookStore.API.Configurations;

public static class DependencyInjectionConfig
{
    public static IServiceCollection ResolveDependencies(this IServiceCollection services)
    {
        // services.AddScoped<BookStoreDbContext>();

        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IBookRepository, BookRepository>();

        services.AddScoped<IBookService, BookService>();
        services.AddScoped<ICategoryService, CategoryService>();

        return services;
    }
}