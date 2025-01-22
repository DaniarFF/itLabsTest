using System.Collections.Generic;
using itLabs.Core.Models;

namespace itLabs.Core.Services;

public interface ICustomerService
{
  /// <summary>
  ///   Добавление нового клиента.
  /// </summary>
  /// <param name="customer"></param>
  void Add(Customer customer);
  
  /// <summary>
  ///   Получение всех клиентов.
  /// </summary>
  /// <returns></returns>
  IEnumerable<Customer> GetAll();
  
  /// <summary>
  ///   Удаление клиента.
  /// </summary>
  /// <param name="id"></param>
  void Delete(int id);
}