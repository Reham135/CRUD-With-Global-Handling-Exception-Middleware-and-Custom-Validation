using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodsMart.DAL.Validations;

public class DateMustBeInFutureAttribute:ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        var currentDate30=DateTime.Now.AddDays(30);
        DateTime? date = value as DateTime?;
        if (date == null)
        {
            return false;
        }
        if(date>currentDate30) { return true; }
        else { return false; }
    }
}
