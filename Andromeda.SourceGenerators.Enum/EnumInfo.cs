using System.Collections.Immutable;

namespace Andromeda.SourceGenerators.Enum
{
    internal record EnumInfo(
        string EnumName,
        string EnumNamespace,
        string ClassName,
        string ClassNamespace,
        ImmutableArray<string> EnumItems
    );
}
