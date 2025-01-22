using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itLabs.Core.Models
{
  public class CustomerEntity
  {
    /// <summary>
    ///   Идентификатор покупателя.
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    ///   Имя покупателя.
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    ///   Электронная почта покупателя.
    /// </summary>
    public string Email { get; set; }
    
    /// <summary>
    ///   Номер телефона покупателя.
    /// </summary>
    public string Phone { get; set; }
  }
}