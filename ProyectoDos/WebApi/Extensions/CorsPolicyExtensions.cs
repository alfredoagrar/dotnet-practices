namespace WebApi.Extensions
{
    /// <summary>
    /// Provides extension methods for configuring CORS (Cross-Origin Resource Sharing) policies.
    /// </summary>
    public static class CorsPolicyExtensions
    {
        /// <summary>
        /// Configures the default CORS policy to allow any origin, method, and header.
        /// </summary>
        /// <param name="services">The collection of services to configure.</param>
        public static void ConfigureCorsPolicy(this IServiceCollection services)
        {
            services.AddCors(opt =>
            {
                opt.AddDefaultPolicy(builder => builder
                    .AllowAnyOrigin()  // Allows requests from any origin
                    .AllowAnyMethod()  // Allows any HTTP method (GET, POST, etc.)
                    .AllowAnyHeader()); // Allows any HTTP header
            });
        }
    }
}
