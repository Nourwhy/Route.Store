using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class ProductNotFoundException(int id) :
    NotFoundException(message: $"Product With id ({id}) Not Found !!")
    {
    }
}
