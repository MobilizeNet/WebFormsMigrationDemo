
namespace HiringTrackingSite
{
    public static class AppExtensions
    {
        public static string DataDirectory(this string str)
        {
            var connStringRaw = str;
            var connectionString = connStringRaw.Replace("|DataDirectory|", string.Empty + System.AppDomain.CurrentDomain.GetData("DataDirectory"));
            return connectionString;
        }
        public static ExtApplication ExtApp(this Mobilize.WebMap.Common.DCP.IApplication app) => app as ExtApplication;
        public static ExtApplication ExtApp(this object obj) => Mobilize.Web.UI.Application.CurrentApplication as ExtApplication;
    }
}

