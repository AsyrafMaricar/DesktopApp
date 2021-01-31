using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Dashboard.Properties;

namespace Dashboard
{
    public partial class Form1 : Form
    {
        public Point downPoint = Point.Empty;

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
         (
               int nLeftRect,
               int nTopRect,
               int nRightRect,
               int nBottomRect,
               int nWidthEllipse,
               int nHeightEllipse
         );

        protected override void OnLoad(EventArgs e)
        {
            if (FormBorderStyle == System.Windows.Forms.FormBorderStyle.None)
            {
                MouseDown += new MouseEventHandler(AppFormBase_MouseDown);
                MouseMove += new MouseEventHandler(AppFormBase_MouseMove);
                MouseUp += new MouseEventHandler(AppFormBase_MouseUp);
            }

            base.OnLoad(e);
        }

        private void AppFormBase_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                downPoint = new Point(e.X, e.Y);
        }
        private void AppFormBase_MouseMove(object sender, MouseEventArgs e)
        {
            if (downPoint != Point.Empty)
                Location = new Point(Left + e.X - downPoint.X, Top + e.Y -downPoint.Y);
        }
        private void AppFormBase_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                downPoint = Point.Empty;
        }


        public Form1()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            pnlNav.Height = btnHomePage.Height;
            pnlNav.Top = btnHomePage.Top;
            pnlNav.Left = btnHomePage.Left;

            lbltitle.Text = "Home Page";
            this.PanelFormLoader.Controls.Clear();
            frmMainPage FrmMainPage_Vrb = new frmMainPage() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FrmMainPage_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.PanelFormLoader.Controls.Add(FrmMainPage_Vrb);
            FrmMainPage_Vrb.Show();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();

        }

        private void btnHomePage_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnHomePage.Height;
            pnlNav.Top = btnHomePage.Top;
            btnHomePage.BackColor = Color.FromArgb(46, 51, 73);

            lbltitle.Text = "Home Page";
            this.PanelFormLoader.Controls.Clear();
            frmMainPage FrmMainPage_Vrb = new frmMainPage() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FrmMainPage_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.PanelFormLoader.Controls.Add(FrmMainPage_Vrb);
            FrmMainPage_Vrb.Show();
        }

        private void btnEnv101_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnEnv101.Height;
            pnlNav.Top = btnEnv101.Top;
            btnEnv101.BackColor = Color.FromArgb(46, 51, 73);

            lbltitle.Text = btnEnv101.Text;
            this.PanelFormLoader.Controls.Clear();
            frmAlerts FrmAlerts_Vrb = new frmAlerts() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FrmAlerts_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.PanelFormLoader.Controls.Add(FrmAlerts_Vrb);
            FrmAlerts_Vrb.Show();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnSettings.Height;
            pnlNav.Top = btnSettings.Top;
            btnSettings.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void btnDashboard_Leave(object sender, EventArgs e)
        {
            btnHomePage.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnSettings_Leave(object sender, EventArgs e)
        {
            btnSettings.BackColor = Color.FromArgb(24, 30, 54);
        }
        private void btnEnv101_Leave(object sender, EventArgs e)
        {
            btnEnv101.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnExitApp_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime datetime = DateTime.Now;
            this.DateTimeLabel.Text = datetime.ToString();
        }

        private bool grp1Collapsed, grp2Collapsed, grp3Collapsed;
        public static string jsonURL;

        private void btnGrp1_Click(object sender, EventArgs e)
        {
            //Check for collapse
            if (panelGrp1.Size == panelGrp1.MinimumSize)
            {
                grp1Collapsed = true;
            } else
            {
                grp1Collapsed = false;
            }

            panelGrp1.BringToFront();
            panelGrp2.SendToBack();


            //If panel is collapsed, expand and move to the top. If expanded, collapse and move to original spot
            if (grp1Collapsed == true)
            {
                btnGrp1.Image = Resources.arrowup_24;
                panelGrp1.Location = new Point(0, 154);
                panelGrp1.Height = panelGrp1.MaximumSize.Height;
                btnGrp1.BackColor = Color.FromArgb(46, 51, 73);

            } else
            {
                btnGrp1.Image = Resources.arrow_211_24;
                panelGrp1.Location = new Point(0, 196);
                panelGrp1.Height = panelGrp1.MinimumSize.Height;
                btnGrp1.BackColor = Color.FromArgb(24, 30, 54);
            }
        }

        private void btnEnv1_Click(object sender, EventArgs e)
        {
            jsonURL = "https://meter.m1sensordata.com/sensirionPHP/getenv15.php?n";

            lbltitle.Text = btnEnv1.Text;
            this.PanelFormLoader.Controls.Clear();
            frmDashboard FrmDashboard_Vrb = new frmDashboard() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FrmDashboard_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.PanelFormLoader.Controls.Add(FrmDashboard_Vrb);
            FrmDashboard_Vrb.Show();
        }

        private void btnEnv2_Click(object sender, EventArgs e)
        {
            jsonURL = "https://meter.m1sensordata.com/sensirionPHP/getenv15.php?n";

            lbltitle.Text = btnEnv2.Text;
            this.PanelFormLoader.Controls.Clear();
            frmDashboard FrmDashboard_Vrb = new frmDashboard() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FrmDashboard_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.PanelFormLoader.Controls.Add(FrmDashboard_Vrb);
            FrmDashboard_Vrb.Show();
        }

        private void btnEnv3_Click(object sender, EventArgs e)
        {
            jsonURL = "https://meter.m1sensordata.com/sensirionPHP/getenv15.php?n";

            lbltitle.Text = btnEnv3.Text;
            this.PanelFormLoader.Controls.Clear();
            frmDashboard FrmDashboard_Vrb = new frmDashboard() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FrmDashboard_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.PanelFormLoader.Controls.Add(FrmDashboard_Vrb);
            FrmDashboard_Vrb.Show();
        }

        private void btnEnv4_Click(object sender, EventArgs e)
        {
            jsonURL = "https://meter.m1sensordata.com/sensirionPHP/getenv15.php?n";

            lbltitle.Text = btnEnv4.Text;
            this.PanelFormLoader.Controls.Clear();
            frmDashboard FrmDashboard_Vrb = new frmDashboard() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FrmDashboard_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.PanelFormLoader.Controls.Add(FrmDashboard_Vrb);
            FrmDashboard_Vrb.Show();
        }

        private void btnEnv5_Click(object sender, EventArgs e)
        {
            jsonURL = "https://meter.m1sensordata.com/sensirionPHP/getenv15.php?n";

            lbltitle.Text = btnEnv5.Text;
            this.PanelFormLoader.Controls.Clear();
            frmDashboard FrmDashboard_Vrb = new frmDashboard() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FrmDashboard_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.PanelFormLoader.Controls.Add(FrmDashboard_Vrb);
            FrmDashboard_Vrb.Show();
        }

        private void btnEnv6_Click(object sender, EventArgs e)
        {
            jsonURL = "https://meter.m1sensordata.com/sensirionPHP/getenv15.php?n";

            lbltitle.Text = btnEnv6.Text;
            this.PanelFormLoader.Controls.Clear();
            frmDashboard FrmDashboard_Vrb = new frmDashboard() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FrmDashboard_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.PanelFormLoader.Controls.Add(FrmDashboard_Vrb);
            FrmDashboard_Vrb.Show();
        }

        private void btnEnv7_Click(object sender, EventArgs e)
        {
            jsonURL = "https://meter.m1sensordata.com/sensirionPHP/getenv15.php?n";

            lbltitle.Text = btnEnv7.Text;
            this.PanelFormLoader.Controls.Clear();
            frmDashboard FrmDashboard_Vrb = new frmDashboard() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FrmDashboard_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.PanelFormLoader.Controls.Add(FrmDashboard_Vrb);
            FrmDashboard_Vrb.Show();
        }

        private void btnEnv8_Click(object sender, EventArgs e)
        {
            jsonURL = "https://meter.m1sensordata.com/sensirionPHP/getenv15.php?n";

            lbltitle.Text = btnEnv8.Text;
            this.PanelFormLoader.Controls.Clear();
            frmDashboard FrmDashboard_Vrb = new frmDashboard() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FrmDashboard_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.PanelFormLoader.Controls.Add(FrmDashboard_Vrb);
            FrmDashboard_Vrb.Show();
        }

        private void btnEnv9_Click(object sender, EventArgs e)
        {
            jsonURL = "https://meter.m1sensordata.com/sensirionPHP/getenv15.php?n";

            lbltitle.Text = btnEnv9.Text;
            this.PanelFormLoader.Controls.Clear();
            frmDashboard FrmDashboard_Vrb = new frmDashboard() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FrmDashboard_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.PanelFormLoader.Controls.Add(FrmDashboard_Vrb);
            FrmDashboard_Vrb.Show();
        }

        private void btnEnv10_Click(object sender, EventArgs e)
        {
            jsonURL = "https://meter.m1sensordata.com/sensirionPHP/getenv15.php?n";

            lbltitle.Text = btnEnv10.Text;
            this.PanelFormLoader.Controls.Clear();
            frmDashboard FrmDashboard_Vrb = new frmDashboard() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FrmDashboard_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.PanelFormLoader.Controls.Add(FrmDashboard_Vrb);
            FrmDashboard_Vrb.Show();
        }

        private void btnGrp2_Click(object sender, EventArgs e)
        {
            //Check for collapse
            if (panelGrp2.Size == panelGrp2.MinimumSize)
            {
                grp2Collapsed = true;
            }
            else
            {
                grp2Collapsed = false;
            }

            panelGrp2.BringToFront();
            panelGrp1.SendToBack();

            //If panel is collapsed, expand and move to the top. If expanded, collapse and move to original spot
            if (grp2Collapsed == true)
            {
                btnGrp2.Image = Resources.arrowup_24;
                panelGrp2.Location = new Point(0, 154);
                panelGrp2.Height = panelGrp2.MaximumSize.Height;
                btnGrp2.BackColor = Color.FromArgb(46, 51, 73);
            }
            else
            {
                btnGrp2.Image = Resources.arrow_211_24;
                panelGrp2.Location = new Point(0, 238);
                panelGrp2.Height = panelGrp2.MinimumSize.Height;
                btnGrp2.BackColor = Color.FromArgb(24, 30, 54);
            }
        }

        private void btnEnv11_Click(object sender, EventArgs e)
        {
            btnEnv11.BackColor = Color.FromArgb(46, 51, 73);

            jsonURL = "https://meter.m1sensordata.com/sensirionPHP/getenv16.php?n";

            lbltitle.Text = btnEnv11.Text;
            this.PanelFormLoader.Controls.Clear();
            frmDashboard FrmDashboard_Vrb = new frmDashboard() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FrmDashboard_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.PanelFormLoader.Controls.Add(FrmDashboard_Vrb);
            FrmDashboard_Vrb.Show();
        }

        private void btnEnv12_Click(object sender, EventArgs e)
        {

            jsonURL = "https://meter.m1sensordata.com/sensirionPHP/getenv16.php?n";

            lbltitle.Text = btnEnv12.Text;
            this.PanelFormLoader.Controls.Clear();
            frmDashboard FrmDashboard_Vrb = new frmDashboard() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FrmDashboard_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.PanelFormLoader.Controls.Add(FrmDashboard_Vrb);
            FrmDashboard_Vrb.Show();
        }

        private void btnEnv13_Click(object sender, EventArgs e)
        {

            jsonURL = "https://meter.m1sensordata.com/sensirionPHP/getenv16.php?n";

            lbltitle.Text = btnEnv13.Text;
            this.PanelFormLoader.Controls.Clear();
            frmDashboard FrmDashboard_Vrb = new frmDashboard() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FrmDashboard_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.PanelFormLoader.Controls.Add(FrmDashboard_Vrb);
            FrmDashboard_Vrb.Show();
        }

        private void btnEnv14_Click(object sender, EventArgs e)
        {

            jsonURL = "https://meter.m1sensordata.com/sensirionPHP/getenv16.php?n";

            lbltitle.Text = btnEnv14.Text;
            this.PanelFormLoader.Controls.Clear();
            frmDashboard FrmDashboard_Vrb = new frmDashboard() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FrmDashboard_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.PanelFormLoader.Controls.Add(FrmDashboard_Vrb);
            FrmDashboard_Vrb.Show();
        }

        private void btnEnv15_Click(object sender, EventArgs e)
        {

            jsonURL = "https://meter.m1sensordata.com/sensirionPHP/getenv15.php?n";

            lbltitle.Text = btnEnv15.Text;
            this.PanelFormLoader.Controls.Clear();
            frmDashboard FrmDashboard_Vrb = new frmDashboard() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FrmDashboard_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.PanelFormLoader.Controls.Add(FrmDashboard_Vrb);
            FrmDashboard_Vrb.Show();
        }

        private void btnEnv16_Click(object sender, EventArgs e)
        {

            jsonURL = "https://meter.m1sensordata.com/sensirionPHP/getenv16.php?n";

            lbltitle.Text = btnEnv16.Text;
            this.PanelFormLoader.Controls.Clear();
            frmDashboard FrmDashboard_Vrb = new frmDashboard() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FrmDashboard_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.PanelFormLoader.Controls.Add(FrmDashboard_Vrb);
            FrmDashboard_Vrb.Show();
        }

        private void btnEnv17_Click(object sender, EventArgs e)
        {

            jsonURL = "https://meter.m1sensordata.com/sensirionPHP/getenv17.php?n";

            lbltitle.Text = btnEnv17.Text;
            this.PanelFormLoader.Controls.Clear();
            frmDashboard FrmDashboard_Vrb = new frmDashboard() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FrmDashboard_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.PanelFormLoader.Controls.Add(FrmDashboard_Vrb);
            FrmDashboard_Vrb.Show();
        }

        private void btnEnv18_Click(object sender, EventArgs e)
        {

            jsonURL = "https://meter.m1sensordata.com/sensirionPHP/getenv18.php?n";

            lbltitle.Text = btnEnv18.Text;
            this.PanelFormLoader.Controls.Clear();
            frmDashboard FrmDashboard_Vrb = new frmDashboard() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FrmDashboard_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.PanelFormLoader.Controls.Add(FrmDashboard_Vrb);
            FrmDashboard_Vrb.Show();
        }

        private void btnEnv19_Click(object sender, EventArgs e)
        {

            jsonURL = "https://meter.m1sensordata.com/sensirionPHP/getenv16.php?n";

            lbltitle.Text = btnEnv19.Text;
            this.PanelFormLoader.Controls.Clear();
            frmDashboard FrmDashboard_Vrb = new frmDashboard() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FrmDashboard_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.PanelFormLoader.Controls.Add(FrmDashboard_Vrb);
            FrmDashboard_Vrb.Show();
        }

        private void btnEnv20_Click(object sender, EventArgs e)
        {

            jsonURL = "https://meter.m1sensordata.com/sensirionPHP/getenv16.php?n";

            lbltitle.Text = btnEnv20.Text;
            this.PanelFormLoader.Controls.Clear();
            frmDashboard FrmDashboard_Vrb = new frmDashboard() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FrmDashboard_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.PanelFormLoader.Controls.Add(FrmDashboard_Vrb);
            FrmDashboard_Vrb.Show();
        }

        private void btnGrp3_Click(object sender, EventArgs e)
        {
            //Check for collapse
            if (panelGrp3.Size == panelGrp3.MinimumSize)
            {
                grp3Collapsed = true;
            }
            else
            {
                grp3Collapsed = false;
            }

            panelGrp3.BringToFront();
            panelGrp1.SendToBack();
            panelGrp2.SendToBack();


            //If panel is collapsed, expand and move to the top. If expanded, collapse and move to original spot
            if (grp3Collapsed == true)
            {
                btnGrp3.Image = Resources.arrowup_24;
                panelGrp3.Location = new Point(0, 154);
                panelGrp3.Height = panelGrp3.MaximumSize.Height;
                btnGrp3.BackColor = Color.FromArgb(46, 51, 73);

            }
            else
            {
                btnGrp3.Image = Resources.arrow_211_24;
                panelGrp3.Location = new Point(0, 280);
                panelGrp3.Height = panelGrp3.MinimumSize.Height;
                btnGrp3.BackColor = Color.FromArgb(24, 30, 54);
            }
        }

        private void btnEnv21_Click(object sender, EventArgs e)
        {
            jsonURL = "https://meter.m1sensordata.com/sensirionPHP/getenv17.php?n";

            lbltitle.Text = btnEnv21.Text;
            this.PanelFormLoader.Controls.Clear();
            frmDashboard FrmDashboard_Vrb = new frmDashboard() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FrmDashboard_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.PanelFormLoader.Controls.Add(FrmDashboard_Vrb);
            FrmDashboard_Vrb.Show();
        }

        private void btnEnv22_Click(object sender, EventArgs e)
        {
            jsonURL = "https://meter.m1sensordata.com/sensirionPHP/getenv17.php?n";

            lbltitle.Text = btnEnv22.Text;
            this.PanelFormLoader.Controls.Clear();
            frmDashboard FrmDashboard_Vrb = new frmDashboard() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FrmDashboard_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.PanelFormLoader.Controls.Add(FrmDashboard_Vrb);
            FrmDashboard_Vrb.Show();
        }

        private void btnEnv23_Click(object sender, EventArgs e)
        {
            jsonURL = "https://meter.m1sensordata.com/sensirionPHP/getenv17.php?n";

            lbltitle.Text = btnEnv23.Text;
            this.PanelFormLoader.Controls.Clear();
            frmDashboard FrmDashboard_Vrb = new frmDashboard() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FrmDashboard_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.PanelFormLoader.Controls.Add(FrmDashboard_Vrb);
            FrmDashboard_Vrb.Show();
        }

        private void btnEnv24_Click(object sender, EventArgs e)
        {
            jsonURL = "https://meter.m1sensordata.com/sensirionPHP/getenv17.php?n";

            lbltitle.Text = btnEnv24.Text;
            this.PanelFormLoader.Controls.Clear();
            frmDashboard FrmDashboard_Vrb = new frmDashboard() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FrmDashboard_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.PanelFormLoader.Controls.Add(FrmDashboard_Vrb);
            FrmDashboard_Vrb.Show();
        }

        private void btnEnv25_Click(object sender, EventArgs e)
        {
            jsonURL = "https://meter.m1sensordata.com/sensirionPHP/getenv17.php?n";

            lbltitle.Text = btnEnv25.Text;
            this.PanelFormLoader.Controls.Clear();
            frmDashboard FrmDashboard_Vrb = new frmDashboard() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FrmDashboard_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.PanelFormLoader.Controls.Add(FrmDashboard_Vrb);
            FrmDashboard_Vrb.Show();
        }

        private void btnEnv26_Click(object sender, EventArgs e)
        {
            jsonURL = "https://meter.m1sensordata.com/sensirionPHP/getenv17.php?n";

            lbltitle.Text = btnEnv26.Text;
            this.PanelFormLoader.Controls.Clear();
            frmDashboard FrmDashboard_Vrb = new frmDashboard() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FrmDashboard_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.PanelFormLoader.Controls.Add(FrmDashboard_Vrb);
            FrmDashboard_Vrb.Show();
        }

        private void btnEnv27_Click(object sender, EventArgs e)
        {
            jsonURL = "https://meter.m1sensordata.com/sensirionPHP/getenv17.php?n";

            lbltitle.Text = btnEnv27.Text;
            this.PanelFormLoader.Controls.Clear();
            frmDashboard FrmDashboard_Vrb = new frmDashboard() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FrmDashboard_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.PanelFormLoader.Controls.Add(FrmDashboard_Vrb);
            FrmDashboard_Vrb.Show();
        }

        private void btnEnv28_Click(object sender, EventArgs e)
        {
            jsonURL = "https://meter.m1sensordata.com/sensirionPHP/getenv17.php?n";

            lbltitle.Text = btnEnv28.Text;
            this.PanelFormLoader.Controls.Clear();
            frmDashboard FrmDashboard_Vrb = new frmDashboard() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FrmDashboard_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.PanelFormLoader.Controls.Add(FrmDashboard_Vrb);
            FrmDashboard_Vrb.Show();
        }

        private void btnEnv29_Click(object sender, EventArgs e)
        {
            jsonURL = "https://meter.m1sensordata.com/sensirionPHP/getenv17.php?n";

            lbltitle.Text = btnEnv29.Text;
            this.PanelFormLoader.Controls.Clear();
            frmDashboard FrmDashboard_Vrb = new frmDashboard() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FrmDashboard_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.PanelFormLoader.Controls.Add(FrmDashboard_Vrb);
            FrmDashboard_Vrb.Show();
        }

        private void btnEnv30_Click(object sender, EventArgs e)
        {
            jsonURL = "https://meter.m1sensordata.com/sensirionPHP/getenv17.php?n";

            lbltitle.Text = btnEnv30.Text;
            this.PanelFormLoader.Controls.Clear();
            frmDashboard FrmDashboard_Vrb = new frmDashboard() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FrmDashboard_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.PanelFormLoader.Controls.Add(FrmDashboard_Vrb);
            FrmDashboard_Vrb.Show();
        }
    }
}
