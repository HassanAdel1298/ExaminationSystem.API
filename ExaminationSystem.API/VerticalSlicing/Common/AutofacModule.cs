using Autofac;
using AutoMapper;
using ExaminationSystem.API.VerticalSlicing.Common.DTOs;
using ExaminationSystem.API.VerticalSlicing.Common.MapperProfile;
using ExaminationSystem.API.VerticalSlicing.Data;
using ExaminationSystem.API.VerticalSlicing.Data.BaseRepository;
using MediatR;

namespace ExaminationSystem.API.VerticalSlicing.Common
{
    public delegate object ServiceFactory(Type serviceType);
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();

            builder.RegisterType<Context>().InstancePerLifetimeScope();

            builder.Register(context => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<UserProfile>();
                cfg.AddProfile<QuizProfile>();
            }).CreateMapper()).As<IMapper>().InstancePerLifetimeScope();

            builder.RegisterType<UserState>().InstancePerLifetimeScope();

            builder.RegisterType<Mediator>().As<IMediator>().InstancePerLifetimeScope();
            
            builder.Register<ServiceFactory>(ctx =>
            {
                var c = ctx.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            }).InstancePerLifetimeScope();

            builder.RegisterType<ControllereParameters>().InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(RequestParameters<>)).InstancePerLifetimeScope();

        }
    }
}
