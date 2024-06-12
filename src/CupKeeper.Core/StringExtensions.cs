using System.Security.Cryptography;
using System.Text;

namespace CupKeeper;

public static class StringExtensions
{
    public static Guid ToGuid(this string input)
    {
        using var md5 = MD5.Create();

        byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
        return new Guid(hash);
    }
}