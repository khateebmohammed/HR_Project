﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HR
{
    public partial class Form1 : Form
    {
        Business_Layer.LOGIN_CLASS Log_Class = new Business_Layer.LOGIN_CLASS();

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


        public Form1()
        {
            InitializeComponent();
           
        }

        private void Label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 100,100));
            this.FormBorderStyle = FormBorderStyle.None;

            this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            DataTable Dt = Log_Class.LOGIN(txt_User_ID.Text, txt_User_PWD.Text);
            try
            {
                if (Dt.Rows.Count > 0)
                {
                    MessageBox.Show("تم تسجيل دخولك بنجاح", "تأكيد تسجيل الدخول", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    homeMain.page ob = new homeMain.page();
                    ob.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("أسم المستخدم أو كلمة المرور غير صحيحة أعد المحاولة!", "خطأ في تسجيل الدخول", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("حدث خطأ ما", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Label7_Click(object sender, EventArgs e)
        {

        }
    }
}
