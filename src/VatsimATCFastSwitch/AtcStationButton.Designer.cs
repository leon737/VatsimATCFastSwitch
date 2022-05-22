namespace VatsimATCFastSwitch
{
    partial class AtcStationButton
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSelectFrequency = new System.Windows.Forms.Button();
            this.btnShowInfo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSelectFrequency
            // 
            this.btnSelectFrequency.BackColor = System.Drawing.Color.Silver;
            this.btnSelectFrequency.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectFrequency.Location = new System.Drawing.Point(3, 3);
            this.btnSelectFrequency.Name = "btnSelectFrequency";
            this.btnSelectFrequency.Size = new System.Drawing.Size(184, 37);
            this.btnSelectFrequency.TabIndex = 0;
            this.btnSelectFrequency.Text = "button1";
            this.btnSelectFrequency.UseVisualStyleBackColor = false;
            this.btnSelectFrequency.Click += new System.EventHandler(this.btnSelectFrequency_Click);
            // 
            // btnShowInfo
            // 
            this.btnShowInfo.BackColor = System.Drawing.Color.LemonChiffon;
            this.btnShowInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowInfo.Location = new System.Drawing.Point(193, 3);
            this.btnShowInfo.Name = "btnShowInfo";
            this.btnShowInfo.Size = new System.Drawing.Size(39, 37);
            this.btnShowInfo.TabIndex = 1;
            this.btnShowInfo.Text = "?";
            this.btnShowInfo.UseVisualStyleBackColor = false;
            this.btnShowInfo.Click += new System.EventHandler(this.btnShowInfo_Click);
            // 
            // AtcStationButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnShowInfo);
            this.Controls.Add(this.btnSelectFrequency);
            this.Name = "AtcStationButton";
            this.Size = new System.Drawing.Size(235, 45);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSelectFrequency;
        private System.Windows.Forms.Button btnShowInfo;
    }
}
