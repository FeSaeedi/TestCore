using DryIoc;
using System;
using System.Linq;

namespace Core.Config.DryIoc
{
    public static class DryIocAssemblyRegistration
    {
        public static void RegisterByAssemblyAndType<T>(this IContainer container, string assemblyName)
        {
            AppDomain.CurrentDomain.Load(assemblyName);
            var assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(a => a.GetName().Name.Contains(assemblyName));
            container.RegisterMany(assemblies,
                type => type.IsAssignableTo(typeof(T)), Reuse.Transient);

        }

        public static void RegisterByAssemblyAndType<T1, T2>(this IContainer container, string assemblyName)
        {
            container.RegisterByAssemblyAndType<T1>(assemblyName);
            container.RegisterByAssemblyAndType<T2>(assemblyName);

        }

    }
}
