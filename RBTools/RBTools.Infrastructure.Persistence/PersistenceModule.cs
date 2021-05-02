using Autofac;
using RBTools.Application.Config;
using RBTools.Infrastructure.Persistence.IO;
using RBTools.Infrastructure.Persistence.IO.TempFiles;
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
            builder.RegisterType<SettingsManager>().As<IConfigurationManager>();
            builder.RegisterType<TempFile>().As<ITempFile>();
            builder.RegisterType<TempFileProvider>().As<ITempFileProvider>();
        }
    }
}
