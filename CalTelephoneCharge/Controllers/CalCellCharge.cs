using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalTelephoneCharge.Controllers
{
    public class CalCellCharge
    {
        public double CalTotalCharge(string Promotion, DateTime StartTime, DateTime EndTime)
        {
            switch (Promotion)
            {
                case "P1": P1 p1 = new P1();
                    return p1.CallCharge(StartTime, EndTime);

                //Insert Other Case
                default: return 0;
            }

        }
    }
}