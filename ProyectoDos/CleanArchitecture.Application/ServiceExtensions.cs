using CleanArchitecture.Application.Common.Behaviors;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CleanArchitecture.Application
{
    /// <summary>
    /// Provides extension methods for configuring services in the application.
    /// </summary>
    public static class ServiceExtensions
    {
        /// <summary>
        /// Configures application services by adding AutoMapper, MediatR, FluentValidation validators,
        /// and the validation behavior pipeline to the specified <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to configure.</param>
        public static void ConfigureApplication(this IServiceCollection services)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            // Adds AutoMapper services to the service collection from the current assembly.
            services.AddAutoMapper(assembly);

            // Registers MediatR services from the current assembly.
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));

            // Registers FluentValidation validators from the current assembly.
            services.AddValidatorsFromAssembly(assembly);

            // Registers the validation behavior pipeline for handling validation in requests.
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        }
    }
}
