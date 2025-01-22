using System.Collections.Generic;
using itLabs.Core.Models;

namespace itLabs.Repository;

public interface ICustomerRepository
{
  /// <summary>
  ///   Получение всех клиентов.
  /// </summary>
  /// <returns></returns>
  IEnumerable<CustomerEntity> GetAll();
  
  /// <summary>
  ///   Добавление нового клиента.
  /// </summary>
  /// <param name="entity"></param>
  void Add(CustomerEntity entity);
  
  /// <summary>
  ///   Удаление клиента.
  /// </summary>
  /// <param name="id"></param>
  void Delete(int id);
}