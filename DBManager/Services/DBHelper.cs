using System.Data.SqlClient;
using System.Data;
using System;

namespace JT.UniStuttgart.StudentLibrary.Logic.DBManagement.DBManager.Services
{
    public static class DBHelper
    {
        public static SqlCommand Command { get; set; }
        static SqlConnection Connection()
        {
            return new SqlConnection(
                new SqlConnectionStringBuilder()
                {
                    InitialCatalog = DBManagement.DBManager.Properties.Settings.Default.serverName,
                    DataSource = DBManagement.DBManager.Properties.Settings.Default.dataBase,
                    //UserID = DBManagement.DBManager.Properties.Settings.Default.userName,
                    //Password = DBManagement.DBManager.Properties.Settings.Default.password,
                    IntegratedSecurity = true
                }.ConnectionString) ;
        }
        static bool OpenConnection()
        {
            if (!DBisConnected())
            {
                try
                {
                    Connection().Open();
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }

            }
            return false;
        }
        static bool DBisConnected()
        {
            return !Connection().State.HasFlag(ConnectionState.Open) ? false : true;
        }
        static bool CloseConnection()
        {

            if (DBisConnected())
            {
                try
                {
                    Connection().Close();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }

            }
            return false;
        }
        public static bool ExecuteSqlQuery(string procedureName, Action assignCommandParamater)
        {
            try
            {
                Command = new SqlCommand(procedureName, Connection());
                Command.CommandType = CommandType.StoredProcedure;
                Command.Connection = Connection();
                if (OpenConnection())
                {
                    assignCommandParamater?.Invoke();
                    Command.ExecuteNonQuery();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                CloseConnection();
                return false;
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}
