namespace AuthenticationAndAuthorization.Config
{
    public static class CorsServiceExtension
    {
        public static void AddAllowedCors(this IServiceCollection Services, string corsName)
        {
            Services.AddCors(options =>
            {
                options.AddPolicy(corsName,
                    builder =>
                    {
                        builder.AllowAnyOrigin();
                        builder.AllowAnyMethod();
                        builder.AllowAnyHeader();
                    });
            });
        }
    }
}
