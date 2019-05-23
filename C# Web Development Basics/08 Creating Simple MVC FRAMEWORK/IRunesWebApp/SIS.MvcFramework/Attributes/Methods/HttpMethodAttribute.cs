namespace SIS.MvcFramework.Attributes.Methods
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class HttpMethodAttribute : Attribute
    {
        public abstract bool IsValid(string requestMethod);
    }
}
