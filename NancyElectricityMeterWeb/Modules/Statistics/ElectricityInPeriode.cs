using System;

namespace NancyElectricityMeterWeb.Modules.Statistics
{
    internal class ElectricityInPeriode
    {
        public bool HasValues { get; set; }
        public int NumberOfKiloWatts { get; set; }
        public DateTime StartDatetime { get; set; }
        public DateTime EndDatetime { get; set; }
    }
}