using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterUser.ClassLibrary
{
    public class EntityNotValidException: Exception
    {
        public EntityNotValidException(string message) : base(message)
        {

        }
    }
}
