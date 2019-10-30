using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace BlazingProjects.Website.Helpers
{
    public class ScopeControl
    {

        private readonly IServiceProvider _serviceProvider;

        private IServiceScope _serviceScope;

        public ScopeControl(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public T GetService<T>()
        {
            if (_serviceScope == null)
                _serviceScope = _serviceProvider.CreateScope();
            return _serviceScope.ServiceProvider.GetService<T>();
        }

        public void ClearScope()
        {
            _serviceScope.Dispose();
            _serviceScope = null;
        }
    }
}
