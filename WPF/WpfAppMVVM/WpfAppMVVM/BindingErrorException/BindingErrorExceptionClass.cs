using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WpfAppMVVM.BindingErrorExceptionClass
{
    [Serializable]
    public class BindingErrorException : Exception
    {
        public string SourceObject { get; set; }
        public string SourceProperty { get; set; }
        public string TargetElement { get; set; }
        public string TargetProperty { get; set; }

        public BindingErrorException()
            : base() { }

        public BindingErrorException(string message)
            : base(message) { }

        public BindingErrorException(string sourceObject, string sourceProperty, string targetElement, string targetProperty) : this(sourceObject)
        {
            SourceProperty = sourceProperty;
            TargetElement = targetElement;
            TargetProperty = targetProperty;
        }
    }

    public class BindingErrorTraceListener : TraceListener
    {
        private const string BindingErrorPattern = @"^BindingExpression path error(?:.+)'(.+)' property not found(?:.+)object[\s']+(.+?)'(?:.+)target element is '(.+?)'(?:.+)target property is '(.+?)'(?:.+)$";

        public override void Write(string s) { }

        public override void WriteLine(string message)
        {
            //throw new Exception(message);
            var xx = new BindingErrorException(message);

            var match = Regex.Match(message, BindingErrorPattern);
            if (match.Success)
            {
                xx.SourceObject = match.Groups[2].ToString();
                xx.SourceProperty = match.Groups[1].ToString();
                xx.TargetElement = match.Groups[3].ToString();
                xx.TargetProperty = match.Groups[4].ToString();
            }

            throw xx;
        }
    }
}
