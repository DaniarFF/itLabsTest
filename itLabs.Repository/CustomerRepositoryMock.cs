using itLabs.Core.Models;

namespace itLabs.Repository
{
  public class CustomerRepositoryMock : ICustomerRepository
  {
    private List<CustomerEntity> customers = new List<CustomerEntity>()
    {
      new CustomerEntity
      {
        Id = 1, 
        Name = "Хаилов Сергей Викторович", 
        Email = "jsdsd@jsds.com", Phone = "+7934567890"
      },
      new CustomerEntity 
      { 
        Id = 2, Name = "Плотников Андрей Владимирович", 
        Email = "adnfe@example.com", 
        Phone = "+7944567894" },
    };
    
    public IEnumerable<CustomerEntity> GetAll()
    {
      return customers;
    }
    
    public void Add(CustomerEntity entity)
    {
      customers.Add(entity);
    }
    
    public void Delete(int id)
    {
      customers.RemoveAll(x => x.Id == id);
    }
  }
}

