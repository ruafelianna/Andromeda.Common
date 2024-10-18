namespace Andromeda.Localization.SourceGenerators
{
    internal static class InternalConsts
    {
        public const string LocalizationConf = $"localization{LocalizationConf_Ext}";

        public const string LocalizationConf_Ext = ".toml";

        public const string LocalizationConf_Invariant = "invariant_culture";

        public const string LocalizationConf_Class = "generated_class_name";

        public const string LocalizationConf_Namespace = "generated_namespace";

        public const string NS_Andromeda = nameof(Andromeda);

        public const string NS_Localization = $"{NS_Andromeda}.Localization";

        public const string NS_Localization_Abstractions = $"{NS_Localization}.Abstractions";

        public const string I_TranslationUnit = "ITranslationUnit";

        public const string I_TranslationProvider = "ITranslationProvider";

        public const string CL_TranslationUnit = "TranslationUnit";

        public const string CL_TranslationProvider = "TranslationProvider";

        public const string Tab = "    ";

        public const string AOptions_Project_Dir = "build_property.projectdir";
    }
}
