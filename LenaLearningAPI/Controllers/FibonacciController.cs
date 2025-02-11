using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LenaLearning;
using Swashbuckle.AspNetCore.Annotations;
using LenaLearningAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace LenaLearningAPI.Controllers
{
    [ApiController]
    [Route("Fibonacci")]
    public class FibonacciController : ControllerBase
    {
        private readonly Fibonacci _fibonacci;

        public FibonacciController(Fibonacci fibonacci)
        {
            _fibonacci = fibonacci;
        }

        [HttpGet]
        [SwaggerResponse(200, Type= typeof(FibonacciNumberResponse))]
        public IActionResult GetFibonacciNumberOf([FromQuery, Required]int number)
        {
            try
            {

                var result = _fibonacci.GetFibonacciNumberOf(number);
                return Ok(new FibonacciNumberResponse
                {
                    Number = number,
                    FibonacciNumber = result,
                    Message = $"The Fibonacci number of {number} is {result}"
                });
            }
            catch (MyException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [SwaggerResponse(200, Type = typeof(FibonacciListResponse))]
        [HttpGet("upto/")]
        public IActionResult GetFibonacciUpTo([FromQuery, Required] int number)
        {
            try
            {
                var result = _fibonacci.CalcFibonacciUpTo(number);
                return Ok(new FibonacciListResponse
                {
                    UpTo = number,
                    FibonacciNumbers = result,
                    Message = $"Fibonacci numbers up to {number}: {string.Join(" | ", result)}"
                });
            }
            catch (MyException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [SwaggerResponse(200, Type = typeof(FibonacciRangeResponse))]
        [HttpGet("range/")]
        public IActionResult GetFibonacciBetween([FromQuery, Required] int start, [FromQuery] int end)
        {
            try
            {
                var result = _fibonacci.CalcFibonacciBetween(start, end);
                return Ok(new FibonacciRangeResponse
                {
                    Start = start,
                    End = end,
                    FibonacciNumbers = result,
                    Message = $"Fibonacci numbers between {start} and {end}: {string.Join(" | ", result)}"
                });
            }
            catch (MyException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
