using System.Globalization;

namespace Luma.Utilities.DateTimes;
/// <summary>
/// Converts English digits of a given number to their equivalent Persian digits.
/// </summary>
public static class PersianNumbersUtils
{
    /// <summary>
    /// Converts English digits of a given number to their equivalent Persian digits.
    /// </summary>
    public static string ToPersianNumbers(this int number, string format = "")
    {
        return (!string.IsNullOrEmpty(format) ?
                number.ToString(format) : number.ToString(CultureInfo.InvariantCulture)).ToPersianNumbers();
    }

    /// <summary>
    /// Converts English digits of a given number to their equivalent Persian digits.
    /// </summary>
    public static string ToPersianNumbers(this long number, string format = "")
    {
        return (!string.IsNullOrEmpty(format) ?
                number.ToString(format) : number.ToString(CultureInfo.InvariantCulture)).ToPersianNumbers();
    }

    /// <summary>
    /// Converts English digits of a given number to their equivalent Persian digits.
    /// </summary>
    public static string ToPersianNumbers(this int? number, string format = "")
    {
        if (!number.HasValue) number = 0;
        return (!string.IsNullOrEmpty(format) ?
                number.Value.ToString(format) : number.Value.ToString(CultureInfo.InvariantCulture)).ToPersianNumbers();
    }

    /// <summary>
    /// Converts English digits of a given number to their equivalent Persian digits.
    /// </summary>
    public static string ToPersianNumbers(this long? number, string format = "")
    {
        if (!number.HasValue) number = 0;
        return (!string.IsNullOrEmpty(format) ?
            number.Value.ToString(format) : number.Value.ToString(CultureInfo.InvariantCulture)).ToPersianNumbers();
    }

    /// <summary>
    /// Converts English digits of a given string to their equivalent Persian digits.
    /// </summary>
    /// <param name="data">English number</param>
    /// <returns></returns>
    public static string ToPersianNumbers(this string data)
    {
        if (string.IsNullOrWhiteSpace(data)) return string.Empty;
        return
           data
            .ToEnglishNumbers()
            .Replace("0", "\u06F0")
            .Replace("1", "\u06F1")
            .Replace("2", "\u06F2")
            .Replace("3", "\u06F3")
            .Replace("4", "\u06F4")
            .Replace("5", "\u06F5")
            .Replace("6", "\u06F6")
            .Replace("7", "\u06F7")
            .Replace("8", "\u06F8")
            .Replace("9", "\u06F9")
            .Replace(".", ",");
    }

    /// <summary>
    /// Converts Persian and Arabic digits of a given string to their equivalent English digits.
    /// </summary>
    /// <param name="data">Persian number</param>
    /// <returns></returns>
    public static string ToEnglishNumbers(this string data)
    {
        if (string.IsNullOrWhiteSpace(data)) return string.Empty;
        return
           data.Replace("\u0660", "0") //?
               .Replace("\u06F0", "0") //?
               .Replace("\u0661", "1") //?
               .Replace("\u06F1", "1") //?
               .Replace("\u0662", "2") //?
               .Replace("\u06F2", "2") //?
               .Replace("\u0663", "3") //?
               .Replace("\u06F3", "3") //?
               .Replace("\u0664", "4") //?
               .Replace("\u06F4", "4") //?
               .Replace("\u0665", "5") //?
               .Replace("\u06F5", "5") //?
               .Replace("\u0666", "6") //?
               .Replace("\u06F6", "6") //?
               .Replace("\u0667", "7") //?
               .Replace("\u06F7", "7") //?
               .Replace("\u0668", "8") //?
               .Replace("\u06F8", "8") //?
               .Replace("\u0669", "9") //?
               .Replace("\u06F9", "9") //?
               ;
    }
}


