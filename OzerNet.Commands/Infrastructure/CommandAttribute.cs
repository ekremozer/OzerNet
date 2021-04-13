using System;

namespace OzerNet.Commands.Infrastructure
{
    public class AuthorizedAttribute : Attribute
    {
    }
    public class RequiredValidation : Attribute
    {
        public string ErrorMessage { get; set; }
    }
    public class MinLengthValidation : Attribute
    {
        public int MinLength { get; set; }
        public string ErrorMessage { get; set; }
    }
    public class MaxLengthValidation : Attribute
    {
        public int MaxLength { get; set; }
        public string ErrorMessage { get; set; }
    }
    public class MinNumberValidation : Attribute
    {
        public int MinNumber { get; set; }
        public string ErrorMessage { get; set; }
    }
    public class MaxNumberValidation : Attribute
    {
        public int MaxNumber { get; set; }
        public string ErrorMessage { get; set; }
    }
    public class MinItemValidation : Attribute
    {
        public int MinItemCount { get; set; }
        public string ErrorMessage { get; set; }
    }
    public class MaxItemValidation : Attribute
    {
        public int MaxItemCount { get; set; }
        public string ErrorMessage { get; set; }
    }
    public class AccessAuthorityAttribute : Attribute
    {
        public string Module { get; set; }
        public string Authority { get; set; }
        public string ErrorMessage { get; set; }
    }

    public class CommandCache : Attribute
    {
        public int Days { get; set; }
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Second { get; set; }
    }
}
