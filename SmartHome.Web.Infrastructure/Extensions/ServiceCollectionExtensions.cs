using Microsoft.Extensions.DependencyInjection;
using SmartHome.Data.Models;
using SmartHome.Data.Repository;
using SmartHome.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Web.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterRepositories(this IServiceCollection services, Assembly modelAssembly)
        {
            Type[] typeToExclude = new Type[] { typeof(ApplicationUser) };

            Type[] modelTypes = modelAssembly
                .GetTypes()
                .Where(t => !t.IsAbstract && !t.IsInterface && !t.Name.ToLower().EndsWith("attribute"))
                .ToArray();

            foreach (Type type in modelTypes) 
            {
                if (!typeToExclude.Contains(type))
                {
                    Type repositoryInterface = typeof(IRepository<,>);
                    Type repositoryInstanceType = typeof(Repository<,>);
                    PropertyInfo? idPropInfo = type
                        .GetProperties()
                        .Where(p => p.Name.ToLower() == "id")
                        .SingleOrDefault();

                    Type[] constructArgs = new Type[2];
                    constructArgs[0] = type;

                    if (idPropInfo == null)
                    {
                        constructArgs[1] = typeof(object);
                    }
                    else
                    {
                        constructArgs[1] = idPropInfo.PropertyType;
                    }
                    repositoryInterface = repositoryInterface.MakeGenericType(constructArgs);
                    repositoryInstanceType = repositoryInstanceType.MakeGenericType(constructArgs);
                    services.AddScoped(repositoryInterface, repositoryInstanceType);
                }
            }
        }

        public static void AddServices(this IServiceCollection serviceCollection, Assembly serviceAssembly)
        {
            Type[] interfaceTypes = serviceAssembly
                .GetTypes()
                .Where(t => t.IsInterface)
                .ToArray();

            Type[] types = serviceAssembly
                .GetTypes()
                .Where(t => !t.IsInterface && !t.IsAbstract && t.Name.ToLower().EndsWith("service"))
                .ToArray();

            foreach (Type interfType in interfaceTypes)
            {
                Type? serType = types
                    .SingleOrDefault(t => "i" + t.Name.ToLower() == interfType.Name.ToLower());

                if (serType == null)
                {
                    throw new NullReferenceException($"Type could not be obtained for service {interfType.Name}");
                }

                serviceCollection.AddScoped(interfType, serType);
            }
        }
    }
}
