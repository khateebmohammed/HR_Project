using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HR.depts
{
    public partial class deptPage : Form
    {
        string saveState;
        Business_Layer.DEPARTEMNET_CLASS dept_CLS = new Business_Layer.DEPARTEMNET_CLASS();
        Business_Layer.MANAGMENT_CLASS mana_CLS = new Business_Layer.MANAGMENT_CLASS();
        public deptPage()
        {
            InitializeComponent();
            DataTable Dt = dept_CLS.Bring_Dept_With_Managemnt();
            List_Depts.ValueMember = "Dept_ID";
            List_Depts.DisplayMember = "Dept_name";
            List_Depts.DataSource = Dt;

        }

        private void List_Depts_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_Dept_ID.Text = List_Depts.SelectedValue.ToString();
            txt_Dept_Name.Text = List_Depts.GetItemText(List_Depts.SelectedItem);
            txt_Dept_Name.ReadOnly = true;
            btn_Save.Enabled = false;
            btn_Edit.Enabled = true;
            btn_Delete.Enabled = true;
            btn_Save.Text = "حفظ";
            cmb_Management.Enabled = false;
            DataTable Dt = dept_CLS.Bring_Managemnt_by_Dept_ID(Convert.ToInt32(List_Depts.SelectedValue.ToString()));
            cmb_Management.ValueMember = "Management_ID";
            cmb_Management.DisplayMember = "Management_Name";
            cmb_Management.DataSource = Dt;
        }

        private void Btn_New_Click(object sender, EventArgs e)
        {
            cmb_Management.Enabled = true;
            DataTable Dt = mana_CLS.Bring_Managements();
            cmb_Management.ValueMember = "Management_ID";
            cmb_Management.DisplayMember = "Management_Name";
            cmb_Management.DataSource = Dt;
            btn_Save.Text = "حفظ";
            saveState = "save";
            btn_Save.Enabled = true;
            btn_Edit.Enabled = false;
            btn_Delete.Enabled = false;
            txt_Dept_ID.Text = dept_CLS.Get_Last_Dept_ID().Rows[0][0].ToString();
            txt_Dept_Name.Clear();
            txt_Dept_Name.ReadOnly = false;
            txt_Dept_Name.Focus();
        }

        private void Btn_Edit_Click(object sender, EventArgs e)
        {
            cmb_Management.Enabled = true;
            DataTable Dt = mana_CLS.Bring_Managements();
            cmb_Management.ValueMember = "Management_ID";
            cmb_Management.DisplayMember = "Management_Name";
            cmb_Management.DataSource = Dt;
            txt_Dept_Name.ReadOnly = false;
            txt_Dept_Name.Focus();
            txt_Dept_Name.Focus();
            btn_Save.Enabled = true;
            btn_Save.Text = "حفظ التعديل";
            saveState = "edit";
            btn_Delete.Enabled = false;
        }

        private void Btn_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("هل أنت متأكد من حذف القسم المحدد؟!!", "عملية الحذف", MessageBoxButtons.YesNo
                    , MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    dept_CLS.DELETE_Dept(Convert.ToInt32(List_Depts.SelectedValue.ToString()));
                    MessageBox.Show("تمت عملية الحذف بنجاح", "عملية الحذف", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    DataTable Dt = dept_CLS.Bring_Dept_With_Managemnt();
                    List_Depts.DataSource = Dt;
                }
                else
                {
                    MessageBox.Show("تمت إلغاء عملية الحذف ", "عملية الحذف", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("هناك خطأ في عملية الحذف ", "خطأ", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                DataTable Dt = dept_CLS.Bring_Dept_With_Managemnt();
                List_Depts.DataSource = Dt;
            }
        }

        private void Btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_Dept_Name.Text != "")
                {
                    if (saveState == "edit")
                    {
                        dept_CLS.EDIT_Dept(Convert.ToInt32(List_Depts.SelectedValue.ToString()), txt_Dept_Name.Text
                            , Convert.ToInt32(cmb_Management.SelectedValue.ToString()));
                        MessageBox.Show("تمت عملية التعديل بنجاح", "عملية التعديل", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                        DataTable Dt = dept_CLS.Bring_Dept_With_Managemnt();
                        List_Depts.DataSource = Dt;
                    }
                    else
                    {
                        dept_CLS.ADD_Dept(txt_Dept_Name.Text, Convert.ToInt32(cmb_Management.SelectedValue.ToString()));
                        MessageBox.Show("تمت عملية الحفظ بنجاح", "عملية الحفظ", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                        DataTable Dt = dept_CLS.Bring_Dept_With_Managemnt();
                        List_Depts.DataSource = Dt;
                    }
                }
                else
                {
                    MessageBox.Show("يجب إدخال أسم للإدارة", "تحذير", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }

            catch
            {
                MessageBox.Show("حصل خطأ ما ", "خطأ", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                DataTable Dt = dept_CLS.Bring_Dept_With_Managemnt();
                List_Depts.DataSource = Dt;
                txt_Dept_ID.Text = List_Depts.SelectedValue.ToString();
                txt_Dept_Name.Text = List_Depts.GetItemText(List_Depts.SelectedItem);
                txt_Dept_Name.ReadOnly = true;
                cmb_Management.Enabled = false;
                btn_Save.Enabled = false;
                btn_Edit.Enabled = true;
                btn_Delete.Enabled = true;
                btn_Save.Text = "حفظ";
            }
        }
    }
}
