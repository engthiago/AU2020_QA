using AU2020_QA.Views;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Onbox.Abstractions.V8;
using Onbox.Revit.V8.Commands;

namespace AU2020_QA.Revit.Commands
{
    [Transaction(TransactionMode.Manual)]
    public class AUAsyncCommand : RevitAppCommand<App>
    {
        public override Result Execute(IContainerResolver container, ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            var ui = container.Resolve<AuAsync>();
            ui.Show();

            return Result.Succeeded;
        }
    }
}