using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace HR.Business_Layer
{
    class DEPARTEMNET_CLASS
    {
        // We will create an object from the data access layer class
        Data_Access_Layer.DataAccessLayer DAL = new Data_Access_Layer.DataAccessLayer();
        public DataTable Bring_Dept_With_Managemnt()
        {
            //DAL.open(); we dont need it because SQL DATA Adabter open and close the connection

            /* Now we will excute the stored procedure by calling the function SelectData
            and save its values in DataTable*/

            DataTable Dt = new DataTable();
            Dt = DAL.SelectData("SP_Bring_Dept_With_Managemnt", null);

            // Now we must close the connection

            DAL.close();
            // Now we will return the DataTable to the form which check the user information 
            return Dt;
        }
        // This is to bring the management of an department
        public DataTable Bring_Managemnt_by_Dept_ID(int ID)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID", SqlDbType.Int);
            param[0].Value = ID;
            DataTable Dt = new DataTable();
            Dt = DAL.SelectData("SP_Bring_Managemnt_by_Dept_ID", param);
            DAL.close();
            return Dt;
        }
        // This is For get Last Department ID
        public DataTable Get_Last_Dept_ID()
        {
            DataTable Dt = new DataTable();
            Dt = DAL.SelectData("Get_Last_Dept_ID", null);
            DAL.close();
            return Dt;
        }
        // This is for delete a department
        public void DELETE_Dept(int ID)
        {
            DAL.open();
            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@ID", SqlDbType.Int);
            param[0].Value = ID;
            DAL.ExecuteCommand("DELETE_Dept", param);

            DAL.close();
        }

        // This is for Edit Dept
        public void EDIT_Dept(int Dept_ID, string Dept_Name,int Mana_ID)
        {
            DAL.open();
            SqlParameter[] param = new SqlParameter[3];

            param[0] = new SqlParameter("@Dept_ID", SqlDbType.Int);
            param[0].Value = Dept_ID;

            param[1] = new SqlParameter("@Dept_Name", SqlDbType.NVarChar, 50);
            param[1].Value = Dept_Name;

            param[2] = new SqlParameter("@Mana_ID", SqlDbType.Int);
            param[2].Value = Mana_ID;

            DAL.ExecuteCommand("EDIT_Dept", param);

            DAL.close();
        }
        // This is for ADD Dept
        public void ADD_Dept(string Dept_Name,int Mana_ID)
        {
            DAL.open();
            SqlParameter[] param = new SqlParameter[2];

            param[0] = new SqlParameter("@Dept_Name", SqlDbType.NVarChar, 50);
            param[0].Value = Dept_Name;

            param[1] = new SqlParameter("@Mana_ID", SqlDbType.Int);
            param[1].Value = Mana_ID;

            DAL.ExecuteCommand("ADD_Dept", param);

            DAL.close();
        }
    }
}
