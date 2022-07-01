using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// تستخدم هذه المكتبة للتعامل مع قاعدة البيانات من نوع اس كيو ال سيرفر
using System.Data.SqlClient;
// هذه المكتبة تسمح لنا للتعامل مع البيانات مثل Data Set anf Data Get
using System.Data;
namespace HR.Data_Access_Layer
{
    class DataAccessLayer
    {
        SqlConnection sqlconnection;

        // This constructor Inisialize The connection Object
        public DataAccessLayer()
        {
            /* The name of the server=DESKTOP-UQ1F1OJ\SQLEXPRESS but if we want to make it
               work in another PC we delete 'DESKTOP-UQ1F1OJ' and write instead of it
               (localhost )or (.)
             */
            sqlconnection = new SqlConnection(@"Server=.\; Database=HR_Management; Integrated Security=true");
        }
        // Metod to open the connection
        public void open()
        {
            if (sqlconnection.State != ConnectionState.Open)
            {
                sqlconnection.Open();
            }
        }
        // Method to close the connection
        public void close()
        {
            if (sqlconnection.State == ConnectionState.Open)
            {
                sqlconnection.Close();
            }
        }
        // Method to read Data from DataBase
        /* This is a function contain the name of the srored procedure ,and we don't know
        how many parameter does the stored procedure have so we will use an array of the 
        type sqlparameter*/
        public DataTable SelectData(string stored_procedure, SqlParameter[] param)
        {
            // To excute the stored procedure

            SqlCommand sqlcmd = new SqlCommand();

            // We will assign the type of sqlcommand and it is stored procedure

            sqlcmd.CommandType = CommandType.StoredProcedure;

            // Now the name of the stored procedure which we will excute it

            sqlcmd.CommandText = stored_procedure;

            sqlcmd.Connection = sqlconnection;
            /* Check if the stored procedure has a parameters or not
            if there is we must  add them before excute the stored_procedure*/

            if (param != null)
            {
                for (int i = 0; i < param.Length; i++)
                {
                    sqlcmd.Parameters.Add(param[i]);
                }
            }

            // Now will we read the data which we get from executing the stored Procedure

            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            // to store the data
            DataTable dt = new DataTable();
            // fill the dt from the da
            da.Fill(dt);
            return dt;
        }

        // Method to Insert,Update ,And Delete Data From DataBase
        public void ExecuteCommand(string stored_procedure, SqlParameter[] param)
        {
            // To excute the stored procedure

            SqlCommand sqlcmd = new SqlCommand();

            // We will assign the type of sqlcommand and it is stored procedure

            sqlcmd.CommandType = CommandType.StoredProcedure;

            // Now the name of the stored procedure which we will excute it

            sqlcmd.CommandText = stored_procedure;

            sqlcmd.Connection = sqlconnection;

            /* Check if the stored procedure has a parameters or not
            if there is we must  add them before excute the stored_procedure*/

            if (param != null)
            {
                sqlcmd.Parameters.AddRange(param);
            }
            // Now we wall Excute the store Procedure
            sqlcmd.ExecuteNonQuery();
        }
    }

}
