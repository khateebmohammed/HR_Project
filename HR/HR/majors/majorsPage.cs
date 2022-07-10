using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HR.majors
{
    public partial class majorsPage : Form
    {
        Business_Layer.MAJOR_CLASS Major_CLS = new Business_Layer.MAJOR_CLASS();
        string saveState;
        public majorsPage()
        {
            InitializeComponent();
            DataTable Dt = Major_CLS.Bring_Majors();
            List_Majors.ValueMember = "Major_ID";
            List_Majors.DisplayMember = "Major_name";
            List_Majors.DataSource = Dt;
        }

        private void List_Majors_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_Major_ID.Text = List_Majors.SelectedValue.ToString();
            txt_Major_Name.Text = List_Majors.GetItemText(List_Majors.SelectedItem);
            txt_Major_Name.ReadOnly = true;
            btn_Save.Enabled = false;
            btn_Edit.Enabled = true;
            btn_Delete.Enabled = true;
            btn_Save.Text = "حفظ";
        }

        private void Btn_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("هل أنت متأكد من حذف المسمى الوظيفي المحدد؟!!", "عملية الحذف", MessageBoxButtons.YesNo
                    , MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    Major_CLS.DELETE_Major(Convert.ToInt32(List_Majors.SelectedValue.ToString()));
                    MessageBox.Show("تمت عملية الحذف بنجاح", "عملية الحذف", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    DataTable Dt = Major_CLS.Bring_Majors();
                    List_Majors.DataSource = Dt;
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
                DataTable Dt = Major_CLS.Bring_Majors();
                List_Majors.DataSource = Dt;
            }
        }

        private void Btn_Edit_Click(object sender, EventArgs e)
        {
            txt_Major_Name.ReadOnly = false;
            txt_Major_Name.Focus();
            btn_Save.Enabled = true;
            btn_Save.Text = ("حفظ التعديل");
            saveState = "edit";
            btn_Delete.Enabled = false;
        }

        private void Btn_New_Click(object sender, EventArgs e)
        {
            btn_Save.Text = "حفظ";
            saveState = "save";
            btn_Save.Enabled = true;
            btn_Edit.Enabled = false;
            btn_Delete.Enabled = false;
            txt_Major_ID.Text = Major_CLS.Get_Last_Major_ID().Rows[0][0].ToString();
            txt_Major_Name.Clear();
            txt_Major_Name.ReadOnly = false;
            txt_Major_Name.Focus();
        }

        private void Btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_Major_Name.Text != "")
                {
                    if (saveState == "edit")
                    {
                        Major_CLS.EDIT_Major(Convert.ToInt32(List_Majors.SelectedValue.ToString()), txt_Major_Name.Text);
                        MessageBox.Show("تمت عملية التعديل بنجاح", "عملية التعديل", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                        DataTable Dt = Major_CLS.Bring_Majors();
                        List_Majors.DataSource = Dt;
                    }
                    else
                    {
                        Major_CLS.ADD_Major(txt_Major_Name.Text);
                        MessageBox.Show("تمت عملية الحفظ بنجاح", "عملية الحفظ", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                        DataTable Dt = Major_CLS.Bring_Majors();
                        List_Majors.DataSource = Dt;
                    }
                }
                else
                {
                    MessageBox.Show("يجب إدخال أسم للمسمى الوظيفي", "تحذير", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }

            catch
            {
                MessageBox.Show("حصل خطأ ما ", "خطأ", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                DataTable Dt = Major_CLS.Bring_Majors();
                List_Majors.DataSource = Dt;
                txt_Major_ID.Text = List_Majors.SelectedValue.ToString();
                txt_Major_Name.Text = List_Majors.GetItemText(List_Majors.SelectedItem);
                txt_Major_Name.ReadOnly = true;
                btn_Save.Enabled = false;
                btn_Edit.Enabled = true;
                btn_Delete.Enabled = true;
                btn_Save.Text = "حفظ";
            }
        }
    }
}
