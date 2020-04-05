using DryIoc;
using LibCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Config.DryIoc
{
    public class DryIocServiceLocator : IServiceLocator
    {
        private readonly IContainer container;

        public DryIocServiceLocator(IContainer container)
        {
            this.container = container;
        }
        public object GetService(Type serviceType)
        {
            return container.Resolve(serviceType);
        }

        public object GetInstance(Type serviceType)
        {
            return container.Resolve(serviceType);
        }

        public object GetInstance(Type serviceType, string key)
        {
            if (key != null)
                return container.Resolve(serviceType, key);
            return container.Resolve(serviceType);
        }

        public IEnumerable<object> GetAllInstances(Type serviceType)
        {
            return (object[])container.ResolveMany(serviceType);
        }

        public TService GetInstance<TService>()
        {
            return container.Resolve<TService>();
        }

        public TService GetInstance<TService>(string key)
        {
            if (key != null)
                return container.Resolve<TService>(key);
            return container.Resolve<TService>();
        }

        public IEnumerable<TService> GetAllInstances<TService>()
        {
            return container.ResolveMany<TService>();
        }

        public bool IsRegistered<TService>()
        {
            return container.IsRegistered<TService>();
        }

        public bool IsRegistered(Type serviceType)
        {
            return container.IsRegistered(serviceType);
        }

        public void Release(object instance)
        {

        }
    }
}
