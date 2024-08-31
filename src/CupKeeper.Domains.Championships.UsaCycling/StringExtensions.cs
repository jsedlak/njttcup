using System.Globalization;
using System.Text.RegularExpressions;

namespace CupKeeper.Domains.Championships;

public static class StringExtensions
{
    private static readonly Regex CategoryPlacingRegex = new Regex(@"\s\(.*\)");

    // public static string ToPascalCase(this string s)
    // {
    //     return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(s);
    // }
    
    public static string StripCategoryPlacing(this string s)
    {
        return CategoryPlacingRegex.Replace(s, "");
    }
}