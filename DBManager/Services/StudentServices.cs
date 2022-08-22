using System.Data;
using System.Data.SqlClient;

namespace JT.UniStuttgart.StudentLibrary.Logic.DBManagement.DBManager.Services
{
    public static class StudentServices
    {
        // insert Student
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name">the student name</param>
        /// <param name="address"></param>
        /// <param name="phone"></param>
        /// <returns></returns>
        public static bool StudentInsert(string name, string address, string phone)
        {
            return DBHelper.ExecuteSqlQuery("Add_Student",
                () => AssignStudentInsertParameter(name, address, phone, DBHelper.Command));
        }
        static void AssignStudentInsertParameter(string name, string address, string phone, SqlCommand command)
        {
            command.Parameters.Add(@"Name", SqlDbType.NVarChar).Value = name;
            command.Parameters.Add(@"Address", SqlDbType.NVarChar).Value = address;
            command.Parameters.Add(@"Phone", SqlDbType.NVarChar).Value = phone;
        }
        // Delete Student
        public static bool StudentDelete(int id)
        {
            return DBHelper.ExecuteSqlQuery("Delete_Student",
                () => AssignStudentDeleteParameter(id, DBHelper.Command));
        }
        static void AssignStudentDeleteParameter(int id, SqlCommand command)
        {
            command.Parameters.Add(@"ID", SqlDbType.Int).Value = id;
        }
        // Update Student
        public static bool StudentUpdate(int id, string name, string address, string phone)
        {
            return DBHelper.ExecuteSqlQuery("Update_Student",
                () => AssignStudentUpdateParameter(id, name, address, phone, DBHelper.Command));
        }
        static void AssignStudentUpdateParameter(int id, string name, string address, string phone, SqlCommand command)
        {
            command.Parameters.Add(@"ID", SqlDbType.Int).Value = id;
            command.Parameters.Add(@"Name", SqlDbType.NVarChar).Value = name;
            command.Parameters.Add(@"Address", SqlDbType.NVarChar).Value = address;
            command.Parameters.Add(@"Phone", SqlDbType.NVarChar).Value = phone;
        }
        // get all Students
        public static bool StudentSelect()
        {
            return DBHelper.ExecuteSqlQuery("Get_Student", null);
        }
    }
}

