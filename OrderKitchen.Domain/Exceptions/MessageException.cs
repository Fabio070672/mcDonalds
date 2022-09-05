using System;
using System.Collections.Generic;
using System.Text;

namespace OrderKitchen.Domain.Exceptions
{
    public class MessageException : Exception
    {
        public readonly List<string> errors;
        public MessageException() : base()
        {
            errors = new List<string>();
        }

        public MessageException(params string[] errors): this(new List<string>(errors)) { }

        public MessageException(IEnumerable<string> errors)
        {
            this.errors = new List<string>();
            this.errors.AddRange(errors);
        }

        public MessageException(string error , Exception ex):base()
        {
            errors = new List<string>();
            errors.Add(error);
        }
    }
}
