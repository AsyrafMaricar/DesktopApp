
namespace Dashboard
{
    partial class frmPopup
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
            this.btnClosePopup = new System.Windows.Forms.Button();
            this.lblAlertMsg = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnClosePopup
            // 
            this.btnClosePopup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(39)))), ((int)(((byte)(52)))));
            this.btnClosePopup.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnClosePopup.FlatAppearance.BorderSize = 0;
            this.btnClosePopup.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(48)))), ((int)(((byte)(60)))));
            this.btnClosePopup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClosePopup.Font = new System.Drawing.Font("Tahoma", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClosePopup.ForeColor = System.Drawing.Color.White;
            this.btnClosePopup.Location = new System.Drawing.Point(173, 160);
            this.btnClosePopup.Name = "btnClosePopup";
            this.btnClosePopup.Size = new System.Drawing.Size(103, 35);
            this.btnClosePopup.TabIndex = 13;
            this.btnClosePopup.Text = "Close";
            this.btnClosePopup.UseVisualStyleBackColor = false;
            this.btnClosePopup.Click += new System.EventHandler(this.btnClosePopup_Click);
            // 
            // lblAlertMsg
            // 
            this.lblAlertMsg.AutoSize = true;
            this.lblAlertMsg.BackColor = System.Drawing.Color.Transparent;
            this.lblAlertMsg.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlertMsg.ForeColor = System.Drawing.Color.White;
            this.lblAlertMsg.Location = new System.Drawing.Point(21, 86);
            this.lblAlertMsg.Name = "lblAlertMsg";
            this.lblAlertMsg.Size = new System.Drawing.Size(408, 38);
            this.lblAlertMsg.TabIndex = 14;
            this.lblAlertMsg.Text = "Unable to retrieve environmental data\r\nPlease check your internet connection or c" +
    "ontact support";
            this.lblAlertMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(32)))), ((int)(((byte)(43)))));
            this.ClientSize = new System.Drawing.Size(450, 210);
            this.Controls.Add(this.btnClosePopup);
            this.Controls.Add(this.lblAlertMsg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPopup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmPopup";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClosePopup;
        private System.Windows.Forms.Label lblAlertMsg;
    }
}