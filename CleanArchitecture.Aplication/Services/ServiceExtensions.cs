using CleanArchitecture.Aplication.Shared.Behavior;
using FluentValidation;
using MediatR;
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

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>)); //devemos incluir o registro de pipeline de comportamento de validação no mecanismo de tratamento de comando e consultas. O IPipelineBehavior é a interface genérica e representa o comportamento, que será aplicado ao comando e consulta. O ValidationBehavior é a classe que tá implementando a interface, ou seja, é a classe que implementa a validação, que vai ser executada nos comandos ANTES dos comando serem processados. 
            //Estamos definindo o tempo de vida AddTransient, pois um pipeline de Behavior geralmente não se deve manter estado entre os requests. Então cada request de comando 'consulta' deve ser tratada de forma independente e não deve compartilhar estado entre as solicitações. Então, quando usamos AddTransient, uma nova instância de ValidationBehavior vai ser criada cada vez que um request de comando 'consulta' for processado, garantindo o isolamento e segurança contra problemas de concorrência. 
        }
    }
}
