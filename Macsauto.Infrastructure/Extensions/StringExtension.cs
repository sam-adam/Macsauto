namespace Macsauto.Infrastructure.Extensions
{
    public static class StringExtension
    {
        public static string ToCamelCase(this string value)
        {
            return char.ToLowerInvariant(value[0]) + value.Substring(1);
        }
    }
}
