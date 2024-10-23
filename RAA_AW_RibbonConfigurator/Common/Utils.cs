
namespace RAA_AW_RibbonConfigurator.Common
{
    internal static class Utils
    {
        internal static RibbonPanel CreateRibbonPanel(UIControlledApplication app, string tabName, string panelName)
        {
            RibbonPanel curPanel;

            if (GetRibbonPanelByName(app, tabName, panelName) == null)
                curPanel = app.CreateRibbonPanel(tabName, panelName);

            else
                curPanel = GetRibbonPanelByName(app, tabName, panelName);

            return curPanel;
        }

        internal static RibbonPanel GetRibbonPanelByName(UIControlledApplication app, string tabName, string panelName)
        {
            foreach (RibbonPanel tmpPanel in app.GetRibbonPanels(tabName))
            {
                if (tmpPanel.Name == panelName)
                    return tmpPanel;
            }

            return null;
        }

        internal static List<clsTabData> GetTabData()
        {
            List<clsTabData> m_returnTabList = new List<clsTabData>();
            List<string> m_tabNameList = Utils.GetTabNames();

            foreach (string curTabName in m_tabNameList)
            {
                m_returnTabList.Add(new clsTabData(curTabName));
            }

            return m_returnTabList;
        }

        private static List<string> GetTabNames()
        {
            return new List<string>
            {
                "RAA Architectural",
                "RAA Mechanical",
                "RAA Electrical",
                "RAA Plumbing",
                "RAA Structural"
            };
        }

        internal static string GetConfigPath()
        {
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string configPath = Path.Combine(path, "ribbon.config");

            return configPath;
        }

        private static void CreateConfigFile(string path)
        {
            // create the file
            using(StreamWriter writer = new StreamWriter(path))
            { 
                foreach(string curTabName in GetTabNames())
                {
                    writer.WriteLine(curTabName + ", Show");
                }
            }
        }
    }
}
