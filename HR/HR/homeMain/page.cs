using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace HR.homeMain
{
    public partial class page : Form
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


        public void allfalse()
        {
            panel18.Visible = false;
            panel11.Visible = false;
            panel9.Visible = false;
            panel13.Visible = false;
            panel15.Visible = false;
            panel15.Visible = false;
            panel21.Visible = false;
            panel17.Visible = false;

            panel27.Visible = false;
            panel29.Visible = false;
            panel30.Visible = false;
            panel31.Visible = false;
            panel32.Visible = false;




        }

        public page()
        {
            InitializeComponent();
        }



        private void Page_Load(object sender, EventArgs e)
        {
            this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            panel2.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, panel2.Width, panel2.Height, 25, 25));


             panel18.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, panel18.Width, panel18.Height, 8, 8));
            panel13.Region = panel18.Region;
            panel9.Region = panel18.Region;
            panel11.Region = panel18.Region;
            panel15.Region = panel18.Region;
            panel17.Region = panel18.Region;
            panel21.Region = panel18.Region;

            panel29.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, panel29.Width, panel29.Height, 12, 12));
            panel30.Region = panel29.Region;
            panel31.Region = panel29.Region;
            panel32.Region = panel29.Region;
            panel27.Region = panel29.Region;

            allfalse();


        }

        private void Button3_MouseMove(object sender, MouseEventArgs e)
        {
            //button1.BackColor = Color.MintCream;
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Label1_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void Label1_MouseLeave(object sender, EventArgs e)
        {

        }

        private void Panel5_MouseMove(object sender, MouseEventArgs e)
        {
            panel5.BackColor = Color.Silver;
        }

        private void Panel5_MouseLeave(object sender, EventArgs e)
        {
            panel5.BackColor = Color.MintCream;
        }

        private void Label1_MouseMove_1(object sender, MouseEventArgs e)
        {
            panel5.BackColor = Color.Silver;
        }

        private void Label1_MouseLeave_1(object sender, EventArgs e)
        {
            panel5.BackColor = Color.MintCream;

        }

        private void Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Button6_MouseMove(object sender, MouseEventArgs e)
        {
            panel18.Visible = true;
        }

        private void Button6_MouseLeave(object sender, EventArgs e)
        {
            panel18.Visible = false;

        }

        private void Button7_MouseMove(object sender, MouseEventArgs e)
        {

            panel11.Visible = true;

        }

        private void Button7_MouseLeave(object sender, EventArgs e)
        {
            panel11.Visible = false;

        }

        private void Button8_MouseMove(object sender, MouseEventArgs e)
        {
            panel9.Visible = true;

        }

        private void Button8_MouseLeave(object sender, EventArgs e)
        {
            panel9.Visible = false;

        }

        private void Button9_MouseMove(object sender, MouseEventArgs e)
        {
            panel13.Visible = true;
        }

        private void Button9_MouseLeave(object sender, EventArgs e)
        {
            panel13.Visible = false;
        }

        private void Button10_MouseMove(object sender, MouseEventArgs e)
        {
            panel17.Visible = true;
        }

        private void Button10_MouseLeave(object sender, EventArgs e)
        {
            panel17.Visible = false;
        }

        private void Button11_MouseMove(object sender, MouseEventArgs e)
        {
            panel15.Visible = true;
        }

        private void Button11_MouseLeave(object sender, EventArgs e)
        {
            panel15.Visible = false;
        }

        private void Button12_MouseMove(object sender, MouseEventArgs e)
        {
            panel21.Visible = true;
        }

        private void Button12_MouseLeave(object sender, EventArgs e)
        {
            panel21.Visible = false;

        }

        private void Button2_MouseMove(object sender, MouseEventArgs e)
        {
            panel27.Visible = true;
        }

        private void Button3_MouseMove_1(object sender, MouseEventArgs e)
        {
            panel29.Visible = true;
        }

        private void Button4_MouseMove(object sender, MouseEventArgs e)
        {
            panel30.Visible = true;

        }

        private void Button5_MouseMove(object sender, MouseEventArgs e)
        {
            panel31.Visible = true;

        }

        private void Button1_MouseMove(object sender, MouseEventArgs e)
        {
            panel32.Visible = true;

        }

        private void Button2_MouseLeave(object sender, EventArgs e)
        {
            panel27.Visible = false;

        }

        private void Button3_MouseLeave(object sender, EventArgs e)
        {
            panel29.Visible = false;

        }

        private void Button4_MouseLeave(object sender, EventArgs e)
        {
            panel30.Visible = false;

        }

        private void Button5_MouseLeave(object sender, EventArgs e)
        {
            panel31.Visible = false;

        }

        private void Button1_MouseLeave(object sender, EventArgs e)
        {
            panel32.Visible = false;

        }


        private Form activeform = null;
        private void openchildform(Form childform)
        {
            if (activeform!=null)
            {
                activeform.Close();
            }

            panel33.Controls.Clear();
            
            
            activeform = childform;
            childform.TopLevel = false;
            childform.FormBorderStyle = FormBorderStyle.None;
            childform.Dock = DockStyle.Fill;
            panel33.Controls.Add(childform);
            panel33.Tag = childform;
            childform.Show();







        }

        private void Button2_Click(object sender, EventArgs e)
        {
            openchildform(new manage.managePage());
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            openchildform(new depts.deptPage());
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            openchildform(new majors.majorsPage());
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            openchildform(new shiftWork.shiftWorkPage());
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            openchildform(new employees.empPage());
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            openchildform(new advance.imprestPage());
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            openchildform(new reward.rewardPage());

        }

        private void Button9_Click(object sender, EventArgs e)
        {
            openchildform(new vacation.vacationPage());

        }

        private void Button10_Click(object sender, EventArgs e)
        {
            openchildform(new productivity.productPage());

        }

        private void Button11_Click(object sender, EventArgs e)
        {
            attendance.attendPage ob = new attendance.attendPage();
            ob.ShowDialog();

        }

        private void Button7_Click(object sender, EventArgs e)
        {
            openchildform(new sanctions.sancPage());

        }

        private void Button12_Click(object sender, EventArgs e)
        {
            salaryPay.salPayPage ob = new salaryPay.salPayPage();
            ob.ShowDialog();

        }
    }
}
