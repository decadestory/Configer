using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orm.Son.Core;

namespace Configer
{
    internal class ConfigManage
    {
        public bool CheckOrCreateDb()
        {
            using (var db = new Db())
            {
                return db.CreateTable<CenterConfiger>();
            }
        }

        public int AddConfig(CenterConfiger cfg, string parentKey)
        {
            using (var db = new Db())
            {
                if (!string.IsNullOrEmpty(parentKey))
                {
                    var conf = GetConfig(parentKey);
                    cfg.ParentId = conf.Id;
                }

                var exist = db.Top<CenterConfiger>(t => t.Key == cfg.Key);
                if (exist == null)
                    return db.Insert(cfg);

                exist.Name = cfg.Name;
                exist.ParentId = cfg.ParentId;
                exist.Value = cfg.Value;
                exist.Version = cfg.Version;
                exist.Description = cfg.Description;
                exist.EditTime = DateTime.Now;
                return db.Update(exist);
            }
        }

        public CenterConfiger GetConfig(string key)
        {
            using (var db = new Db())
            {
                return db.Top<CenterConfiger>(t => t.Key == key);
            }
        }

        public List<CenterConfiger> GetConfigs(string key)
        {
            using (var db = new Db())
            {
                var cc = db.Top<CenterConfiger>(t => t.Key == key);
                return db.FindMany<CenterConfiger>(t => t.ParentId == cc.Id);
            }
        }

    }
}
