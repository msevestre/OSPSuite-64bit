using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using OSPSuite.FuncParser;
using OSPSuite.TeXReporting;
using OSPSuite.TeXReporting.Builder;
using OSPSuite.Utility.Container;
using OSPSuite.Utility.Events;
using OSPSuite_64bit.ORM;
using SimModelNET;

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
            TemplateFolder = ".\\StandardTemplate",
            ContentFileName = "Content",
            DeleteWorkingDir = true
         };
         var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "dummyreport.pdf");
         await reportCreator.ReportToPDF(buildTrackerFactory.CreateFor<BuildTracker>(path), reportSettings, new []{ "Hi"});
      }

      private void button1_Click(object sender, EventArgs e)
      {
         var parsedFunc = new ParsedFunction();

         parsedFunc.StringToParse = " ";
         parsedFunc.VariableNames = new List<string> {"x", "y", "z"};
         parsedFunc.ParameterNames = new List<string>{"p1", "p2"};
         parsedFunc.ParameterValues = new[] {0.0, 0.0};

         var errorData = new FuncParserErrorData();

         parsedFunc.Parse(errorData);

         if (errorData.ErrorNumber == errNumber.err_OK)
            MessageBox.Show(this, "That wasn't supposed to happen");
         else
            MessageBox.Show(this, $"Error is on purpose. The error is {errorData.ErrorNumber}");
      }

      private void button2_Click(object sender, EventArgs e)
      {
         var simulation = new Simulation();
         XMLSchemaCache.InitializeFromFile("OSPSuite.SimModel.xsd");
         simulation.LoadFromXMLFile(".\\SimModel4_ExampleInput05.xml");
         simulation.FinalizeSimulation();
         simulation.RunSimulation();

         MessageBox.Show("Finished");
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
