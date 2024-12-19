using Microsoft.AspNetCore.Mvc;

namespace WebApi.Extensions
{
    /// <summary>
    /// Provides extension methods for configuring API behavior options.
    /// </summary>
    public static class ApiBehaviorExtensions
    {
        /// <summary>
        /// Configures API behavior options to suppress the default model state invalid filter.
        /// </summary>
        /// <param name="services">The collection of services to configure.</param>
        public static void ConfigureApiBehavior(this IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(options =>
            {
                // Suppress the automatic model state invalid filter
                options.SuppressModelStateInvalidFilter = true;
            });
        }
    }
}
