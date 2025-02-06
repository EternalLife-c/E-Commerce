using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.Responses
{
    public class BaseCommandResponse 
    {
        //Use later for getting custom responses after a failed or successfull operation in handles
        public int Id { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
    }
}
