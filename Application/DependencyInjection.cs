using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;


namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection service)
        {
            var assembly = typeof(DependencyInjection).Assembly;
            service.AddMediatR(configuration =>
                configuration.RegisterServicesFromAssemblies(assembly)
            );
            service.AddValidatorsFromAssembly(assembly);
            return service;
        }
    }
}
