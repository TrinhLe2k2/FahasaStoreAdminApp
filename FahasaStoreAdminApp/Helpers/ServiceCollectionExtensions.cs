using System.Reflection;

namespace FahasaStoreAdminApp.Helpers
{
    public static class ServiceCollectionExtensions
    {
        public static void AddScopedServicesFromAssembly(this IServiceCollection services, Assembly assembly, string serviceNamespace)
        {
            var serviceTypes = assembly.GetTypes()
                .Where(t => t.IsClass && t.Namespace == serviceNamespace && !t.IsAbstract)
                .Select(t => new
                {
                    Service = t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name),
                    Implementation = t
                })
                .Where(t => t.Service != null && t.Implementation != null); // Ensure both Service and Implementation are not null

            foreach (var serviceType in serviceTypes)
            {
                // Adding a null check to avoid null reference exception
                if (serviceType.Service != null)
                {
                    services.AddScoped(serviceType.Service, serviceType.Implementation);
                }
            }
        }
    }

}
