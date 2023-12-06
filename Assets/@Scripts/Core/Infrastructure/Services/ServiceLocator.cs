using System;

namespace Core.Infrastructure.Services
{
    public class ServiceLocator
    {
        private static readonly Lazy<ServiceLocator> LazyLoader = new Lazy<ServiceLocator>(() => new ServiceLocator());
        public static ServiceLocator Container => LazyLoader.Value;

        public void RegisterSingle<TService>(TService implementation) where TService : IService =>
            Implementation<TService>.ServiceInstance = implementation;

        public TService Single<TService>() where TService : IService =>
            Implementation<TService>.ServiceInstance;

        private class Implementation<TService> where TService : IService
        {
            public static TService ServiceInstance;
        }
    }
}