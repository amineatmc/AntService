﻿using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Business.VerimorOtp;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
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

            builder.RegisterType<TravelHistoryManager>().As<ITravelHistoryService>();
            builder.RegisterType<EfTravelHistoryDal>().As<ITravelHistoryDal>();

            builder.RegisterType<DriverManager>().As<IDriverService>();
            builder.RegisterType<EfDriverDal>().As<IDriverDal>();

            builder.RegisterType<PassengerManager>().As<IPassengerService>();
            builder.RegisterType<EfPassengerDal>().As<IPassengerDal>();

            builder.RegisterType<DriverRequestManager>().As<IDriverRequestService>();
            builder.RegisterType<EfDriverRequestDal>().As<IDriverRequestDal>();

            builder.RegisterType<PassengerRequestManager>().As<IPassengerRequestService>();
            builder.RegisterType<EfPassengerRequestDal>().As<IPassengerRequestDal>();

            builder.RegisterType<StationRequestManager>().As<IStationRequestService>();
            builder.RegisterType<EfStationRequestDal>().As<IStationRequestDal>();

            builder.RegisterType<PaymentTypeManager>().As<IPaymentTypeService>();
            builder.RegisterType<EfPaymentTypeDal>().As<IPaymentTypeDal>();

            builder.RegisterType<ReservationManager>().As<IReservationService>();
            builder.RegisterType<EfReservationDal>().As<IReservationDal>();

            builder.RegisterType<VehicleManager>().As<IVehicleService>();
            builder.RegisterType<EfVehicleDal>().As<IVehicleDal>();

            builder.RegisterType<DriverVehicleManager>().As<IDriverVehicleService>();
            builder.RegisterType<EfDriverVehicleDal>().As<IDriverVehicleDal>();

            builder.RegisterType<VehicleOwnerManager>().As<IVehicleOwnerService>();
            builder.RegisterType<EfVehicleOwnerDal>().As<IVehicleOwnerDal>();

            builder.RegisterType<ChatManager>().As<IChatService>();
            builder.RegisterType<EfChatDal>().As<IChatDal>();

            builder.RegisterType<StationVehicleManager>().As<IStationVehicleService>();
            builder.RegisterType<EfStationVehicleDal>().As<IStationVehicleDal>();

            builder.RegisterType<StationManager>().As<IStationService>();
            builder.RegisterType<EfStationDal>().As<IStationDal>();

            builder.RegisterType<VoipManager>().As<IVoipService>();
            builder.RegisterType<EfVoipDal>().As<IVoipDal>();

            builder.RegisterType<VehicleOwnerVehicleManager>().As<IVehicleOwnerVehicleService>();
            builder.RegisterType<EfVehicleOwnerVehicleDal>().As<IVehicleOwnerVehicleDal>();


            builder.RegisterType<ScoreManager>().As<IScoreService>();
            builder.RegisterType<EfScoreDal>().As<IScoreDal>();

            builder.RegisterType<CancelTextManager>().As<ICancelTextService>();
            builder.RegisterType<EfCancelTextDal>().As<ICancelTextDal>();

            builder.RegisterType<DriverCancelTravelManager>().As<IDriverCancelTravelService>();
            builder.RegisterType<EfDriverCancelTravelDal>().As<IDriverCancelTravelDal>();

            builder.RegisterType<PassengerCancelTravelManager>().As<IPassengerCancelTravelService>();
            builder.RegisterType<EfPassengerCancelTravelDal>().As<IPassengerCancelTravelDal>();

            builder.RegisterType<RecipeManager>().As<IRecipeService>();
            builder.RegisterType<EfRecipeDal>().As<IRecipeDal>();

            builder.RegisterType<PermitImageManager>().As<IPermitImageService>();
            builder.RegisterType<EfPermitImageDal>().As<IPermitImageDal>();

            builder.RegisterType<FileManager>().As<IFileService>();


            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().EnableInterfaceInterceptors(new ProxyGenerationOptions()
            {
                Selector = new AspectInterceptorSelector()
            }).SingleInstance();
        }
    }
}
