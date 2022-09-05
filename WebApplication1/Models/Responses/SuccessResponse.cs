using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orderkitchen.API.Models.Responses
{
    public sealed class SuccessResponse<T> : BaseResponse where T : class
    {
        public T Data { get; private set; }
        public SuccessResponse(T data) : base(true)
        {
            Data = data;
        }
    }
}
