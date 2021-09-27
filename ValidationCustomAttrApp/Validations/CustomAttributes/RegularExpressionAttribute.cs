using System;

namespace ValidationCustomAttrApp.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.Property, AllowMultiple = false)]
    public class RegularExpressionAttribute : Attribute
    {
        public string ErrorMessage { get; set; }

        public string Pattern { get; set; }

        public RegularExpressionAttribute(string pattern)
        {
            Pattern = pattern;
            ErrorMessage = "Field, {0}, is invalid. The value provided does not match the declared regular expression pattern, {1}";
        }

        public RegularExpressionAttribute(string pattern, string errorMessage)
        {
            Pattern = pattern;
            ErrorMessage = errorMessage;
        }
    }
}
