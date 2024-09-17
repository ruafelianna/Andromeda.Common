namespace Andromeda.CSharp.Consts
{
    /// <summary>
    /// <seealso href="https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/access-modifiers"/>
    /// </summary>
    public class AccessModifiersConsts
    {
        /// <summary>
        /// Code in any assembly can access this type or member.
        /// The accessibility level of the containing type
        /// controls the accessibility level of public members
        /// of the type
        /// </summary>
        public const string Public = "public";

        /// <summary>
        /// Only code declared in the same class or struct
        /// can access this member
        /// </summary>
        public const string Private = "private";

        /// <summary>
        /// Only code in the same class or in a derived class
        /// can access this type or member
        /// </summary>
        public const string Protected = "protected";

        /// <summary>
        /// Only code in the same assembly can access
        /// this type or member
        /// </summary>
        public const string Internal = "internal";

        /// <summary>
        /// Only code in the same assembly or in a derived class
        /// in another assembly can access this type or member
        /// </summary>
        public const string ProtectedInternal = "protected internal";

        /// <summary>
        /// Only code in the same assembly and in the same class
        /// or a derived class can access the type or member
        /// </summary>
        public const string PrivateProtected = "private protected";

        /// <summary>
        /// Only code in the same file can access
        /// the type or member
        /// </summary>
        public const string File = "file";
    }
}
