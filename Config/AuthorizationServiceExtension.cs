namespace AuthenticationAndAuthorization.Config
{
    public static class AuthorizationServiceExtension
    {
        public static void AddLocalAuthorization(this IServiceCollection Services)
        {
            Services.AddAuthorization(options =>
            {
                options.AddPolicy("RequireAdministratorRole", policy => policy.RequireRole("Administrator"));
                options.AddPolicy("FemaleOnly", policy => policy.RequireClaim("genero", "Femenino"));
            });
        }
    }
}
