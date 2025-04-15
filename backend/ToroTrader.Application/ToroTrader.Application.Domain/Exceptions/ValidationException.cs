using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToroTrader.Application.Domain.Exceptions
{
    public class ValidationException : Exception
    {
        public IEnumerable<string> Errors { get; }

        public ValidationException(string message) : base(message)
        {
            Errors = [message];
        }

        public ValidationException(IEnumerable<string> errors)
            : base("Erro(s) de validação.")
        {
            Errors = errors;
        }
    }
}

