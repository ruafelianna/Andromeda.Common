using static Andromeda.CSharp.Consts.Postfixes;

namespace Andromeda.SourceGenerators.Enum
{
    internal class InternalConsts
    {
        public const string NS_Local
            = $"{nameof(Andromeda)}.{nameof(SourceGenerators)}.{nameof(Enum)}";

        public const string A_HasStrings
            = "HasStrings";

        public const string A_HasStringsFull
            = $"{A_HasStrings}{POST_Attribute}";

        public const string P_HasStrings_StringsClass
            = "StringsClass";

        public const string P_HasStrings_StringsNamespace
            = "StringsNamespace";

        public const string P_HasStrings_ExtClass
            = "ExtClass";

        public const string P_HasStrings_ExtNamespace
            = "ExtNamespace";

        public const string P_HasStrings_GenerateFunctions
            = "GenerateFunctions";

        public const string M_AsString
            = "AsString";

        public const string POST_Dict = "Dict";

        public const string POST_Extensions = "Extensions";

        public const string PropTab = "                ";

        public const string NewLine = "\r\n";
    }
}
