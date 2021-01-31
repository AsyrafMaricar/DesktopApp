
namespace Dashboard
{
    partial class frmAlerts
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gridEnv101 = new System.Windows.Forms.DataGridView();
            this.alertupdatetimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gridEnv101)).BeginInit();
            this.SuspendLayout();
            // 
            // gridEnv101
            // 
            this.gridEnv101.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.gridEnv101.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.gridEnv101.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridEnv101.Location = new System.Drawing.Point(17, 22);
            this.gridEnv101.Name = "gridEnv101";
            this.gridEnv101.Size = new System.Drawing.Size(997, 433);
            this.gridEnv101.TabIndex = 0;
            // 
            // alertupdatetimer
            // 
            this.alertupdatetimer.Tick += new System.EventHandler(this.alertupdatetimer_Tick);
            // 
            // frmAlerts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(1031, 477);
            this.Controls.Add(this.gridEnv101);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAlerts";
            this.Text = "frmAlerts";
            this.Leave += new System.EventHandler(this.frmAlerts_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.gridEnv101)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridEnv101;
        private System.Windows.Forms.Timer alertupdatetimer;
    }
}