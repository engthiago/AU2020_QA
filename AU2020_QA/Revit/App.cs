using AU2020_QA.Revit.Commands;
using AU2020_QA.Revit.Commands.Availability;
using AU2020_QA.Views;
using Autodesk.Revit.UI;
using Onbox.Abstractions.V8;
using Onbox.Core.V8;
using Onbox.Mvc.Revit.V8;
using Onbox.Mvc.V8.Messaging;
using Onbox.Revit.V8;
using Onbox.Revit.V8.Applications;
using Onbox.Revit.V8.Async;
using Onbox.Revit.V8.UI;

namespace AU2020_QA.Revit
{
    [ContainerProvider("c7bda7df-6c34-4e75-bb25-fda71dee08b3")]
    public class App : RevitApp
    {
        public override void OnCreateRibbon(IRibbonManager ribbonManager)
        {
            // Here you can create Ribbon tabs, panels and buttons

            var br = ribbonManager.GetLineBreak();

            // Adds a Ribbon Panel to the Addins tab
            var addinPanelManager = ribbonManager.CreatePanel("AU2020_QA");
            addinPanelManager.AddPushButton<HelloCommand, AvailableOnProject>($"Hello{br}Framework", "onbox_logo");

            // Adds a new Ribbon Tab with a new Panel
            var panelManager = ribbonManager.CreatePanel("AU2020_QA", "Hello Panel");

            panelManager.AddPushButton<WPFViewCommand, AvailableOnProject>($"Hello{br}WPF", "autodesk_logo");

            panelManager.AddPushButton<AUAsyncCommand, AvailableOnProject>($"Async{br}Test", "onbox_logo");

        }

        public override Result OnStartup(IContainer container, UIControlledApplication application)
        {
            // Here you can add all necessary dependencies to the container

            container.AddOnboxCore();
            container.AddRevitMvc();

            // Registers IWPFView to the container
            // Views should ALWAYS be added as Transients
            container.AddTransient<IHelloWpfView, HelloWpfView>();

            // Adds MessageBoxService to the container
            container.AddSingleton<IMessageService, MessageBoxService>();

            container.AddRevitAsync(options =>
            {
                options.Name = "AU2020";
                options.IsJournalable = true;
            });

            return Result.Succeeded;
        }

        public override Result OnShutdown(IContainerResolver container, UIControlledApplication application)
        {
            // No Need to cleanup the Container, the framework will do it for you
            return Result.Succeeded;
        }
    }

}