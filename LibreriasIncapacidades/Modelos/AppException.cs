using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace LibreriasIncapacidades.Modelos
{
    public class AppException : Exception
    {

        public string[] dataLog { get; set; }
        public AppException() : base() { }

        public AppException(string message) : base(message) { }
        //public AppException(string message, string details) : base(message) { }

        public AppException(string message, string details, string[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, details, args))
        {
            dataLog = args;
        }

        //public AppException(string message, string details, IDictionary data)
        //   : base(String.Format(CultureInfo.CurrentCulture, message, details, data))
        //{
        //}
    }
}
