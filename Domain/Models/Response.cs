using System;

namespace filed.Domain.Models
{
    public class Response
    {
        public int Id { get; set; }
        public int StatusCode { get; set; }        
        public bool Success { get; set; }        
        public string Message { get; set; }
    }
}