using System;

namespace RBTools.Application.Config
{
    public interface IConfigurationMemento : IConfiguration
    {
        public bool HasStateChanged(IEquatable<IConfiguration> current);
    }
}
