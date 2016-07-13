using System;
using System.Collections.Generic;

namespace DataHandling
{
    public interface IGetElectricityValuesForAPeriode
    {
        List<int> GetElectricityValuesForGivenPeriode(DateTime startDateTime, DateTime endDateTime);
    }
}