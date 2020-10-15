using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SCADA_IOT_CompanyBBS.ViewModel
{
    public class SubItem
    {
        public SubItem(string name, int tag, UserControl screen = null)
        {
            Name = name;
            Screen = screen;
            Tag = tag;
        }
        public string Name { get; private set; }
        public int Tag { get; set; }
        public UserControl Screen { get; private set; }
    }
}
