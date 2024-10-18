using System.Globalization;

namespace Andromeda.Localization.Abstractions
{
    public interface ITranslationProvider
    {
        CultureInfo Culture { get; set; }

        string? GetTranslation(
            ITranslationUnit unit,
            CultureInfo culture
        );
    }
}
