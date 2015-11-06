using System.Configuration;

namespace PayMaster.Framework.Utility.Static
{
    public static class ConfigStatic
    {
        public static readonly string PskwConnectionstring = CultureInfoFormat.ToString(ConfigurationManager.ConnectionStrings[Constant.PskwConnectionstring]);

        public static readonly string ApiBaseUrl = CultureInfoFormat.ToString(ConfigurationManager.ConnectionStrings["ApiBaseUrl"]);
    }
}
