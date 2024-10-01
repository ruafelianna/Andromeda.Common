using Andromeda.Configuration.Abstractions;
using System.Configuration;

namespace Andromeda.Configuration
{
    public abstract class BaseApplicationSettings :
        ApplicationSettingsBase,
        IBaseApplicationSettings
    {
        protected BaseApplicationSettings() : base()
        {
        }
    }
}
