﻿namespace URLShorten.Dto
{
    public class Result<T>
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public T Data { get; set; }

        public static Result<T> Ok(T data, string? message = null)
        {
            return new Result<T>
            {
                Success = true,
                Data = data,
                Message = message
            };
        }

        public static Result<T> Fail(string? message = null)
        {
            return new Result<T>
            {
                Success = false,
                Message = message
            };
        }
    }
}
