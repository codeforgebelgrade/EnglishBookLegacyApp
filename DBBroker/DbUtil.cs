using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace SummerSchoolsApp.DBBroker
{
    public class DbUtil
    {
        public string FormatDate(DateTime dateValue)
        {
            string dateStr = dateValue.Date.ToString(CultureInfo.GetCultureInfo("en-US"));
            return dateStr.Substring(0, dateStr.IndexOf(" "));
        }

        public string ChangeDateToSerbianFormat(string date)
        {
            char[] separatorParams = new char[1];
            separatorParams[0] = '/';
            string[] dateSplit = date.Split(separatorParams);
            string finalDate = dateSplit[1] + "/" + dateSplit[0] + "/" + dateSplit[2];

            return finalDate;
        }
    }
}
