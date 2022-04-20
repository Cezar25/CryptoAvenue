using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject.BLL
{
    public class InputValidationBusinessLogic
    {
        public static bool ValidateIntOrDouble(Object obj)
        {
            if (obj.GetType() == typeof(int) || obj.GetType() == typeof(double))
                return true;
            return false;
        }
    }
}
