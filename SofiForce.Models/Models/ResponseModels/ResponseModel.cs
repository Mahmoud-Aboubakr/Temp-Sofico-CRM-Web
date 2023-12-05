using System;
using System.Collections.Generic;

namespace Models
{
    public class ResponseModel<T>
    {
        public string Message { get; set; }
        public int StatusCode { get; set; } = 200;
        public DateTime ExecutionDate { get; set; } = DateTime.Now;
        public bool Succeeded { get; set; } = true;
        public T Data { get; set; }
        public int Total { get; set; } = 1;

    }
}