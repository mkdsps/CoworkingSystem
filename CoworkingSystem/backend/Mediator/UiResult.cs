using System;
using System.Collections.Generic;
using System.Text;

namespace CoworkingSystem.backend.Mediator
{
    public class UiResult<T>
    {
        public bool Success { get; }
        public string Message { get; }
        public T? Data { get; }

        private UiResult(bool success, string message, T? data)
        {
            Success = success;
            Message = message;
            Data = data;
        }

        public static UiResult<T> Ok(T? data = default, string message = "OK")
            => new UiResult<T>(true, message, data);

        public static UiResult<T> Fail(string message)
            => new UiResult<T>(false, message, default);
    }
}
