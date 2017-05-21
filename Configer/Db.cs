using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orm.Son.Core;

namespace Configer
{
    internal class Db : SonConnection
    {
        public Db() : base(Configer.dbConnName)
        {
        }
    }
}
