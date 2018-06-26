using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Loader;
using System.Text;

namespace Scutor.AspnetCore.Wireup
{
    /// <summary>
    /// Extension methods for Service scanning
    /// </summary>
    public static class ServiceScanner
    {
        /// <summary>
        /// Extension method for wireup assemblies with transient lifetime based on dlls in context folder and with given pattern
        /// </summary>
        /// <param name="services">Main services</param>
        /// <param name="context">Main Assembly for beeing searched</param>
        /// <param name="pattern">Pattern for assembly searching </param>
        public static void WireupTransient(this IServiceCollection services,Assembly context,string pattern = "*")
        {
            var allAssemblies = getAssemplies(context, pattern);
            services.Scan(scan => {
                scan.FromAssemblies(allAssemblies)
                .AddClasses()
                .AsImplementedInterfaces()
                .WithTransientLifetime();
            });
        }

        /// <summary>
        /// Extension method for wireup assemblies with scoped lifetime based on dlls in context folder and with given pattern
        /// </summary>
        /// <param name="services">Main services</param>
        /// <param name="context">Main Assembly for beeing searched</param>
        /// <param name="pattern">Pattern for assembly searching </param>
        public static void WireupScoped(this IServiceCollection services, Assembly context, string pattern = "*")
        {
            var allAssemblies = getAssemplies(context, pattern);
            services.Scan(scan => {
                scan.FromAssemblies(allAssemblies)
                .AddClasses()
                .AsImplementedInterfaces()
                .WithScopedLifetime();
            });
        }

        /// <summary>
        /// Extension method for wireup assemblies with singleton lifetime based on dlls in context folder and with given pattern
        /// </summary>
        /// <param name="services">Main services</param>
        /// <param name="context">Main Assembly for beeing searched</param>
        /// <param name="pattern">Pattern for assembly searching </param>
        public static void WireupSingleton(this IServiceCollection services, Assembly context, string pattern = "*")
        {
            var allAssemblies = getAssemplies(context, pattern);
            services.Scan(scan => {
                scan.FromAssemblies(allAssemblies)
                .AddClasses()
                .AsImplementedInterfaces()
                .WithSingletonLifetime();
            });
        }

        /// <summary>
        /// Search directory to find assemblies
        /// </summary>
        /// <param name="services">Main services</param>
        /// <param name="context">Main Assembly for beeing searched</param>
        /// <returns>List of founded assemblies</returns>
        private static IEnumerable<Assembly> getAssemplies(Assembly context, string pattern)
        {
            var currentAssemblyPath = System.IO.Path.GetDirectoryName(context.Location);
            var allAssemblies = new List<Assembly>();
            var alldllFiles = System.IO.Directory.GetFiles(currentAssemblyPath, pattern);
            foreach (var item in alldllFiles)
            {
                try
                {
                    var assembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(item);
                    allAssemblies.Add(assembly);
                }
                catch (System.Exception ex)
                {
                    Console.Write("Error " + ex.Message);
                }
            }
            return allAssemblies;
        }
    }
}
