using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIHost2host.Models.AppFrameworks
{
    public class CommonTools
    {
        public static string changeFormatDateMIRO(string date)
        {
            string result = string.Empty;
            string[] arr_date = date.Split('.');

            if (arr_date.Length > 2)
            {
                result = arr_date[2] + arr_date[1] + arr_date[0];
            }

            return result;
        }

        public static string GetAmountFormat(string currency)
        {
            string AmountFormat = string.Empty;
            switch (currency.Trim())
            {
                case "IDR":
                    AmountFormat = "{0:#,0}";
                    break;
                case "USD":
                    AmountFormat = "{0:#,0.00}";
                    break;
                case "USDN":
                    AmountFormat = "{0:#,0.0000}";
                    break;
                default:
                    AmountFormat = "{0:#,0.00}";
                    break;
            }
            return AmountFormat;
        }
    }
}