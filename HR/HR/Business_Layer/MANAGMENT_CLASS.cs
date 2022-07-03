using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace HR.Business_Layer
{
    class MANAGMENT_CLASS
    {
        // We will create an object from the data access layer class
        Data_Access_Layer.DataAccessLayer DAL = new Data_Access_Layer.DataAccessLayer();
        public DataTable Bring_Managements()
        {
            //DAL.open(); we dont need it because SQL DATA Adabter open and close the connection

            /* Now we will excute the stored procedure by calling the function SelectData
            and save its values in DataTable*/

            DataTable Dt = new DataTable();
            Dt = DAL.SelectData("SP_Bring_Managements", null);

            // Now we must close the connection

            DAL.close();
            // Now we will return the DataTable to the form which check the user information 
            return Dt;
        }

        // This is for delete a management
        public void DELETE_Managment(int ID)
        {
            DAL.open();
            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@ID", SqlDbType.Int);
            param[0].Value = ID;
            DAL.ExecuteCommand("DELETE_Managment", param);

            DAL.close();
        }
        // This is for Edit Managment
        public void EDIT_Managment(int Manag_ID, string Manag_Name)
        {
            DAL.open();
            SqlParameter[] param = new SqlParameter[2];

            param[0] = new SqlParameter("@ID", SqlDbType.Int);
            param[0].Value = Manag_ID;

            param[1] = new SqlParameter("@Name", SqlDbType.NVarChar, 50);
            param[1].Value = Manag_Name;

            DAL.ExecuteCommand("EDIT_Managment", param);

            DAL.close();
        }
        // This is for ADD Managment
        public void ADD_Managment(string Management_Name)
        {
            DAL.open();
            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@Name", SqlDbType.NVarChar, 50);
            param[0].Value = Management_Name;

            DAL.ExecuteCommand("ADD_Managment", param);

            DAL.close();
        }
        // This is For get Last Management ID
        public DataTable Get_Last_Management_ID()
        {
            DataTable Dt = new DataTable();
            Dt = DAL.SelectData("Get_Last_Management_ID", null);
            DAL.close();
            return Dt;
        }
    }
}
