using System;
using CoreDataLibrary;

namespace HourlyRunner
{
    public class HourlyRunner : BaseCoreDataWorkItem
    {
        public override string Name
        {
            get { return "Hourly Runner"; }
        }

        public override bool DueToRun()
        {
            ReadFromDb();
            var dateTime = DateTime.Now;
            var timeSpan = dateTime - LastRun;

            if (timeSpan.TotalHours >= 1)
            {
                LastRun = dateTime;
                return true;
            }
            return false;
        }

        public override bool Run()
        {
            if (DueToRun())
            {
                ReportLogger.AddMessage("Hourly Runner", "Run called");
            }
            return true;
        }
    }
}