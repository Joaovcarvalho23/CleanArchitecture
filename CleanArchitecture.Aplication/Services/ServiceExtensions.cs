using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Aplication.Services
{
    public static class ServiceExtensions
    {
        public static void ConfigureApplicationApp(this IServiceCollection services) //método de extensão, extende de IServiceCollection e tá registrando os serviços do AddAutoMapper, AddMediatR e AddValidatorsFromAssembly
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());//ele tá especificando que o serviço de cada um desses recursos deve ser configurados para atuarem dentro do Assembly, onde o método está sendo definido. 
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
