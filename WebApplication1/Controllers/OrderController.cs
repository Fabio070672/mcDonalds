using Microsoft.AspNetCore.Mvc;
using Orderkitchen.Services;
using OrderKitchen.Domain.Exceptions;
using OrderKitchen.Domain.IServices;
using OrderKitchen.Domain.Model;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading.Tasks;

namespace Orderkitchen.API.Controllers
{
    [ApiController]
    [Route("v1/order")]
    public class OrderController : ApiBaseController
    {
        private readonly OrderService _orderService;

        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("Create")]
        [SwaggerOperation(Summary ="Create order client", Description="Send for kitchen order client")]
        [SwaggerResponse(200, "Order created and send to kitchen")]
        [SwaggerResponse(400, "Some thing are wrong , order does not created")]
        public async Task<IActionResult> Insert([FromBody] OrderModel orderModel)
        {
            try
            {
                await _orderService.InsertAsync(orderModel);

            }
            catch (MessageException ex)
            {
                return Error(ex);
            }
            catch(Exception ex1)
            {
                return BadRequest(ex1);
            }
            return Ok("Your order was created and send to kitchen...");
        }

        [HttpGet("GetOrder")]
        [SwaggerOperation(Summary = "Get order list", Description = "Get all order ordered for id")]
        [SwaggerResponse(200, "Order list")]
        [SwaggerResponse(400, "Some thing are wrong , order does not listed")]
        public async Task<IActionResult> GetOrderList(bool active)
        {
            try
            {
                var result = await _orderService.GetOrderAsync(active);
                return Success(result);
            }
            catch (MessageException ex)
            {
                return Error(ex);
            }
            catch (Exception ex1)
            {
                return BadRequest(ex1);
            }
        }
    }
}
