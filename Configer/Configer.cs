using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configer
{
    public class Configer
    {
        internal static string dbConnName;
        internal static ConfigManage confm= new ConfigManage();
        public static void Init(string dbConnStr)
        {
            dbConnName = dbConnStr;
            confm.CheckOrCreateDb();
        }

        public static bool Set(string key,string value, string parentKey = "", string name ="",string desc ="",  int version =1)
        {
            var cc = new CenterConfiger()
            {
                Key = key,
                Value = value,
                Version = version,
                Name = name,
                Description = desc,
                AddTime = DateTime.Now,
                EditTime = DateTime.Now,
                Enable = true
            };
            return confm.AddConfig(cc,parentKey)>0;
        }

        public static CenterConfiger Get(string key)
        {
           return confm.GetConfig(key);
        }

        public static List<CenterConfiger> Gets(string key)
        {
            return confm.GetConfigs(key);
        }

    }
}
