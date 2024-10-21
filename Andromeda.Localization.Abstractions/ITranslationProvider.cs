using System.Collections.Generic;
using System.Globalization;

namespace Andromeda.Localization.Abstractions
{
    public interface ITranslationProvider
    {
        CultureInfo Culture { get; set; }

        IDictionary<string, string?>? Translation { get; }
    }
}
