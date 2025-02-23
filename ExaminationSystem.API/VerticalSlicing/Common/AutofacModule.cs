using Autofac;
using AutoMapper;
using ExaminationSystem.API.VerticalSlicing.Common.DTOs;
using ExaminationSystem.API.VerticalSlicing.Common.MapperProfile;
using ExaminationSystem.API.VerticalSlicing.Data;
using ExaminationSystem.API.VerticalSlicing.Data.BaseRepository;

namespace ExaminationSystem.API.VerticalSlicing.Common
{
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

            builder.RegisterType<ControllereParameters>().InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(RequestParameters<>)).InstancePerLifetimeScope();


        }
    }
}
