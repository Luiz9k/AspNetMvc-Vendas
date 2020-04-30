using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vendas.Services.Exceptions
{
    public class NotFoundExcepetion : ApplicationException
    {
        public NotFoundExcepetion(string message) : base(message)
        {

        }
    }
}
