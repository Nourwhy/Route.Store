using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class BasketNotFoundException(string id)
      : NotFoundException(message: $"Basket With Id '{id}' Not Found")
    {
    }

}
