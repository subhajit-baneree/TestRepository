using Honeywell.App.Business.Library.Enums;
using Honeywell.App.Business.Library.Helpers;
using Honeywell.App.Business.Library.Interfaces;
using System;

namespace Honeywell.App.Business.Library.Implementations
{
    public class TimeConverter : ITimeConverter
    {
        public string ConvertToSelectedTimeZone(Timezone timeZone)
        {
            var convertedTime = string.Empty;
            try
            {
                switch (timeZone)
                {
                    case Timezone.EST:
                        convertedTime = ConvertToEST();
                        break;

                    case Timezone.CST:
                        convertedTime = ConvertToCST();
                        break;

                    case Timezone.PST:
                        convertedTime = ConvertTOPST();
                        break;

                    case Timezone.IST:
                        convertedTime = ConvertTOIST();
                        break;
                }
            }
            catch (Exception ex)
            {
                Logger.Log("Execption occured while trying to get time for " + timeZone);
                Logger.Log("Exception message: " + ex.Message);
            }
            return convertedTime;
        }

        private string ConvertToEST() 
        {
            var currentSystemTime = DateTime.Now;
            TimeZoneInfo timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(global::Honeywell.App.Business.Library.Resources.TimeCodeResource.EST_ID);
            var timeZoneInCST = TimeZoneInfo.ConvertTime(currentSystemTime, timeZoneInfo);
            return ConvertToRequiredFormat(timeZoneInCST);
        }

        private string ConvertToCST() 
        {
            var currentSystemTime = DateTime.Now;
            TimeZoneInfo timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(global::Honeywell.App.Business.Library.Resources.TimeCodeResource.CST_ID);
            var timeZoneInCST = TimeZoneInfo.ConvertTime(currentSystemTime, timeZoneInfo);
            return ConvertToRequiredFormat(timeZoneInCST);
        }

        private string ConvertTOPST() 
        {
            var currentSystemTime = DateTime.Now;
            TimeZoneInfo timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(global::Honeywell.App.Business.Library.Resources.TimeCodeResource.PST_ID);
            var timeZoneInPST = TimeZoneInfo.ConvertTime(currentSystemTime, timeZoneInfo);
            
            return ConvertToRequiredFormat(timeZoneInPST);
        }

        private string ConvertTOIST() 
        {
            var currentSystemTime = DateTime.Now;
            TimeZoneInfo timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(global::Honeywell.App.Business.Library.Resources.TimeCodeResource.IST_ID);
            var timeZoneInCST = TimeZoneInfo.ConvertTime(currentSystemTime, timeZoneInfo);
            return ConvertToRequiredFormat(timeZoneInCST);
        }

        private string ConvertToRequiredFormat(DateTime dateTime) 
        {
            var dateInRequiredFormat = dateTime.Date.ToShortDateString().Replace('-', '/');
            Logger.Log("Date in format required: " + dateInRequiredFormat);

            var timeInRequiredFormat = dateTime.TimeOfDay.Hours > 12 ? (dateTime.TimeOfDay.Hours - 12).ToString() + ":" + (dateTime.TimeOfDay.Minutes).ToString() + " PM" :
                                                                (dateTime.TimeOfDay.Hours).ToString() + ":" + (dateTime.TimeOfDay.Minutes).ToString() + " AM";
            Logger.Log("Time in format required: " + timeInRequiredFormat);

            return dateInRequiredFormat + " " + timeInRequiredFormat;
        }
    }
}
