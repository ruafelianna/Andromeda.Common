using Andromeda.Localization.Abstractions;
using ReactiveUI.Fody.Helpers;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using Tommy;

namespace Andromeda.Localization
{
    public class TranslationProvider : ITranslationProvider
    {
        public TranslationProvider(Assembly assembly, string path)
        {
            Culture = CultureInfo.CurrentUICulture;
            Assembly = assembly;
            Path = path;
        }

        [Reactive]
        public CultureInfo Culture { get; set; }

        public string Path { get; }

        public Assembly Assembly { get; }

        public string? GetTranslation(
            ITranslationUnit unit,
            CultureInfo culture
        )
        {
            if (culture != Culture)
            {
                var respath = Assembly
                .GetManifestResourceNames()
                .FirstOrDefault(name => name == Path);

                if (respath is null)
                {
                    return null;
                }

                using var reader = new StreamReader(
                    Assembly.GetManifestResourceStream(respath)!
                );

                _translation = TOML.Parse(reader).AsTable.RawTable;
            }

            return _translation![unit.Key];
        }

        private Dictionary<string, TomlNode>? _translation;
    }
}
