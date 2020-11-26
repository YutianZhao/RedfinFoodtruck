using System;
using System.Collections.Generic;
using System.Text;

namespace RedfinFoodtruck.Services.Common
{
    public class ServiceResponse<T> : IServiceResponse<T>
    {
        public bool Success { get; private set; }

        public string Message { get; private set; }

        public string MessageCode { get; private set; }

        public string LocalizedMessage { get; private set; }

        public T ResponseObject { get; set; }

        public string Warning { get; set; }

        public ServiceResponse(bool success, string messageCode, string message, string localizedMessage, T responseObject)
        {
            Success = success;
            MessageCode = messageCode;
            Message = message;
            LocalizedMessage = localizedMessage;
            ResponseObject = responseObject;
        }
    }

    public interface IServiceResponse<T> : IServiceResponse
    {
        T ResponseObject { get; }
    }

    public interface IServiceResponse
    {
        bool Success { get; }

        string Message { get; }

        string MessageCode { get; }

        string LocalizedMessage { get; }

        string Warning { get; }
    }
}
