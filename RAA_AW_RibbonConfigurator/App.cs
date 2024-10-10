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

            // create buttons
            PushButtonData btnConfig = cmdConfig.GetButtonData();
            PushButtonData btnData1 = Command1.GetButtonData();
            PushButtonData btnData2 = Command2.GetButtonData();

            // add buttons to panels
            foreach(clsTabData curTab in tabData)
            {
                foreach(RibbonPanel curPanel in curTab.Panels)
                {
                    if (curPanel.Name == "Config")
                        curPanel.AddItem(btnConfig);
                    else
                    {
                        curPanel.AddItem(btnData1);
                        curPanel.AddItem(btnData2);
                    }
                }
            }



            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication a)
        {
            return Result.Succeeded;
        }
    }

}
