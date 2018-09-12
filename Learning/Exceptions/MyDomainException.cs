using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    public class MyDomainException : Exception
    {
        public int RequestId { get; set; }

        public MyDomainException(int requestId, string message, Exception innerException) : base(message, innerException)
        {
            RequestId = requestId;
        }
    }
}
