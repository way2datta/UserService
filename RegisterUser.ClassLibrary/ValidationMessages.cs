namespace RegisterUser.ClassLibrary
{
    public static class ValidationMessages
    {
        public static string FieldIsRequired = "{0} is required.";

        public static string GetFieldIsRequiredMessage(string fieldName)
        {
            return string.Format(FieldIsRequired, fieldName);
        }
    }
}