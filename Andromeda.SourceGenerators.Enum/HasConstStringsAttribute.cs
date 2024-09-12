using System;

namespace Andromeda.SourceGenerators.Enum
{
    [AttributeUsage(AttributeTargets.Enum)]
    public class HasConstStringsAttribute : Attribute
    {
        public string? ConstNamespace { get; init; }

        public string? ConstClass { get; init; }
    }
}
