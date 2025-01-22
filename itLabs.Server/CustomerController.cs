using itLabs.Api;
using itLabs.Core.Models;
using itLabs.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace itLabs.Server;

/// <summary>
///  API контроллер для работы с клиентами.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
  private readonly ICustomerService customerService;

  public CustomerController(ICustomerService customerService)
  {
    this.customerService = customerService;
  }

  /// <summary>
  ///  Получение всех клиентов.
  /// </summary>
  /// <returns></returns>
  [HttpGet]
  public ActionResult<List<CustomerResponse>> GetAll()
  {
    var customers = customerService.GetAll();
    var response = customers.Select(c => new CustomerResponse()
    {
      Name = c.Name,
      Email = c.Email,
      Phone = c.Phone,
      Id = c.Id
    });

    return Ok(response);
  }

  /// <summary>
  ///  Добавление нового клиента.
  /// </summary>
  /// <param name="request"></param>
  /// <returns></returns>
  [HttpPost]
  public async Task<IActionResult> AddCustomer([FromBody] AddCustomerRequest request)
  {
    var newCustomer = new Customer()
    {
      Name = request.Name,
      Email = request.Email,
      Phone = request.Phone
    };

    customerService.Add(newCustomer);
    return Ok();
  }

  /// <summary>
  ///  Удаление клиента.
  /// </summary>
  /// <param name="id"></param>
  /// <returns></returns>
  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteCustomer([FromRoute] int id)
  {
    customerService.Delete(id);
    return Ok();
  }
}