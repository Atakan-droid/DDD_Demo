using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application
{
    public static class ServiceRegister
    {
        public static void ApplicationServiceRegister(this IServiceCollection serviceDescriptors)
        {
            var assm = Assembly.GetExecutingAssembly();
            serviceDescriptors.AddMediatR(assm);
        }
    }
}
