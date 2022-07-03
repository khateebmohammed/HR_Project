using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HR.manage
{
    public partial class managePage : Form
    {

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
      (
          int nLeftRect,     // x-coordinate of upper-left corner
          int nTopRect,      // y-coordinate of upper-left corner
          int nRightRect,    // x-coordinate of lower-right corner
          int nBottomRect,   // y-coordinate of lower-right corner
          int nWidthEllipse, // width of ellipse
          int nHeightEllipse // height of ellipse
      );
        string saveState;
        Business_Layer.MANAGMENT_CLASS Mana_CLS = new Business_Layer.MANAGMENT_CLASS();
        public managePage()
        {
            InitializeComponent();
            DataTable Dt = Mana_CLS.Bring_Managements();
            List_Management.ValueMember = "Management_ID";
            List_Management.DisplayMember = "Management_name";
            List_Management.DataSource = Dt;
            
        }

        private void ManagePage_Load(object sender, EventArgs e)
        {
            List_Management.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, List_Management.Width, List_Management.Height, 10, 10));

        }

        private void Btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_Manag_Name.Text != "")
                {
                    if (saveState == "edit")
                    {
                        Mana_CLS.EDIT_Managment(Convert.ToInt32(List_Management.SelectedValue.ToString()), txt_Manag_Name.Text);
                        MessageBox.Show("تمت عملية التعديل بنجاح", "عملية التعديل", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                        DataTable Dt = Mana_CLS.Bring_Managements();
                        List_Management.DataSource = Dt;
                    }
                    else
                    {
                        Mana_CLS.ADD_Managment(txt_Manag_Name.Text);
                        MessageBox.Show("تمت عملية الحفظ بنجاح", "عملية الحفظ", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                        DataTable Dt = Mana_CLS.Bring_Managements();
                        List_Management.DataSource = Dt;
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
                DataTable Dt = Mana_CLS.Bring_Managements();
                List_Management.DataSource = Dt;
                txt_Manag_ID.Text = List_Management.SelectedValue.ToString();
                txt_Manag_Name.Text = List_Management.GetItemText(List_Management.SelectedItem);
                txt_Manag_Name.ReadOnly = true;
                btn_Save.Enabled = false;
                btn_Edit.Enabled = true;
                btn_Delete.Enabled = true;
                btn_Save.Text = "حفظ";
            }
        }

        private void Txt_Manag_ID_TextChanged(object sender, EventArgs e)
        {

        }

        private void List_Management_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_Manag_ID.Text = List_Management.SelectedValue.ToString();
            txt_Manag_Name.Text = List_Management.GetItemText(List_Management.SelectedItem);
            txt_Manag_Name.ReadOnly = true;
            btn_Save.Enabled = false;
            btn_Edit.Enabled = true;
            btn_Delete.Enabled = true;
            btn_Save.Text = "حفظ";
        }

        private void Btn_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("هل أنت متأكد من حذف الإدارة المحددة؟!!", "عملية الحذف", MessageBoxButtons.YesNo
                    , MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    Mana_CLS.DELETE_Managment(Convert.ToInt32(List_Management.SelectedValue.ToString()));
                    MessageBox.Show("تمت عملية الحذف بنجاح", "عملية الحذف", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    DataTable Dt = Mana_CLS.Bring_Managements();
                    List_Management.DataSource = Dt;
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
                DataTable Dt = Mana_CLS.Bring_Managements();
                List_Management.DataSource = Dt;
            }
        }

        private void Btn_Edit_Click(object sender, EventArgs e)
        {
            txt_Manag_Name.ReadOnly = false;
            txt_Manag_Name.Focus();
            btn_Save.Enabled = true;
            btn_Save.Text =("حفظ التعديل");
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
            txt_Manag_ID.Text=Mana_CLS.Get_Last_Management_ID().Rows[0][0].ToString();
            txt_Manag_Name.Clear();
            txt_Manag_Name.ReadOnly = false;
            txt_Manag_Name.Focus();
        }
    }
}
