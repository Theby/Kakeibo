using System;
using System.Globalization;

public static class StringExtensions
{
    public static CultureInfo CLCulture = new CultureInfo("es-CL");

    public static string ToCurrencyString(this decimal value)
    {
        return value.ToString("C", CLCulture);
    }

    public static string ToCalendarDate(this DateTime datetime)
    {
        return datetime.ToString("yyyy/MM/dd");
    }
}