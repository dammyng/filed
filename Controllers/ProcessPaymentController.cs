using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using filed.Domain.Models;
using filed.Domain.Services;
using filed.Extensions;
using filed.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace filed.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProcessPaymentController : ControllerBase
    {
        private readonly IProcessPaymentService _processPaymentService;
        private readonly ILogger<ProcessPaymentController> _logger;
        private readonly IMapper _mapper;


        public ProcessPaymentController(ILogger<ProcessPaymentController> logger, IProcessPaymentService processPaymentService, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;

            _processPaymentService = processPaymentService;
        }

        [HttpPost]
        public async Task<IActionResult> ProcessPayment([FromBody] PaymentResource request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());


            try
            {
                var newPayment = _mapper.Map<PaymentResource, Payment>(request);
                var result = await _processPaymentService.ProcessPayment(newPayment);
                return Ok("Payment is " + result.PaymentStatus);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }

        }
    }
}