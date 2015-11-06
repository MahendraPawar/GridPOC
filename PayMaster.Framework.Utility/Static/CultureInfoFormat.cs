using System;
using System.Globalization;

namespace PayMaster.Framework.Utility.Static
{
    public static class CultureInfoFormat
    {
        public static string ToString(object obj)
        {
            return Convert.ToString(obj, CultureInfo.InvariantCulture);
        }

        public static Int32 ToInt32(object obj)
        {

            return Convert.ToInt32(obj, CultureInfo.InvariantCulture);
        }


        public static Int64 ToInt64(object obj)
        {

            return Convert.ToInt64(obj, CultureInfo.InvariantCulture);
        }

        public static DateTime ToDateTime(object obj)
        {

            return Convert.ToDateTime(obj, CultureInfo.InvariantCulture);

        }

        public static bool ToBoolean(object obj)
        {

            return Convert.ToBoolean(obj, CultureInfo.InvariantCulture);

        }

        public static Int16 ToInt16(object obj)
        {

            return Convert.ToInt16(obj, CultureInfo.InvariantCulture);

        }

        public static double ToDouble(object obj)
        {

            return Convert.ToDouble(obj, CultureInfo.InvariantCulture);

        }

        public static decimal ToDecimal(object obj)
        {

            return Convert.ToDecimal(obj, CultureInfo.InvariantCulture);

        }


        public static byte ToByte(object obj)
        {
            return Convert.ToByte(obj, CultureInfo.InvariantCulture);

        }


    }

}


