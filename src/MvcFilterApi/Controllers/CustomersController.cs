using Microsoft.AspNetCore.Mvc;
using MvcFilterApi.Dtos;
using MvcFilterApi.Models;

namespace MvcFilterApi.Controllers;

[ApiController]
[Route("api/customer")]
public class CustomerController : ControllerBase
{
    [HttpGet]
    public IActionResult GetCustomer() 
    {
        return Ok(new Customer("Henrique", 24));
    }

    [HttpPost]
    public IActionResult PostCustomer([FromBody] CustomerDto request) 
    {
        var customer = new Customer(request.Name, request.Age);

        return Ok(customer);
    }
}