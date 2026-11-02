using BlaisePascal.ExArrayConEnum_Benedettini_Sofia.Domain;

namespace BlaisePascal.ExArray_Benedettini_Sofia.Domain
{
    public class WeeklySchedule
    {
        private string _employeeName;
        public string EmployeeName
        {
            get
            { return _employeeName; }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("The name of the employee must have characters");
                }
                _employeeName = value;
            }
        }

        private List<double> _dailyHours;

        public WeeklySchedule(string employeeName)
        {
            EmployeeName = employeeName;

            _dailyHours = new List<double>();
            for (int i = 0; i < 7; i++)
            {
                _dailyHours.Add(0.0);
            }
        }

        public void SetHoursForDay(DaysOfWeek day, double hours)
        { 
            if (hours < 0.0 || hours > 10.0)
            {
                throw new ArgumentException("The hours worked should be between 0.0 and 10.0");
            }

            // va a prendere il valore numerico corrispondente a quell elemento nella enum
            int index = (int)day;
            _dailyHours[index] = hours;
        }

        public double TotalHoursWorked()
        {
            double counter = 0.0;
            foreach (double hour in _dailyHours)
            {
                counter += hour;
            }
            return counter;
        }

        private bool AreDaysWithMoreThan8Hours()
        {
            bool areDaysWithMoreThan8Hours = false;

            foreach (double hour in _dailyHours)
            {
                if (hour > 8.0)
                {
                    areDaysWithMoreThan8Hours = true;
                    break;
                }
            }

            return areDaysWithMoreThan8Hours;
        }

        public bool HasOvertime()
        {
            bool hasOvertime = false;

            if (this.TotalHoursWorked() > 40.0 || this.AreDaysWithMoreThan8Hours() == true)
            {
                hasOvertime = true;
            }

            return hasOvertime;
        }

        public DaysOfWeek DayWithMostHours()
        {
            double maxHours = _dailyHours[0];

            foreach(double hoursOfDay in _dailyHours)
            {
                if(hoursOfDay > maxHours)
                {
                    maxHours = hoursOfDay;
                }
            }

            int indexOfMax = _dailyHours.IndexOf(maxHours);
            DaysOfWeek dayFound = (DaysOfWeek)indexOfMax;

            return dayFound;
        }

    }
}
