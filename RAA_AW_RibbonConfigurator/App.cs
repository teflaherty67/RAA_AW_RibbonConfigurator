using RAA_AW_RibbonConfigurator.Common;

namespace RAA_AW_RibbonConfigurator
{
    internal class App : IExternalApplication
    {
        public static List<clsTabData> tabData = new List<clsTabData>();
        public static AdWin.RibbonControl ribbon;
        public Result OnStartup(UIControlledApplication app)
        {
            tabData = Utils.GetTabData();
            ribbon = AdWin.ComponentManager.Ribbon;

            // create ribbon tabs
            foreach(clsTabData curTab  in tabData)
            {
                try
                {
                    app.CreateRibbonTab(curTab.TabName);
                }
                catch (Exception)
                {
                    Debug.Print("Tab already exists");
                }

                // create panels
                curTab.Panels = new List<RibbonPanel>();
                curTab.Panels.Add(Utils.CreateRibbonPanel(app, curTab.TabName, "Config"));
                curTab.Panels.Add(Utils.CreateRibbonPanel(app, curTab.TabName, "Revit Tools"));
            }

            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication a)
        {
            return Result.Succeeded;
        }
    }

}
