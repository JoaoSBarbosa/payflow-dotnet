using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace payFlow.Application.Exceptions
{
    public sealed class BusinessException : FieldNullException
    {
        public BusinessException(string message) : base(message)
        {

        }
    }
}
