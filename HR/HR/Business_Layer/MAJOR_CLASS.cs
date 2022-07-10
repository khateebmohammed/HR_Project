using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace HR.Business_Layer
{
    class MAJOR_CLASS
    {
        // We will create an object from the data access layer class
        Data_Access_Layer.DataAccessLayer DAL = new Data_Access_Layer.DataAccessLayer();
        public DataTable Bring_Majors()
        {
            //DAL.open(); we dont need it because SQL DATA Adabter open and close the connection

            /* Now we will excute the stored procedure by calling the function SelectData
            and save its values in DataTable*/

            DataTable Dt = new DataTable();
            Dt = DAL.SelectData("SP_Bring_Majors", null);

            // Now we must close the connection

            DAL.close();
            // Now we will return the DataTable to the form which check the user information 
            return Dt;
        }
        // This is for delete a major
        public void DELETE_Major(int ID)
        {
            DAL.open();
            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@ID", SqlDbType.Int);
            param[0].Value = ID;
            DAL.ExecuteCommand("DELETE_Major", param);

            DAL.close();
        }
        // This is for Edit Major
        public void EDIT_Major(int Major_ID, string Major_Name)
        {
            DAL.open();
            SqlParameter[] param = new SqlParameter[2];

            param[0] = new SqlParameter("@ID", SqlDbType.Int);
            param[0].Value = Major_ID;

            param[1] = new SqlParameter("@Name", SqlDbType.NVarChar, 50);
            param[1].Value = Major_Name;

            DAL.ExecuteCommand("EDIT_Major", param);

            DAL.close();
        }
        // This is for ADD Major
        public void ADD_Major(string Major_Name)
        {
            DAL.open();
            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@Name", SqlDbType.NVarChar, 50);
            param[0].Value = Major_Name;

            DAL.ExecuteCommand("ADD_Major", param);

            DAL.close();
        }
        // This is For get Last Major ID
        public DataTable Get_Last_Major_ID()
        {
            DataTable Dt = new DataTable();
            Dt = DAL.SelectData("Get_Last_Major_ID", null);
            DAL.close();
            return Dt;
        }
    }
}
