using System;
using System.Collections.Generic;
using System.Text;

namespace Ahmynar_Application.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string name, object key) : base($"{name} ({key}) não foi encontrado")
        {

        }
    }
}
