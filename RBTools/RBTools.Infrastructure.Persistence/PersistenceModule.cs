using Autofac;
using RBTools.Application.Config;
using RBTools.Application.Config.IOAbstractions;
using RBTools.Infrastructure.Persistence.IO;
using RBTools.Infrastructure.Persistence.Serialization;

namespace RBTools.Infrastructure.Persistence
{
    public class PersistenceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<JsonSerializer>().As<ISerializer>();
            builder.RegisterType<JsonFileLoadSave>().As<IFileLoadSave>();
            builder.RegisterType<ConfigurationManager>().As<IConfigurationManager>();
            builder.RegisterType<File>().As<IFile>();
            builder.RegisterType<TempFileProvider>().As<ITempFileProvider>();
        }
    }
}
