﻿using E_Commerce.Application.Contracts.Infrastructure;
using E_Commerce.Application.Models;
using E_Commerce.Infrastructure.Mail;
using E_Commerce.Infrastructure.PasswordHash;
using E_Commerce.Infrastructure.Payment;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Infrastructure
{
    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();

            return services;
        }
    }
}
