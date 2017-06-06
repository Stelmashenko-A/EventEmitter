using System.Web.Script.Serialization;
using DataMiner.Services.Models;

namespace DataMiner.Services
{
    public class Parser
    {
        public RootObject Parse(string str)
        {
            var jss = new JavaScriptSerializer();
            return jss.Deserialize<RootObject>(str);
        }
    }
}