using System.Security.Cryptography;
using System.Text;

namespace Board.Api.Infrastructure;

public static class HashGenerator
{
    public static string Generate(string input)
    {
        using var md5 = MD5.Create();

        var encoding = Encoding.UTF8.GetBytes(input);
        var hash = md5.ComputeHash(encoding);

        var builder = new StringBuilder();

        foreach (var item in hash)
            builder.Append(item.ToString("x2"));

        return builder.ToString();
    }
}