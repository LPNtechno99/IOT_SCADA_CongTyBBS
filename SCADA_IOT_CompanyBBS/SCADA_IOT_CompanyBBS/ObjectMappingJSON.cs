using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCADA_IOT_CompanyBBS
{
    public class ObjectMappingJSON
    {
        public List<DIVal> DIVal { get; set; }
    }
    public class DIVal
    {
        public int Ch { get; set; }
        public int Md { get; set; }
        public int Val { get; set; }
        public int Stat { get; set; }
        public int Cnting { get; set; }
        public int OvLch { get; set; }
    }

}
