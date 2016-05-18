using System;

namespace Sol_Calc_Online
{
    [Serializable]
    internal class TollingPeriod
    {
        private double length;
        public double Length { get { return length; } set { this.length = value; } }

        private DateTime start;
        public DateTime Start { get { return start; } set { this.start = value; } }

        private DateTime end;
        public DateTime End { get { return end; } set { this.end = value; } }

        private TimeSpan span;
        public TimeSpan Span { get { return span; } set { this.span = value; } }

        private string dateStringFormat = "MM/dd/yyyy";

        public TollingPeriod(DateTime start, DateTime end)
        {
            this.start = start;
            this.end = end;
            calcTimeSpan();
            calcLength();
        }

        private void calcTimeSpan()
        {
            this.span = end - start;
        }

        private void calcLength()
        {
            this.length = span.TotalDays + 1;
        }

        public override string ToString()
        {
            // eg 01/21/2016 - 01/23/2016 = 3 days
            return start.ToString(dateStringFormat)
                                + " - " + end.ToString(dateStringFormat)
                                + " = " + length.ToString("000") + " days";
        }
}
}