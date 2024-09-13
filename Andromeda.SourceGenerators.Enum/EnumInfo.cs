using System.Collections.Immutable;

namespace Andromeda.SourceGenerators.Enum
{
    internal record EnumInfo(
        string EnumName,
        string EnumNamespace,
        ImmutableArray<string> EnumItems,
        string ClassName,
        string ClassNamespace,
        string ExtName,
        string ExtNamespace
    );
}
