using System;
using System.IO;
using OSPSuite_64bit.das;

namespace OSPSuite_64bit.ORM
{
   public interface IDatabase : IDisposable
   {
      void Connect(string databasePath);
      DAS DatabaseObject { get; }
      void Disconnect();
      bool IsConnected { get; }
   }

   public abstract class Database : IDatabase
   {
      public DAS DatabaseObject { get; private set; }
      private readonly string _userName;
      protected readonly string _password;

      protected Database(string password, string username)
      {
         _userName = username;
         _password = password;
         //create a default DAS in case the Connect was not called...
         DatabaseObject = new DAS();
      }

      public DASDataTable FullTableFrom(string query)
      {
         return DatabaseObject.CreateAndFillDataTable(query);
      }

      public void Connect(string databasePath)
      {
         //clear any open connection if already open
         Cleanup();

         if (DatabaseObject == null)
            DatabaseObject = new DAS();

         if (!FileExists(databasePath))
            throw new Exception($"File does not exist{databasePath}");

         DatabaseObject.Connect(databasePath, _userName, _password, GetProvider());
      }

      public static Func<string, bool> FileExists = fileFullPath =>
      {
         if (string.IsNullOrEmpty(fileFullPath))
            return false;

         var fileInfo = new FileInfo(fileFullPath);
         return fileInfo.Exists;
      };

      protected abstract DataProviders GetProvider();

      public void Disconnect()
      {
         if (!IsConnected) return;

         if (DatabaseObject.IsTransactionOpen)
            DatabaseObject.Rollback();

         try
         {
            DatabaseObject.DisConnect();
         }
         catch (Exception)
         {
            //Do nothing;
         }
      }

      public bool IsConnected
      {
         get
         {
            if (DatabaseObject == null) return false;
            return DatabaseObject.IsConnected;
         }
      }

      protected virtual void Cleanup()
      {
         Disconnect();
      }

      #region Disposable properties

      private bool _disposed;

      public void Dispose()
      {
         if (_disposed) return;

         Cleanup();
         GC.SuppressFinalize(this);
         _disposed = true;
      }

      ~Database()
      {
         Cleanup();
      }

      #endregion
   }

   public interface IModelDatabase : IDatabase
   {
   }

   public class ModelDatabase : SQLiteDatabase, IModelDatabase
   {
   }

   public abstract class SQLiteDatabase : Database
   {
      protected SQLiteDatabase(string password = null) : base(password, string.Empty)
      {
      }

      protected override DataProviders GetProvider()
      {
         return string.IsNullOrEmpty(_password) ? DataProviders.SQLite : DataProviders.MSAccessWithDatabaseSecurity;
      }
   }
}
