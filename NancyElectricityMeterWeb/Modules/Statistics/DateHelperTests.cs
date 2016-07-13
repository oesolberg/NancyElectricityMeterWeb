using System;
using NUnit.Framework;
using Shouldly;

namespace NancyElectricityMeterWeb.Modules.Statistics
{
    public class DateHelperTests
    {
        [Test]
        public void GetStartOfWeeek_InputMonday_ShouldGiveStartOfWeekSameDay()
        {
            //Arrange
            var dateToTest = new DateTime(2016, 7, 11);

            //Act
            var result = dateToTest.GetStartOfWeek();

            //Assert

            result.DayOfWeek.ShouldBe(DayOfWeek.Monday);
            result.Day.ShouldBe(dateToTest.Day);
        }

        [Test]
        public void GetStartOfWeeek_InputTuesday_ShouldGiveStartOfWeekTheDayBefore()
        {
            //Arrange
            var dateToTest=new DateTime(2016,7,12);

            //Act
            var result = dateToTest.GetStartOfWeek();
            
            //Assert
           
            result.DayOfWeek.ShouldBe(DayOfWeek.Monday);
            result.Day.ShouldBe(dateToTest.Day-1);
        }

        [Test]
        public void GetStartOfWeeek_InputSunday_ShouldGiveStartOfWeekThePreviousMonday()
        {
            //Arrange
            var dateToTest = new DateTime(2016, 7, 10);

            //Act
            var result = dateToTest.GetStartOfWeek();

            //Assert

            result.DayOfWeek.ShouldBe(DayOfWeek.Monday);
            result.Day.ShouldBe(dateToTest.AddDays(-6).Day);
        }

        [Test]
        public void GetStartOfWeeek_InputSundayAtTheStartOfMonth_ShouldGiveStartOfWeekThePreviousMondayTheMonthBefore()
        {
            //Arrange
            var dateToTest = new DateTime(2016, 7, 3);

            //Act
            var result = dateToTest.GetStartOfWeek();

            //Assert

            result.DayOfWeek.ShouldBe(DayOfWeek.Monday);
            result.Day.ShouldBe(dateToTest.AddDays(-6).Day);
            result.Month.ShouldBe(dateToTest.AddMonths(-1).Month);
        }

        [Test]
        public void GetStartOfWeeek_InputSaturdayInJanuary_ShouldGiveStartOfWeekThePreviousMondayTheMonthAndYearBefore()
        {
            //Arrange
            var dateToTest = new DateTime(2016, 1, 2);

            //Act
            var result = dateToTest.GetStartOfWeek();

            //Assert

            result.DayOfWeek.ShouldBe(DayOfWeek.Monday);
            result.Day.ShouldBe(28);
            result.Month.ShouldBe(12);
            result.Year.ShouldBe(2015);
        }
        [Test]
        public void GetStartOfMonth_SecondOfJanuary_ShouldGiveFirstOfJanuary()
        {
            //Arrange
            var dateToTest = new DateTime(2016, 1, 2);

            //Act
            var result = dateToTest.GetStartOfMonth();

            //Assert
            result.Day.ShouldBe(1);
            result.Month.ShouldBe(1);
            result.Year.ShouldBe(2016);
        }
        [Test]
        public void GetStartOfWeeek_InputThirtyFirstOfDecember_ShouldFirstOfDecember()
        {
            //Arrange
            var dateToTest = new DateTime(2015, 12, 31);

            //Act
            var result = dateToTest.GetStartOfMonth();

            //Assert
            result.Day.ShouldBe(1);
            result.Month.ShouldBe(12);
            result.Year.ShouldBe(2015);
        }

    }
}