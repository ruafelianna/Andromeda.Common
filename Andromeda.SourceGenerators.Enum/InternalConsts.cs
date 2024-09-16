using static Andromeda.CSharp.Consts.Postfixes;

namespace Andromeda.SourceGenerators.Enum
{
    internal class InternalConsts
    {
        public const string NS_Local
            = $"{nameof(Andromeda)}.{nameof(SourceGenerators)}.{nameof(Enum)}";

        public const string A_HasConstStrings
            = "HasConstStrings";

        public const string A_HasConstStringsFull
            = $"{A_HasConstStrings}{POST_Attribute}";

        public const string P_HasConstStrings_ConstClass
            = "ConstClass";

        public const string P_HasConstStrings_ConstNamespace
            = "ConstNamespace";

        public const string P_HasConstStrings_ExtClass
            = "ExtClass";

        public const string P_HasConstStrings_ExtNamespace
            = "ExtNamespace";

        public const string M_AsString
            = "AsString";

        public const string POST_Dict = "Dict";

        public const string POST_Extensions = "Extensions";

        public const string PropTab = "                ";

        public const string NewLine = "\r\n";
    }
}
