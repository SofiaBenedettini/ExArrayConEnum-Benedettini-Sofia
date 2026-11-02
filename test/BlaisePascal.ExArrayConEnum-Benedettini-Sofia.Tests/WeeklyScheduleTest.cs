
using BlaisePascal.ExArray_Benedettini_Sofia.Domain;
using BlaisePascal.ExArrayConEnum_Benedettini_Sofia.Domain;

namespace BlaisePascal.ExArray_Benedettini_Sofia.Tests
{
    public class WeeklyScheduleTest
    {
        [Fact]
        public void Constructor_ValidName_InitializesCorrectly()
        {
            WeeklySchedule schedule = new WeeklySchedule("Mario Rossi");
            Assert.Equal("Mario Rossi", schedule.EmployeeName);
        }

        [Fact]
        public void Constructor_NullName_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new WeeklySchedule(null));
        }

        [Fact]
        public void Constructor_EmptyName_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new WeeklySchedule(""));
        }

        [Fact]
        public void Constructor_WhitespaceName_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new WeeklySchedule("   "));
        }

        [Fact]
        public void SetHoursForDay_ValidHours_UpdatesSuccessfully()
        {
            WeeklySchedule schedule = new WeeklySchedule("Luigi Verdi");
            schedule.SetHoursForDay(DaysOfWeek.Lunedì, 8.0);

            Assert.Equal(8.0, schedule.TotalHoursWorked());
        }

        [Fact]
        public void SetHoursForDay_NegativeHours_ThrowsArgumentException()
        {
            WeeklySchedule schedule = new WeeklySchedule("Anna Neri");

            Assert.Throws<ArgumentException>(
                () => schedule.SetHoursForDay(DaysOfWeek.Lunedì, -1.0));
        }

        [Fact]
        public void SetHoursForDay_ExceedingMaxHours_ThrowsArgumentException()
        {
            WeeklySchedule schedule = new WeeklySchedule("Anna Neri");

            Assert.Throws<ArgumentException>(
                () => schedule.SetHoursForDay(DaysOfWeek.Lunedì, 10.5));
        }

        [Fact]
        public void HasOvertime_TotalHoursGreaterThan40_ReturnsTrue()
        {
            WeeklySchedule schedule = new WeeklySchedule("Giorgio Rossi");

            schedule.SetHoursForDay(DaysOfWeek.Lunedì, 8.0);
            schedule.SetHoursForDay(DaysOfWeek.Martedì, 8.0);
            schedule.SetHoursForDay(DaysOfWeek.Mercoledì, 8.0);
            schedule.SetHoursForDay(DaysOfWeek.Giovedì, 8.0);
            schedule.SetHoursForDay(DaysOfWeek.Venerdì, 9.0);

            Assert.True(schedule.HasOvertime());
        }

        [Fact]
        public void HasOvertime_DayWithMoreThan8Hours_ReturnsTrue()
        {
            WeeklySchedule schedule = new WeeklySchedule("Giorgio Rossi");

            schedule.SetHoursForDay(DaysOfWeek.Lunedì, 9.0);

            Assert.True(schedule.HasOvertime());
        }

        [Fact]
        public void HasOvertime_NormalHours_ReturnsFalse()
        {
            WeeklySchedule schedule = new WeeklySchedule("Giorgio Rossi");

            schedule.SetHoursForDay(DaysOfWeek.Lunedì, 8.0);

            Assert.False(schedule.HasOvertime());
        }

        [Fact]
        public void DayWithMostHours_ReturnsCorrectDay()
        {
            WeeklySchedule schedule = new WeeklySchedule("Sara Blu");

            schedule.SetHoursForDay(DaysOfWeek.Mercoledì, 9.5);

            Assert.Equal(DaysOfWeek.Mercoledì, schedule.DayWithMostHours());
        }

        [Fact]
        public void SetHoursForDay_ValidHoursForEveryDay_UpdatesSuccessfully()
        {
            WeeklySchedule schedule = new WeeklySchedule("Mario Rossi");

            schedule.SetHoursForDay(DaysOfWeek.Lunedì, 8.0);
            schedule.SetHoursForDay(DaysOfWeek.Martedì, 7.5);
            schedule.SetHoursForDay(DaysOfWeek.Mercoledì, 6.0);
            schedule.SetHoursForDay(DaysOfWeek.Giovedì, 8.0);
            schedule.SetHoursForDay(DaysOfWeek.Venerdì, 7.0);
            schedule.SetHoursForDay(DaysOfWeek.Sabato, 4.0);
            schedule.SetHoursForDay(DaysOfWeek.Domenica, 0.0);

            Assert.Equal(40.5, schedule.TotalHoursWorked());
        }

        [Fact]
        public void DayWithMostHours_Saturday_ReturnsSaturday()
        {
            WeeklySchedule schedule = new WeeklySchedule("Sara Blu");

            schedule.SetHoursForDay(DaysOfWeek.Sabato, 9.0);

            Assert.Equal(DaysOfWeek.Sabato, schedule.DayWithMostHours());
        }

        [Fact]
        public void SetHoursForDay_ZeroHours_UpdatesSuccessfully()
        {
            WeeklySchedule schedule = new WeeklySchedule("Mario Rossi");

            schedule.SetHoursForDay(DaysOfWeek.Lunedì, 0.0);

            Assert.Equal(0.0, schedule.TotalHoursWorked());
        }

        [Fact]
        public void SetHoursForDay_MaxHours_UpdatesSuccessfully()
        {
            WeeklySchedule schedule = new WeeklySchedule("Mario Rossi");

            schedule.SetHoursForDay(DaysOfWeek.Lunedì, 10.0);

            Assert.Equal(10.0, schedule.TotalHoursWorked());
        }
    }
}
