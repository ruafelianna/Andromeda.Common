using Andromeda.Localization.Abstractions;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reactive.Linq;
using System.Reflection;
using Tommy;

namespace Andromeda.Localization
{
    public class TranslationProvider : ReactiveObject, ITranslationProvider
    {
        public TranslationProvider(Assembly assembly, string path)
        {
            Culture = CultureInfo.CurrentUICulture;
            Assembly = assembly;
            Path = path.Replace('\\', '.').Replace('/', '.');

            this
                .WhenAnyValue(o => o.Culture)
                .Select(culture =>
                {
                    var respath = Assembly
                        .GetManifestResourceNames()
                        .FirstOrDefault(resName =>
                            resName == $"{Assembly.GetName().Name}{Path}.{culture.Name}.toml"
                        );

                    if (respath is null)
                    {
                        return null;
                    }

                    using var reader = new StreamReader(
                        Assembly.GetManifestResourceStream(respath)!
                    );

                    return TOML.Parse(reader).AsTable.RawTable
                        .Select(pair => new KeyValuePair<string, string?>(
                            pair.Key,
                            pair.Value
                        ))
                        .ToFrozenDictionary();
                })
                .ToPropertyEx(this, o => o.Translation);
        }

        [Reactive]
        public CultureInfo Culture { get; set; }

        public string Path { get; }

        public Assembly Assembly { get; }

        [ObservableAsProperty]
        public IDictionary<string, string?>? Translation { get; }
    }
}
