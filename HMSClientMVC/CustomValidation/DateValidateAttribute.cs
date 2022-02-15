using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;

namespace HMSClientMVC.CustomValidation
{
    public class DateValidateAttribute : ValidationAttribute
    {
         
            public override bool IsValid(object value)
            {
                DateTime propValue = Convert.ToDateTime(value);
                if (propValue >= DateTime.Now)
                    return true;
                else
                    return false;

            }
        

    }
}