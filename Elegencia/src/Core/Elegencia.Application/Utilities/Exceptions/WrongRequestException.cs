using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elegencia.Application.Utilities.Exceptions
{
    public class WrongRequestException:Exception
    {
        public WrongRequestException(string message) : base(message) { }
    }
}
