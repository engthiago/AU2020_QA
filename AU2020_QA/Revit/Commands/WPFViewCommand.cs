using AU2020_QA.Views;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Onbox.Abstractions.V8;
using Onbox.Revit.V8.Commands;

namespace AU2020_QA.Revit.Commands
{
    [Transaction(TransactionMode.Manual)]
    public class WPFViewCommand : RevitAppCommand<App>
    {
        public override Result Execute(IContainerResolver container, ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            // Asks the container for a new instance of a view
            var wpfView = container.Resolve<IHelloWpfView>();
            wpfView.ShowDialog();

            return Result.Succeeded;
        }
    }
}