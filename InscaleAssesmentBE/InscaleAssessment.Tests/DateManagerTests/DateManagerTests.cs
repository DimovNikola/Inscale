using BusinessLayer.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace InscaleAssessment.Tests.DateManagerTests
{
    public class DateManagerTests
    {
        [Fact]
        public void DatesToCompare_CheckDateConflictingIntervalBothDatesInConflictingInterval_ReturnsTrue()
        {
            // Arrange
            var dateFrom = DateTime.Parse("2023-03-05T20:36:00.284Z");
            var dateTo = DateTime.Parse("2023-03-08T20:36:00.284Z");
            var dateCheckFrom = DateTime.Parse("2023-03-06T20:36:00.284Z");
            var dateCheckTo = DateTime.Parse("2023-03-07T20:36:00.284Z");

            var dateManager = new DateManager();

            // Act
            var conflict = dateManager.CheckDateConflictingInterval(dateFrom, dateTo, dateCheckFrom, dateCheckTo);

            //Assert
            Assert.True(conflict);
        }

        [Fact]
        public void DatesToCompare_CheckDateConflictingIntervalToDateInsideInterval_ReturnsTrue()
        {
            // Arrange
            var dateFrom = DateTime.Parse("2023-03-05T20:36:00.284Z");
            var dateTo = DateTime.Parse("2023-03-08T20:36:00.284Z");
            var dateCheckFrom = DateTime.Parse("2023-03-01T20:36:00.284Z");
            var dateCheckTo = DateTime.Parse("2023-03-07T20:36:00.284Z");

            var dateManager = new DateManager();

            // Act
            var conflict = dateManager.CheckDateConflictingInterval(dateFrom, dateTo, dateCheckFrom, dateCheckTo);

            //Assert
            Assert.True(conflict);
        }

        [Fact]
        public void DatesToCompare_CheckDateConflictingIntervalFromDateInsideInterval_ReturnsTrue()
        {
            // Arrange
            var dateFrom = DateTime.Parse("2023-03-05T20:36:00.284Z");
            var dateTo = DateTime.Parse("2023-03-08T20:36:00.284Z");
            var dateCheckFrom = DateTime.Parse("2023-03-06T20:36:00.284Z");
            var dateCheckTo = DateTime.Parse("2023-03-12T20:36:00.284Z");

            var dateManager = new DateManager();

            // Act
            var conflict = dateManager.CheckDateConflictingInterval(dateFrom, dateTo, dateCheckFrom, dateCheckTo);

            //Assert
            Assert.True(conflict);
        }

        [Fact]
        public void DatesToCompare_CheckDateConflictingIntervalBothDatesOutsideInterval_ReturnsTrue()
        {
            // Arrange
            var dateFrom = DateTime.Parse("2023-03-05T20:36:00.284Z");
            var dateTo = DateTime.Parse("2023-03-08T20:36:00.284Z");
            var dateCheckFrom = DateTime.Parse("2023-03-01T20:36:00.284Z");
            var dateCheckTo = DateTime.Parse("2023-03-12T20:36:00.284Z");

            var dateManager = new DateManager();

            // Act
            var conflict = dateManager.CheckDateConflictingInterval(dateFrom, dateTo, dateCheckFrom, dateCheckTo);

            //Assert
            Assert.True(conflict);
        }

        [Fact]
        public void DatesToCompare_CheckDateConflictingIntervalBothDatesLeftOfinterval_ReturnsFalse()
        {
            // Arrange
            var dateFrom = DateTime.Parse("2023-03-05T20:36:00.284Z");
            var dateTo = DateTime.Parse("2023-03-08T20:36:00.284Z");
            var dateCheckFrom = DateTime.Parse("2023-03-01T20:36:00.284Z");
            var dateCheckTo = DateTime.Parse("2023-03-02T20:36:00.284Z");

            var dateManager = new DateManager();

            // Act
            var conflict = dateManager.CheckDateConflictingInterval(dateFrom, dateTo, dateCheckFrom, dateCheckTo);

            //Assert
            Assert.False(conflict);
        }

        [Fact]
        public void DatesToCompare_CheckDateConflictingIntervalBothDatesRightOfinterval_ReturnsFalse()
        {
            // Arrange
            var dateFrom = DateTime.Parse("2023-03-05T20:36:00.284Z");
            var dateTo = DateTime.Parse("2023-03-08T20:36:00.284Z");
            var dateCheckFrom = DateTime.Parse("2023-03-09T20:36:00.284Z");
            var dateCheckTo = DateTime.Parse("2023-03-12T20:36:00.284Z");

            var dateManager = new DateManager();

            // Act
            var conflict = dateManager.CheckDateConflictingInterval(dateFrom, dateTo, dateCheckFrom, dateCheckTo);

            //Assert
            Assert.False(conflict);
        }
    }
}
