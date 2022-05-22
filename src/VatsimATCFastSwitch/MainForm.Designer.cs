namespace VatsimATCFastSwitch
{
    partial class MainForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnTopmost = new System.Windows.Forms.Button();
            this.lblError = new System.Windows.Forms.Label();
            this.flowButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.lblAtis = new System.Windows.Forms.Label();
            this.timerAircraft = new System.Windows.Forms.Timer(this.components);
            this.timerStations = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowButtons, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblAtis, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.DarkGray;
            this.flowLayoutPanel1.Controls.Add(this.btnRefresh);
            this.flowLayoutPanel1.Controls.Add(this.btnTopmost);
            this.flowLayoutPanel1.Controls.Add(this.lblError);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(794, 31);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.PaleGreen;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Location = new System.Drawing.Point(3, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 0;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnTopmost
            // 
            this.btnTopmost.BackColor = System.Drawing.Color.LightPink;
            this.btnTopmost.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTopmost.Location = new System.Drawing.Point(84, 3);
            this.btnTopmost.Name = "btnTopmost";
            this.btnTopmost.Size = new System.Drawing.Size(100, 23);
            this.btnTopmost.TabIndex = 1;
            this.btnTopmost.Text = "Always On Top";
            this.btnTopmost.UseVisualStyleBackColor = false;
            this.btnTopmost.Click += new System.EventHandler(this.btnTopmost_Click);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.DarkRed;
            this.lblError.Location = new System.Drawing.Point(190, 0);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(147, 13);
            this.lblError.TabIndex = 2;
            this.lblError.Text = "eeeeeeeeeeeeeeeeeeee";
            // 
            // flowButtons
            // 
            this.flowButtons.AutoScroll = true;
            this.flowButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowButtons.Location = new System.Drawing.Point(3, 40);
            this.flowButtons.Name = "flowButtons";
            this.flowButtons.Size = new System.Drawing.Size(794, 297);
            this.flowButtons.TabIndex = 1;
            // 
            // lblAtis
            // 
            this.lblAtis.AutoSize = true;
            this.lblAtis.BackColor = System.Drawing.Color.DarkGray;
            this.lblAtis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAtis.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAtis.Location = new System.Drawing.Point(3, 340);
            this.lblAtis.Name = "lblAtis";
            this.lblAtis.Size = new System.Drawing.Size(794, 110);
            this.lblAtis.TabIndex = 2;
            this.lblAtis.Text = "label1";
            // 
            // timerAircraft
            // 
            this.timerAircraft.Enabled = true;
            this.timerAircraft.Interval = 30000;
            this.timerAircraft.Tick += new System.EventHandler(this.timerAircraft_Tick);
            // 
            // timerStations
            // 
            this.timerStations.Enabled = true;
            this.timerStations.Interval = 120000;
            this.timerStations.Tick += new System.EventHandler(this.timerStations_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnTopmost;
        private System.Windows.Forms.FlowLayoutPanel flowButtons;
        private System.Windows.Forms.Label lblAtis;
        private System.Windows.Forms.Timer timerAircraft;
        private System.Windows.Forms.Timer timerStations;
        private System.Windows.Forms.Label lblError;
    }
}

