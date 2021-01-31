using Dashboard.Properties;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Dashboard
{
    public partial class frmDashboard : Form
    {
        public List<JSONModel> datalist;
        public frmDashboard()
        {
            InitializeComponent();
            initdataload();       
        }

        public static bool FormIsOpen(FormCollection application, Type formType)
        {
            //usage sample: FormIsOpen(Application.OpenForms,typeof(Form2)
            return Application.OpenForms.Cast<Form>().Any(openForm => openForm.GetType() == formType);
        }

        private void initdataload()
        {
            using (WebClient wc = new WebClient())
            {
                string URL = Form1.jsonURL + "=360";
                var json = string.Empty;
                bool initialtry = true;

                while (initialtry)
                {
                    try
                    {
                        json = wc.DownloadString(URL.ToString());
                        initialtry = false;
                    }
                    catch (WebException e)
                    {
                        bool windowopen = FormIsOpen(Application.OpenForms, typeof(frmPopup));
                        if (!windowopen)
                        {
                            frmPopup frmpop = new frmPopup();
                            frmpop.ShowDialog();
                        }
                        Console.WriteLine($"{e}");
                    }
                }

                datalist = JsonConvert.DeserializeObject<List<JSONModel>>(json);

                chart1.DataSource = datalist;
                chart1_settings();

                processTick();

                updatetimer.Interval = 5500;
                updatetimer.Start();

            }
        }

        private void updatetimer_Tick(object sender, EventArgs e)
        {
            bool windowopen;
            using (WebClient wc = new WebClient())
            {
                string newURL = Form1.jsonURL;
                var newjson = string.Empty;
                frmPopup frmpop = new frmPopup();
                try
                {
                    newjson = wc.DownloadString(newURL.ToString());
                    windowopen = FormIsOpen(Application.OpenForms, typeof(frmPopup));
                }
                catch (WebException ex)
                {
                    windowopen = FormIsOpen(Application.OpenForms, typeof(frmPopup));
                    if (windowopen == false)
                    {
                        frmpop.Show();    
                    }
                    Console.WriteLine($"{ex}");
                }

                if (windowopen)
                {
                    frmpop.Hide();
                }

                var newlist = (JsonConvert.DeserializeObject<List<JSONModel>>(newjson));
                if (newlist != null) 
                { 
                    datalist.AddRange(newlist); 
                }
            }

            chart1.DataBind();
            processTick();

        }

        private void processTick()
        {
            float latestbatt = datalist[datalist.Count - 1].sen3;
            float tempsum = datalist.Sum(total => total.sen2);
            float avgtemp = (tempsum / datalist.Count);
            bool battLow;
            bool highTemp;

            lblBatt.Text = latestbatt.ToString() + "%";
            if (latestbatt >= 80)
            {
                imgBatt.Image = Resources.fullbatt;
                battLow = false;
            }
            else
            {
                if (latestbatt >= 35)
                {
                    imgBatt.Image = Resources.halfbatt;
                    battLow = false;
                }
                else
                {
                    imgBatt.Image = Resources.lowbatt;
                    lblBatt.ForeColor = Color.Red;
                    battLow = true;
                }
            };

            lblRSSI.Text = datalist[datalist.Count - 1].sen4.ToString() + "dBm";

            lblAvgTemp.Text = avgtemp.ToString("F") + "°C";
            if (avgtemp > 30.0) { lblAvgTemp.ForeColor = Color.Red; highTemp = true; } else { lblAvgTemp.ForeColor = Color.LimeGreen; highTemp = false; };

            circularProgressBar1.Text = datalist[datalist.Count - 1].sen1.ToString() + "%";
            circularProgressBar1.Value = (int)datalist[datalist.Count - 1].sen1;

            int i;

            switch (highTemp)
            {
                case true:
                    if (battLow == true)
                    {
                        i = 3;
                    }
                    else { i = 1; }
                    break;
                default:
                    if (battLow == true)
                    {
                        i = 2;
                    }
                    else { i = 0; }
                    break;
            }

            switch (i)
            {
                default:
                    Console.WriteLine("normal");
                    lblStatus.Text = "Healthy";
                    lblStatus.ForeColor = Color.LimeGreen;

                    imgStatus1.Image = Resources.kisspng_computer_icons_emoticon_smiley_lol_icon_5b5cea95e965e5_676644911532816021956_100x100;

                    imgStatus2.Hide();
                    break;

                case 1:
                    Console.WriteLine("hightemp");
                    lblStatus.Text = "High average temperature!";
                    lblStatus.ForeColor = Color.Red;

                    imgStatus1.Image = Resources.thermometer_red_512_100x100;
                    
                    imgStatus2.Hide();
                    break;

                case 2:
                    Console.WriteLine("battlow");
                    lblStatus.Text = "Low Battery!";

                    imgStatus1.Image = Resources.battery_9_1282;

                    imgStatus2.Hide();
                    break;

                case 3:
                    Console.WriteLine("both");
                    lblStatus.Text = "Battery Low \n High temperature \n Send support!";

                    imgStatus1.Location = new Point(0,94);

                    imgStatus1.Image = Resources.thermometer_red_512_100x100;
                    imgStatus2.Image = Resources.battery_9_1282;

                    imgStatus2.Show();

                    break;
            }
        }

        private void chart1_settings()
        {
           
            Series series1 = new Series("My Series");
            chart1.Series.Add(series1);
            series1.ChartType = SeriesChartType.Line;
            series1.YValueMembers = "Sen2";
            series1.XValueMember = "Date";

            chart1.ChartAreas[0].BackColor = Color.FromArgb(46, 51, 73);
            chart1.Series["My Series"].Color = Color.FromArgb(255, 128, 128);
            chart1.Legends.Clear();
            chart1.Series["My Series"].ToolTip = "#VALX, #VAL";

            chart1.ChartAreas[0].AxisX.LabelStyle.Format = "MM/dd hh:mm";
            chart1.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
            chart1.ChartAreas[0].AxisX.LabelStyle.Interval = 10;
            chart1.Series["My Series"].XValueType = ChartValueType.DateTime;
            chart1.Series["My Series"].IsXValueIndexed = true;
            chart1.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Minutes;
            chart1.ChartAreas[0].AxisX.Enabled = AxisEnabled.False;

            chart1.ChartAreas[0].AxisX.LineColor = Color.FromArgb(37, 42, 64);
            chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Transparent;
            chart1.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.White;

            chart1.ChartAreas[0].AxisY.LineColor = Color.FromArgb(37, 42, 64);
            chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
            chart1.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.White;
            chart1.ChartAreas[0].AxisY.Minimum = 15;
            chart1.ChartAreas[0].AxisY.Maximum = 35;
        }


        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {
         
        }

        private void btnMax_click(object sender, EventArgs e)
        {
            if (chartpanel.Dock != DockStyle.Fill)
            {
                chartpanel.Dock = DockStyle.Fill;

                chart1.Location = new Point(0, 50);
                chart1.Size = new Size(697, 402);
                chart1.ChartAreas[0].AxisX.Enabled = AxisEnabled.True;

                btnMax.Location = new Point(975, 13);
                btnMax.Image = Resources.mini_24x24;

                btnPause.Location = new Point(866, 13);

                lblTemp.Location = new Point(390, 40);     
            }
            else 
            {
                chartpanel.Dock = DockStyle.None;

                chart1.Location = new Point(0, 50);
                chart1.Size = new Size(426, 262);
                chart1.ChartAreas[0].AxisX.Enabled = AxisEnabled.False;

                btnMax.Location = new Point(386, 13);
                btnMax.Image = Resources.max_20x20;
 
                btnPause.Location = new Point(295, 13);

                lblTemp.Location = new Point(18, 22);
            }
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            if (updatetimer.Enabled == true)
            {
                updatetimer.Stop();
                btnPause.Text = "Resume";
                btnPause.ForeColor = Color.Green;
            }
            else 
            {
                updatetimer.Start();
                btnPause.Text = "Pause";
                btnPause.ForeColor = Color.Maroon;

            }
            
            
        }

        private void dashboard_Leave(object sender, EventArgs e)
        {
            updatetimer.Dispose();
        }
    }
}
