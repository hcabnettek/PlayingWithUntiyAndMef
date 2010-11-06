using System.Configuration;

namespace UnityDAL
{
    public partial class UnityDemoModelDataContext
    {
        public static UnityDemoModelDataContext Create()
        {
            return new UnityDemoModelDataContext(ConfigurationManager.ConnectionStrings["dal"].ConnectionString);
        }
        
    }
}