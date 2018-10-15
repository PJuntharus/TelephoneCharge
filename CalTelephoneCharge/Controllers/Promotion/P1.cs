using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalTelephoneCharge.Controllers
{
    public class P1
    {
        
        public double CallCharge(DateTime StartTime, DateTime EndTime)
        {
            
            double diffTime = EndTime.Subtract(StartTime).TotalMinutes;

            double result = 3.0;

            if (diffTime > 1)
            {
                result += Math.Round((diffTime - 1),2);
            }


            return result;

        }
    }
}