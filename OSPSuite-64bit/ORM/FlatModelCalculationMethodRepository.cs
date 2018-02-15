using System.Collections.Generic;
using System.Linq;

namespace OSPSuite_64bit.ORM
{
   public class FlatModelCalculationMethodRepository : MetaDataRepository<FlatModelCalculationMethod>
   {

      public FlatModelCalculationMethodRepository(DbGateway dbGateway, IDataTableToMetaDataMapper<FlatModelCalculationMethod> mapper)
         : base(dbGateway, mapper, "VIEW_MODEL_CALCULATION_METHODS")
      {
      }


      public IEnumerable<string> ModelListFor(string calculationMethod)
      {
         return (from modelCalcMethod in All()
            where modelCalcMethod.CalculationMethod == calculationMethod
            select modelCalcMethod.Model).Distinct();
      }

      public FlatModelCalculationMethod By(string model, string calculationMethod)
      {
         return (from modelCalcMethod in All()
            where modelCalcMethod.CalculationMethod == calculationMethod
            where modelCalcMethod.Model == model
            select modelCalcMethod).First();
      }
   }

   public class FlatModelCalculationMethod
   {
      public string Model { get; set; }
      public string Category { get; set; }
      public string CalculationMethod { get; set; }
      public bool IsDefault { get; set; }
      public int Sequence { get; set; }
   }
}
