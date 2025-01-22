using System.Collections.Generic;
using System.Linq;
using itLabs.Core.Models;
using itLabs.Repository;

namespace itLabs.Core.Services;

public class CustomerService : ICustomerService
{
  private readonly ICustomerRepository repository;

  public CustomerService(ICustomerRepository repository)
  {
    this.repository = repository;
  }

  public void Add(Customer customer)
  {
    var entity = new CustomerEntity
    {
      Id = customer.Id,
      Name = customer.Name,
      Email = customer.Email,
      Phone = customer.Phone
    };

    repository.Add(entity);
  }

  public IEnumerable<Customer> GetAll()
  {
    var entities = repository.GetAll();

    var customers = entities.Select(entity => new Customer
    {
      Phone = entity.Phone,
      Email = entity.Email,
      Name = entity.Name,
      Id = entity.Id
    });

    return customers;
  }

  public void Delete(int id)
  {
    repository.Delete(id);
  }
}