using ABB.Robotics.Controllers.RapidDomain;

namespace ABB_Comunication
{
    public static class ExtensionMethods
    {
        public static bool GetBool(this RapidData rapidData)
        {
            return ((Bool)rapidData.Value).Value;
        }

        public static double GetDouble(this RapidData rapidData)
        {
            return ((Num)rapidData.Value).Value;
        }
    }
}
