using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace HR.Business_Layer
{
    class LOGIN_CLASS
    {
        public DataTable LOGIN(string ID, string PWD)
        {
            // We will create an object from the data access layer class
            Data_Access_Layer.DataAccessLayer DAL = new Data_Access_Layer.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[2];

            param[0] = new SqlParameter("@ID", SqlDbType.NVarChar, 50);
            param[0].Value = ID;
            param[1] = new SqlParameter("@PWD", SqlDbType.NVarChar, 50);
            param[1].Value = PWD;

            // Now we will open the connection

            //DAL.open(); we dont need it because SQL DATA Adabter open and close the connection           

            /* Now we will excute the stored procedure by calling the function SelectData
            and save its values in DataTable*/

            DataTable Dt = new DataTable();
            Dt = DAL.SelectData("SP_LOGIN", param);

            // Now we must close the connection

            DAL.close();
            // Now we will return the DataTable to the form which check the user information 
            return Dt;
        }
    }
}
