using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dashboard
{
    public partial class frmAlerts : Form
    {
        public List<JSONModel> datalist;
        public frmAlerts()
        {
            InitializeComponent();
            alertupdatetimer.Interval = 3500;
            alertupdatetimer.Start();         

            using (WebClient wc = new WebClient())
            {
                string URL = "https://meter.m1sensordata.com/sensirionPHP/getenv101.php?n=10";
                var json = string.Empty;
                json = wc.DownloadString(URL.ToString());
                datalist = JsonConvert.DeserializeObject<List<JSONModel>>(json);

                gridEnv101.DataSource = datalist;
                table_Setting();

            };
        }

        private void alertupdatetimer_Tick(object sender, EventArgs e)
        {
            using (WebClient wc = new WebClient())
            {
                string URL = "https://meter.m1sensordata.com/sensirionPHP/getenv101.php?n=10";
                var json = string.Empty;
                json = wc.DownloadString(URL.ToString());
                
                datalist = JsonConvert.DeserializeObject<List<JSONModel>>(json);
                Console.WriteLine("updoot");

                gridEnv101.DataSource = datalist;               

            };
        }

        private void table_Setting()
        {
            gridEnv101.Columns["device"].HeaderText = "Device";
            gridEnv101.Columns["date"].HeaderText = "Date";
            gridEnv101.Columns["sen1"].HeaderText = "Humidity (%)";
            gridEnv101.Columns["sen2"].HeaderText = "Temperature (°C)";
            gridEnv101.Columns["sen3"].Visible = false;
            gridEnv101.Columns["sen4"].Visible = false;

            gridEnv101.Columns["sen2"].DisplayIndex = 2;
            gridEnv101.Columns["sen1"].DisplayIndex = 3;

            gridEnv101.RowsDefaultCellStyle.BackColor = Color.FromArgb(37,42,64);
            gridEnv101.GridColor = Color.DarkOrange;

            gridEnv101.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            gridEnv101.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(25, 39, 52); //Header
            gridEnv101.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 16, FontStyle.Bold);
            gridEnv101.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(225, 225, 225);

            gridEnv101.BorderStyle = BorderStyle.None;
            gridEnv101.CellBorderStyle = DataGridViewCellBorderStyle.None;
            gridEnv101.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            gridEnv101.EnableHeadersVisualStyles = false;
            gridEnv101.BackgroundColor = Color.FromArgb(37, 42, 64);
            gridEnv101.RowHeadersVisible = false;
            gridEnv101.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridEnv101.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            gridEnv101.RowTemplate.Height = 30;
            gridEnv101.DefaultCellStyle.Font = new Font("Tahoma", 14);
            gridEnv101.ReadOnly = true;
            gridEnv101.AllowUserToResizeRows = false;
            
            ///////////////////////////// //////////////////power table setting END //////////////////////
        }

        private void frmAlerts_Leave(object sender, EventArgs e)
        {
            alertupdatetimer.Dispose();
        }
    }
}
