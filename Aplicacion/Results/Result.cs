using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Results
{
    public class Result
    {
        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;
        public string Error { get; }

        protected Result(bool isSuccess, string error)
        {
            IsSuccess = isSuccess;
            Error = error;
        }

        // ✔ Success SIN valor
        public static Result Success()
        {
            return new(true, null);
        }

        // ✔ Success CON valor (GENÉRICO)
        public static Result<T> Success<T>(T value)
        {
            return new(value, true, null);
        }

        public static Result Failure(string error)
        {
            return new(false, error);
        }

        public static Result<T> Failure<T>(string error)
        {
            return new(default!, false, error);
        }
    }

    public class Result<T> : Result
    {
        private readonly T _value;

        //Generic Static Factory with Type Inference
        protected internal Result(T value, bool isSuccess, string error)
            : base(isSuccess, error)
        {
            _value = value;
        }

        public T Value()
        {
            if (IsSuccess == false)
            {
                throw new InvalidOperationException("No se puede acceder al valor de un Result fallido.");
            }

            return _value;
        }

        //// ⭐ OPCIONAL pero muy bueno
        //public static implicit operator Result<T>(T value)
        //    => Success(value);

        //internal static Result<T> Success(T value)
        //{
        //    return new(value, true, null);
        //}

        //internal static new Result<T> Failure(string error)
        //{
        //    return new(default!, false, error);
        //}
    }
}
