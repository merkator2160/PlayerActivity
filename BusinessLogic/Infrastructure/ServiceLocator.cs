using Microsoft.Practices.Unity;
using PlayerActivity.BusinessLogic.Interfaces;
using System;

namespace PlayerActivity.BusinessLogic.Infrastructure
{
    public sealed class ServiceLocator : IDisposable
    {
        private Boolean _disposed;
        private readonly IUnityContainer _container;


        public ServiceLocator()
        {
            _container = UnityConfig.GetConfiguredContainer();
        }
        ~ServiceLocator()
        {
            Dispose(false);
        }


        // PROPERTIES /////////////////////////////////////////////////////////////////////////////
        public IActivityService ActivityService => _container.Resolve<IActivityService>();


        // IDisposable ////////////////////////////////////////////////////////////////////////////
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private void Dispose(Boolean disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _container?.Dispose();
                }

                _disposed = true;
            }
        }
    }
}