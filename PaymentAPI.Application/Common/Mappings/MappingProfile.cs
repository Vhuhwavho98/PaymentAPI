using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PaymentAPI.Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            ApplyMappingFromAssembly(Assembly.GetExecutingAssembly());
        }

        public void ApplyMappingFromAssembly(Assembly assembly)
        {
            var mapFromType = typeof(IMapForm<>);
            var mappingMethodName = nameof(IMapForm<object>.Mapping);
            bool hasInterfaces(Type type) => type.IsGenericType && type.GetGenericTypeDefinition() == mapFromType;

            var types = assembly.GetExportedTypes()
                                .Where(t => t.GetInterfaces().Any(hasInterfaces))
                                .ToList();

            var argumentTypes = new Type[] { typeof(Profile) };

            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);
                var methodInfo = type.GetMethod(mappingMethodName);

                if (methodInfo != null)
                {
                    methodInfo.Invoke(instance, new object[] { this });
                }
                else
                {
                    var interfaces = type.GetInterfaces().Where(hasInterfaces).ToList();
                    if (interfaces.Count > 0)
                    {
                        foreach (var @interface in interfaces)
                        {
                            var interfaceMethodInfo = @interface.GetMethod(mappingMethodName, argumentTypes);
                            interfaceMethodInfo?.Invoke(instance, new object[] { this });
                        }
                    }
                }
            }
        }
    }
}

