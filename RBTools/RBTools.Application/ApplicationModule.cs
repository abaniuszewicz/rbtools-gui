using Autofac;
using RBTools.Application.Commands;
using RBTools.Application.Communication.DTO;
using RBTools.Application.Communication.Mapping;
using RBTools.Application.Config;
using RBTools.Domain.Commands;

namespace RBTools.Application
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<Configuration>().As<IConfiguration>().SingleInstance();
            builder.RegisterType<ConfigurationMemento>().As<IConfigurationMemento>();
            builder.RegisterType<PostCommandIssuer>().AsSelf().SingleInstance();
            builder.RegisterType<PostCommandDtoMapper>().As<IMapper<RbtPostDto, PostCommand>>();
        }
    }
}
