using System;

namespace Models
{
    public class CustomResultModel
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public bool Succeeded { get; set; }
    }
}
