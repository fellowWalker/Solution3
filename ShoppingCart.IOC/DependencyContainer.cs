﻿using Microsoft.Extensions.DependencyInjection;
using ShoppingCart.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using ShoppingCart.Data.Repositories;
using ShoppingCart.Application.Interfaces;
using ShoppingCart.Application.Services;
using ShoppingCart.Data.Context;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using ShoppingCart.Application.AutoMapper;

namespace ShoppingCart.IOC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ShoppingCartDbContext>(options =>
                options.UseSqlServer(connectionString )
                );

            services.AddScoped<IProductsRepository, ProductsRepository>();
            services.AddScoped<IProductsService, ProductsService>();

            services.AddScoped<ICategoriesRepository, CategoriesRepository>();
            services.AddScoped<ICategoriesService, CategoriesService>();

            services.AddScoped<IMembersRepository, MembersRepository>();
            services.AddScoped<IMembersService, MembersService>();

            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<ICartService, CartService>();

            services.AddScoped<ICartProductRepository, CartProductRepository>();
            services.AddScoped<ICartProductService, CartProductService>();

            services.AddAutoMapper(typeof(AutoMapperConfiguration));
            AutoMapperConfiguration.RegisterMappings();

        }
    }
}
