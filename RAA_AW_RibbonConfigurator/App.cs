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

            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication a)
        {
            return Result.Succeeded;
        }
    }

}
