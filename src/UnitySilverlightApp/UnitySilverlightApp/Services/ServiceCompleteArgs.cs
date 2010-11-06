using System;

namespace UnitySilverlightApp.Services
{
    public class ServiceCompleteArgs<T> :EventArgs where T : class
    {
        public T Entity { get; set; }

        public Exception Error { get; set; }

        public ServiceCompleteArgs(T entity, Exception e)
        {
            Entity = entity;
            Error = e;
        }
    }
}