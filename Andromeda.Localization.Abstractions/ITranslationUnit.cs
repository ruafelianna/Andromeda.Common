namespace Andromeda.Localization.Abstractions
{
    public interface ITranslationUnit
    {
        string Key { get; }

        string? Value { get; }
    }
}
