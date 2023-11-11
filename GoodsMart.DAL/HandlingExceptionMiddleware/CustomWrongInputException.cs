using GoodsMart.DAL.HandlingExceptionMiddleware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodsMart.DAL.HandlingExceptionMiddleware
{
    public class CustomWrongInputException:SystemException
    {
        private readonly string msg;

        public CustomWrongInputException()
        {
        }

        public CustomWrongInputException(string _msg): base(_msg)
        {
            msg = _msg;
        }
        public override string Message
        {
            get
            {
                return $"{msg}";
            }
        }
    }
}

