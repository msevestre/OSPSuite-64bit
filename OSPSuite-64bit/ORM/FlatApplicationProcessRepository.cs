using System.Collections.Generic;
using System.Data;
using System.Linq;
using OSPSuite_64bit.das;

namespace OSPSuite_64bit.ORM
{
   public class FlatApplicationProcessRepository : MetaDataRepository<FlatApplicationProcess>
   {
      public FlatApplicationProcessRepository(DbGateway dbGateway,
         IDataTableToMetaDataMapper<FlatApplicationProcess> mapper)
         : base(dbGateway, mapper, "VIEW_APPLICATION_PROCESSES")
      { }

      public IEnumerable<string> ProcessNamesFor(string applicationName)
      {
         return from flatAppProcess in All()
            where flatAppProcess.Application.Equals(applicationName)
            select flatAppProcess.Process;
      }
   }

   public abstract class MetaDataRepository<T> : StartableRepository<T> where T : new()
   {
      private readonly DbGateway _dbGateway;
      private readonly IDataTableToMetaDataMapper<T> _mapper;
      private IList<T> _allElements;
      private readonly string _viewName;

      protected MetaDataRepository(DbGateway dbGateway, IDataTableToMetaDataMapper<T> mapper, string viewName)
      {
         _dbGateway = dbGateway;
         _mapper = mapper;
         _viewName = viewName;
      }

      public override IEnumerable<T> All()
      {
         Start();
         return _allElements;
      }

      protected override void DoStart()
      {
         var dt = _dbGateway.ExecuteStatementForDataTable($"SELECT * FROM {_viewName}");
         _allElements = new List<T>(_mapper.MapFrom(dt));
      }

      protected IEnumerable<T> AllElements()
      {
         return _allElements;
      }
   }

   public abstract class StartableRepository<T>
   {
      private bool _initialized;

      protected StartableRepository()
      {
         _initialized = false;
      }

      public void Start()
      {
         //not thread safe!
         if (_initialized) return;
         DoStart();
         _initialized = true;
         PerformPostStartProcessing();
      }

      /// <summary>
      ///    Action that can only be done once the repository has been intialized
      /// </summary>
      protected virtual void PerformPostStartProcessing()
      {
         /*  Override when required */
      }

      protected abstract void DoStart();
      public abstract IEnumerable<T> All();
   }

   public class DbGateway
   {
      private readonly IModelDatabase _modelDatabase;

      public DbGateway(IModelDatabase modelDatabase)
      {
         _modelDatabase = modelDatabase;
         _modelDatabase.Connect("PKSimDB.sqlite");
      }

      public virtual DataTable ExecuteStatementForDataTable(string selectStatement)
      {
         var dataTable = new DASDataTable(databaseConnection);
         databaseConnection.FillDataTable(dataTable, selectStatement);
         return dataTable;
      }

      private DAS databaseConnection
      {
         get { return _modelDatabase.DatabaseObject; }
      }
   }
}
