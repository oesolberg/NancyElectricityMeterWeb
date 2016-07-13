namespace NancyElectricityMeterWeb.Modules.Statistics
{
    internal class ElectricityStatisticsViewModel
    {
        public ElectricityInPeriode ElectricityFromMidnight { get; set; }
        public ElectricityInPeriode ElectricityPreviousDay { get; set; }
        public ElectricityInPeriode ElectricityLastSevenDays { get; set; }
        public ElectricityInPeriode ElectricityLastMonth { get; set; }
        public ElectricityInPeriode ElectricityLastSixMonths { get; set; }
        public ElectricityInPeriode ElectricityLastYear { get; set; }
        public ElectricityInPeriode ElectricityLastTwentyFourHours { get; set; }
        public ElectricityInPeriode ElectricitySinceStartOfWeek { get; set; }
        public ElectricityInPeriode ElectricityPreviousWeek { get; set; }
        public ElectricityInPeriode ElectricityPreviousMonth { get; set; }
        public ElectricityInPeriode ElectricitySinceStartOfMonth { get; set; }
    }
}