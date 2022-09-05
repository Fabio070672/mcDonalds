using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orderkitchen.API.Models.Responses
{
    public abstract class BaseResponse
    {
        public bool Success { get;private set; }
        protected BaseResponse(bool success)
        {
            Success = success; 
        }
    }
}
