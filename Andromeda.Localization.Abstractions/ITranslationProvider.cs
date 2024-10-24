using System.Collections.Generic;
using System.Globalization;

namespace Andromeda.Localization.Abstractions
{
    public interface ITranslationProvider
    {
        CultureInfo Culture { get; set; }

        CultureInfo InvariantCulture { get; }

        IDictionary<string, string?>? Translation { get; }

        IDictionary<string, string?>? InvariantTranslation { get; }
    }
}
