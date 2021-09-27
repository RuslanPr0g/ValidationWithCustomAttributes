using System;

namespace ValidationCustomAttrApp.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.Property, AllowMultiple = false)]
    public class StringLengthAttribute : Attribute
    {
        public int MaxLength { get; set; }

        public string ErrorMessage { get; set; }

        public int MinLength { get; set; }

        public StringLengthAttribute(int maxLength)
        {
            SetProperties(maxLength);
        }

        public StringLengthAttribute(int maxLength, string errorMessage)
        {
            SetProperties(maxLength, errorMessage);
        }

        public StringLengthAttribute(int maxLength, int minLength)
        {
            SetProperties(maxLength, minLength: minLength);
        }

        public StringLengthAttribute(int maxLength, string errorMessage, int minLength)
        {
            SetProperties(maxLength, errorMessage, minLength);
        }

        private void SetProperties(int maxLength, string errorMessage = "", int? minLength = null)
        {
            if (errorMessage == string.Empty)
            {
                if (minLength is null)
                {
                    ErrorMessage = "The character length for field, {0}, must not exceed {1}";
                }
                else
                {
                    ErrorMessage = "Field, {0}, cannot have a character length that is less than {2} or a character length that is greater than {1}";
                }
            }
            else
            {
                ErrorMessage = errorMessage;
            }

            MaxLength = maxLength;

            MinLength = minLength == null ? 0 : minLength.Value;
        }
    }
}
