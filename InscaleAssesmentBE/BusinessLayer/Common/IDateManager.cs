using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Common
{
    public interface IDateManager
    {
        bool CheckDateConflictingInterval(DateTime dateFrom, DateTime dateTo, DateTime dateCheckFrom, DateTime dateCheckTo);
    }
}
