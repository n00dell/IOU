using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOU.Services.Common
{
    internal class ServiceException : Exception
    {
        public string ServiceName { get; set; }
        public string OperationName { get; set; }

        public ServiceException(string message) : base(message)
        {
            ServiceName = "";
            OperationName = "";
        }

        public ServiceException(string serviceName, string operationName, string message)
            : base(message)
        {
            ServiceName = serviceName;
            OperationName = operationName;
        }
    
}
}
