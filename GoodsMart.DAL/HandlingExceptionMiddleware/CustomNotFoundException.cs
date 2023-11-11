using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodsMart.DAL.HandlingExceptionMiddleware
{
    public class CustomNotFoundException:SystemException
    {
        private readonly string msg;

        public CustomNotFoundException() { }
        
        public CustomNotFoundException(string _msg):base(_msg)
        {
            msg=_msg;
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
