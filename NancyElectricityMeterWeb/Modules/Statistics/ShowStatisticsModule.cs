using System;
using System.Collections.Generic;
using DataHandling;
using Nancy;

namespace NancyElectricityMeterWeb.Modules.Statistics
{
    //Show today from midnight, last day, last 7 days, last 30 days, last 6 months, last year
    public class ShowStatisticsModule : NancyModule
    {
        public IGetElectricityValuesForAPeriode _electricityHandling { get; set; }

        public ShowStatisticsModule()
        {

            Get["/showstatistics"] = parameters =>
            {
                _electricityHandling = new DataHandling.GetElectricityValuesForAPeriode();

                var electricityStatisticsModel = GetDataToShowOnWebPage();
                return View["showStatistics", electricityStatisticsModel];
            };
        }

        private ElectricityStatisticsViewModel GetDataToShowOnWebPage()
        {
            return new ElectricityStatisticsViewModel()
            {
                ElectricityFromMidnight = GetElectricityForAPeriode(DateTime.Now.Date, DateTime.Now),
                ElectricityPreviousDay = GetElectricityForAPeriode(DateTime.Now.AddDays(-1).Date, DateTime.Now.Date),
                ElectricityLastSevenDays = GetElectricityForAPeriode(DateTime.Now.AddDays(-7), DateTime.Now),
                ElectricityLastMonth = GetElectricityForAPeriode(DateTime.Now.AddMonths(-1), DateTime.Now),
                ElectricityLastSixMonths = GetElectricityForAPeriode(DateTime.Now.AddMonths(-6), DateTime.Now),
                ElectricityLastYear = GetElectricityForAPeriode(DateTime.Now.AddYears(-1), DateTime.Now),
                ElectricityLastTwentyFourHours = GetElectricityForAPeriode(DateTime.Now.AddHours(-24), DateTime.Now),

                ElectricitySinceStartOfWeek = GetElectricityForAPeriode(DateTime.Now.GetStartOfWeek(), DateTime.Now),
                ElectricityPreviousWeek = GetElectricityForAPeriode(DateTime.Now.GetStartOfWeek().AddDays(-7), DateTime.Now.GetStartOfWeek()),
                ElectricitySinceStartOfMonth = GetElectricityForAPeriode(DateTime.Now.GetStartOfMonth(), DateTime.Now),
                ElectricityPreviousMonth = GetElectricityForAPeriode(DateTime.Now.GetStartOfMonth().AddDays(-1).GetStartOfMonth(), DateTime.Now.GetStartOfMonth())
            };
        }

        private DateTime FindStartOfMonth(DateTime inputDateTime)
        {
            return new DateTime(inputDateTime.Year, inputDateTime.Month, 1);
        }

        private DateTime FindStartOfWeek(DateTime inputDateTime)
        {
            //Since we are Norwegian our week starts on monday - Day 1 not 0
            var thisDayOfWeek =(int) inputDateTime.DayOfWeek;
            if(thisDayOfWeek==1) return new DateTime(inputDateTime.Year,inputDateTime.Month,inputDateTime.Day);
            if(thisDayOfWeek==0) return inputDateTime.Date.AddDays(-7);
            return DateTime.Today;
        }

        private ElectricityInPeriode GetElectricityForAPeriode(DateTime startDateTime, DateTime endDateTime)
        {
            var periodeData = new ElectricityInPeriode() { HasValues = false };
            var listOfInts = _electricityHandling.GetElectricityValuesForGivenPeriode(startDateTime, endDateTime);
            if (listOfInts.Count > 0)
            {
                periodeData.HasValues = true;
                periodeData.StartDatetime = startDateTime;
                periodeData.EndDatetime = startDateTime;
                periodeData.NumberOfKiloWatts = FindNumberOfKilowattsUsed(listOfInts);
            }
            return periodeData;
        }

        private int FindNumberOfKilowattsUsed(List<int> listOfInts)
        {
            if (listOfInts.Count < 2) return -1;

            listOfInts.Sort();
            var startValue = listOfInts[0];
            var endValue = listOfInts[listOfInts.Count - 1];
            var returnValue = endValue - startValue;
            return returnValue;
        }
    }
}