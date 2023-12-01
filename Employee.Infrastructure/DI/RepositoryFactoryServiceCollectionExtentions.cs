using System;
using System.Collections.Generic;
using System.Text;
using Employee.Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Employee.Infrastructure.Data.DependencyInjection
{
  public static  class RepositoryFactoryServiceCollectionExtentions
    {
        public static IServiceCollection AddRepositoryFactory<TContext>(this IServiceCollection services)
        {
            services.AddTransient<IApiRepositoryFactory, ApiRepositoryFactory>();
            return services;
        }
    }
}
