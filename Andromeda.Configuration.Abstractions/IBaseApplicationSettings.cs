using System.ComponentModel;
using System.Configuration;

namespace Andromeda.Configuration.Abstractions
{
    public interface IBaseApplicationSettings : INotifyPropertyChanged
    {
        event SettingChangingEventHandler? SettingChanging;

        event SettingsLoadedEventHandler SettingsLoaded;

        event SettingsSavingEventHandler SettingsSaving;

        object GetPreviousVersion(string propertyName);

        void Reload();

        void Reset();

        void Save();

        void Upgrade();
    }
}
