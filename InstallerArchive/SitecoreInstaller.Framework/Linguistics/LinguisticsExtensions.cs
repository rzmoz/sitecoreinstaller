namespace SitecoreInstaller.Framework.Linguistics
{
    public static class LinguisticsExtensions
    {
        public static string AddIng(this string str)
        {
            if (str == null)
                str = string.Empty;
            return str + "ing";
        }
    }
}
