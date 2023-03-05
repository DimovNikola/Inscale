using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Common
{
    public class DateManager : IDateManager
    {
        public bool CheckDateConflictingInterval(DateTime dateFrom, DateTime dateTo, DateTime dateCheckFrom, DateTime dateCheckTo)
        {
            if (
                (dateCheckFrom.Date >= dateFrom.Date && dateCheckTo.Date <= dateTo.Date) ||
                (dateCheckFrom.Date <= dateFrom.Date && dateCheckTo.Date <= dateTo.Date && dateCheckTo.Date > dateFrom.Date) ||
                (dateCheckFrom.Date >= dateFrom.Date && dateCheckTo.Date >= dateTo.Date && dateCheckFrom.Date < dateTo.Date)
               )
                return true;
            else
                return false;
        }  
            
    }
}
