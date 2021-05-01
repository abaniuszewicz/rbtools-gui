using Autofac;
using RBTools.Application.Configuration;
using RBTools.Infrastructure.Persistence.IO;
using RBTools.Infrastructure.Persistence.IO.TempFiles;
using RBTools.Infrastructure.Persistence.Serialization;
using RBTools.Infrastructure.Persistence.Settings;

namespace RBTools.Infrastructure.Persistence
{
    public class PersistenceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<JsonSerializer>().As<ISerializer>();
            builder.RegisterType<JsonFileManager>().As<IFileManager>();
            builder.RegisterType<SettingsManager>().As<ISettingsManager>();
            builder.RegisterType<TempFile>().As<ITempFile>();
            builder.RegisterType<TempFileProvider>().As<ITempFileProvider>();
        }
    }
}
