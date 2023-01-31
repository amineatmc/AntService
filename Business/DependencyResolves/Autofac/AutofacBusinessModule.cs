using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Business.VerimorOtp;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolves.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<AllUserManager>().As<IAllUserService>();
            builder.RegisterType<EfAllUser>().As<IAllUser>();

            builder.RegisterType<EfBoundaryDal>().As<IBoundaryDal>();
            builder.RegisterType<BoundaryManager>().As<IBoundaryService>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().EnableInterfaceInterceptors(new ProxyGenerationOptions()
            {
                Selector = new AspectInterceptorSelector()
            }).SingleInstance();
        }
    }
}
