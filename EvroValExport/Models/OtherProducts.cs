using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EvroValExport.Models
{
    public class OtherProducts : CategoryProducts 
    {
        public override Decimal CalculateTotalSum()
        {
            return Price * (Quantity/10);
        }
    }
}