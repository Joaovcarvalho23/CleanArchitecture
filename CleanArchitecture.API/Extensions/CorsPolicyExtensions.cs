namespace CleanArchitecture.API.Extensions
{
    public static class CorsPolicyExtensions
    {
        public static void ConfigureCorsPolicy(this IServiceCollection services)//estamos definindo um método de defenção ConfigureCorsPolicy 
        {
            services.AddCors(opt =>
            {
                opt.AddDefaultPolicy(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            });//este código está adicionando uma política CORS (Cross-Origin Resource Sharing) no nosso serviço. Este código define uma política padrão 
        }
    }
}
