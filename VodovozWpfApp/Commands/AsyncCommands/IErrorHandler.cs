using System;

namespace VodovozWpfApp

{
    public interface IErrorHandler
    {
        void HandleError(Exception ex);
    }
}