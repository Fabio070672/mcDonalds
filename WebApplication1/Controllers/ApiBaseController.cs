using Microsoft.AspNetCore.Mvc;
using Orderkitchen.API.Models.Responses;
using OrderKitchen.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orderkitchen.API.Controllers
{
    public class ApiBaseController : ControllerBase
    {
        protected IActionResult Success(object data = null) => Ok(new SuccessResponse<object>(data));
        protected IActionResult Error(MessageException ex) => BadRequest(new BadResponse(ex.errors));
        protected IActionResult Error() => BadRequest(new BadResponse("I'm sorry does not can execute your request"));

    }
}
