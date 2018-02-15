namespace OSPSuite_64bit.ORM
{
   public class FlatCalculationMethodRepository : MetaDataRepository<FlatCalculationMethod>
   {
      public FlatCalculationMethodRepository(DbGateway dbGateway, IDataTableToMetaDataMapper<FlatCalculationMethod> mapper)
         : base(dbGateway, mapper, "VIEW_CALCULATION_METHODS")
      {
      }
   }

   public class FlatCalculationMethod : FlatObject
   {
      public string Category { get; set; }
      public int Sequence { get; set; }
   }

   public abstract class FlatObject
   {
      public string Id { get; set; }
   }
}
