using ButterflySystems.Models.Errors;
using System;
using System.Collections.Generic;
using System.Text;

namespace ButterflySystems.Models.Exceptions
{
    public class ButterflySystemsException : Exception
    {
        public ErrorCode ErrorCode { get; set; }
        public string Description { get; set; }
        public ButterflySystemsException() { }
        public ButterflySystemsException(string message, ErrorCode errorCode) : base(message)
        {
        }
        public ButterflySystemsException(string message, string Description, ErrorCode errorCode) : base(message)
        {
        }
        public ButterflySystemsException(string message, ErrorCode errorCode, Exception inner) : base(message, inner)
        {
        }
    }
}
