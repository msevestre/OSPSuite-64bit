﻿using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using OSPSuite.TeXReporting;
using OSPSuite.TeXReporting.Builder;
using OSPSuite.Utility.Container;
using OSPSuite.Utility.Events;
using OSPSuite_64bit.ORM;

namespace OSPSuite_64bit
{
   public partial class Form1 : Form
   {
      public Form1()
      {
         InitializeComponent();
      }

      private void loadModelDataButton_Click(object sender, EventArgs e)
      {
         var modelDatabase = new ModelDatabase();

         // These work too, just wanted more than one
         //         var repository = new FlatApplicationProcessRepository(new DbGateway(modelDatabase), new DataTableToMetaDataMapper<FlatApplicationProcess>());
         //         var repository = new FlatCalculationMethodRepository(new DbGateway(modelDatabase), new DataTableToMetaDataMapper<FlatCalculationMethod>());

         // Right in the view
         var repository = new FlatModelCalculationMethodRepository(new DbGateway(modelDatabase), new DataTableToMetaDataMapper<FlatModelCalculationMethod>());
         flatModelCalculationMethods.DataSource = repository.All();

         // Raw query
         rawQueryDataGrid.DataSource = modelDatabase.FullTableFrom("SELECT * FROM tab_calculation_methods");
      }

      private async void generateReportButton_Click(object sender, EventArgs e)
      {
         var reportCreator = IoC.Resolve<IReportCreator>();
         var buildTrackerFactory = IoC.Resolve<IBuildTrackerFactory>();
         var reportSettings = new ReportSettings
         {
            Title = "Dummy",
            Author = "author mcauthorface",
            Keywords = new[] { "Tests", "PKReporting", "SBSuite" },
            Software = "SBSuite",
            SubTitle = "SubTitle",
            SoftwareVersion = "5.2",
            TemplateFolder = "..\\..\\StandardTemplate",
            ContentFileName = "Content",
            DeleteWorkingDir = true
         };
         var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "dummyreport.pdf");
         await reportCreator.ReportToPDF(buildTrackerFactory.CreateFor<BuildTracker>(path), reportSettings, new []{ "Hi"});
      }
   }

   public class EventPublisher : IEventPublisher
   {
      public void PublishEvent<T>(T eventToPublish)
      {
         
      }

      public void AddListener(IListener listenerToAdd)
      {
         
      }

      public void RemoveListener(IListener listenerToRemove)
      {
         
      }

      public bool Contains(IListener listener)
      {
         return false;
      }
   }
}
