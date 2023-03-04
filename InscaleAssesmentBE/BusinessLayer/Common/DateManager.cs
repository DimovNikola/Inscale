﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Common
{
    public class DateManager : IDateManager
    {
        public bool CheckDateConflictingInterval(DateTime dateFrom, DateTime dateTo, DateTime dateCheckFrom, DateTime dateCheckTo) => 
            dateCheckFrom >= dateFrom && dateCheckTo <= dateTo
            || dateCheckFrom <= dateFrom && dateCheckTo <= dateTo
            || dateCheckFrom >= dateFrom && dateCheckTo >= dateTo;
    }
}