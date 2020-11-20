using System;
using System.Windows;
using Autodesk.Revit.DB;
using Onbox.Mvc.Abstractions.V8;
using Onbox.Mvc.Revit.Abstractions.V8;
using Onbox.Mvc.Revit.V8;
using Onbox.Revit.Abstractions.V8;
using Onbox.Revit.V8;
using Onbox.Revit.V8.Async;

namespace AU2020_QA.Views
{
    /// <summary>
    /// A contract a view designed to have Revit as parent window
    /// </summary>
    public interface IAuAsync : IRevitMvcViewBase, IMvcViewModeless
    {
    }

    /// <summary>
    /// A view designed to have Revit as parent window
    /// </summary>
    public partial class AuAsync : RevitMvcViewBase, IAuAsync
    {
        private readonly IRevitEventHandler revitEventHandler;

        public AuAsync(IRevitAppData appData, IRevitEventHandler revitEventHandler) : base(appData)
        {
            InitializeComponent();
            this.revitEventHandler = revitEventHandler;
        }

        private void OnButtonClicked(object sender, RoutedEventArgs e)
        {
            this.revitEventHandler.RunAsync((app) =>
            {
                var doc = app.ActiveUIDocument.Document;
                this.ChangeDocInfo(doc);
            });
        }

        private void ChangeDocInfo(Document doc)
        {
            using (var t = new Transaction(doc, "Change Revit Project info"))
            {
                t.Start();

                doc.ProjectInformation.Author = "AU 2020";

                t.Commit();
            }
        }
    }
}