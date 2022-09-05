using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orderkitchen.API.Models.Responses
{
    public sealed class BadResponse : BaseResponse
    {
        public List<string> Errors { get;private set; }
        public BadResponse(string error) : base(false) 
        { 
            Errors = new List<string> { error }; 
        }

        public BadResponse(List<string> errors) : base(false)
        {
            Errors = errors;
        }
    }
}
