using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAA_AW_RibbonConfigurator
{
    internal class clsTabData
    {
        public string TabName { get; set; }
        public bool IsVisible { get; set; }
        public List<RibbonPanel> Panels { get; set; }
        public clsTabData(string _tabName)
        {
            TabName = _tabName;
            IsVisible = true;
        }
    }
}
