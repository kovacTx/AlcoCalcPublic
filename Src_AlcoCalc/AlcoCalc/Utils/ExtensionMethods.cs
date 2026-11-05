using MudBlazor;
using System.Globalization;

namespace AlcoCalc.Utils;

public static class ExtensionMethods
{
    private static ISnackbar? snackbar;

    public static void Use(this ISnackbar s)
        => snackbar = s;
    public static void AsSuccess(this string message)
        => snackbar?.Add(message, Severity.Success);
    public static void AsWarning(this string message)
        => snackbar?.Add(message, Severity.Warning);
    public static void AsError(this string message)
        => snackbar?.Add(message, Severity.Error);
    public static void AsError(this Exception e)
        => AsError($"pre dané hodnoty {MapExceptionCode(e)}");

    public static string MapExceptionCode(Exception e)
    {
        var m = e.Message;
        var calculatorCode = m.Length <= 4 ? m : m[..4];
        return calculatorCode switch
        {
            "1A-1" => Pages.Calculations._1A_1.ErrMessage,
            "1A-2" => Pages.Calculations._1A_2.ErrMessage,
            "1A-3" => Pages.Calculations._1A_3.ErrMessage,
            "1A-4" => Pages.Calculations._1A_4.ErrMessage,
            "1A-5" => Pages.Calculations._1A_5.ErrMessage,
            "1A-6" => Pages.Calculations._1A_6.ErrMessage,
            "1A-7" => Pages.Calculations._1A_7.ErrMessage,
            "1A-8" => Pages.Calculations._1A_8.ErrMessage,

            "1B-1" => Pages.Calculations._1B_1.ErrMessage,
            "1B-2" => Pages.Calculations._1B_2.ErrMessage,

            "2-1" => Pages.Calculations._2_1.ErrMessage,
            "2-2" => Pages.Calculations._2_2.ErrMessage,
            "2-3" => Pages.Calculations._2_3.ErrMessage,
            "2-4" => Pages.Calculations._2_4.ErrMessage,
            _ => m,
        };
    }
    public static bool IsNullOrNan(this double? value)
    {
        if (value is null) return true;
        if (double.IsNaN(value.Value)) return true;
        return false;
    }
    public static double Clamp(this double d, double? min, double? max)
    {
        if (min.IsNullOrNan() && max.IsNullOrNan()) return d;
        else if (min.IsNullOrNan()) return Math.Max(d, max!.Value);
        else if (max.IsNullOrNan()) return Math.Min(d, min!.Value);
        else return Math.Clamp(d, min!.Value, max!.Value);
    }
    public static string FilterNumericInput(this string input)
    {
        if (string.IsNullOrEmpty(input))
            return string.Empty;

        int length = input.Length;
        Span<char> buffer = stackalloc char[length];
        int j = 0;
        bool hasDecimal = false;

        for (int i = 0; i < length; i++)
        {
            char c = input[i];

            if (c is >= '0' and <= '9')
                buffer[j++] = c;
            else if (c is '.' or ',' && !hasDecimal)
            {
                buffer[j++] = '.';
                hasDecimal = true;
            }
            else if (c == '-' && j == 0)
                buffer[j++] = c;
        }

        return new string(buffer[..j]);
    }
    public static string? Stringify0(this double? value)
        => value?.ToString("0.000000", CultureInfo.InvariantCulture);
    public static string? Stringify(this double? value)
        => value?.ToString("0.######", CultureInfo.InvariantCulture);
}
