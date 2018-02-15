using System;
using System.Windows.Forms;
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
   }
}
