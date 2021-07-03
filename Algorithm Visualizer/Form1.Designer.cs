namespace Algorithm_Visualizer
{
    partial class AlgoVis
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
            this.menuPanel = new System.Windows.Forms.Panel();
            this.chGoal = new System.Windows.Forms.CheckBox();
            this.chStart = new System.Windows.Forms.CheckBox();
            this.cbAlgo = new System.Windows.Forms.ComboBox();
            this.bReset = new System.Windows.Forms.Button();
            this.bLaunch = new System.Windows.Forms.Button();
            this.mainPanel = new System.Windows.Forms.TableLayoutPanel();
            this.menuPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuPanel
            // 
            this.menuPanel.BackColor = System.Drawing.SystemColors.HotTrack;
            this.menuPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.menuPanel.Controls.Add(this.chGoal);
            this.menuPanel.Controls.Add(this.chStart);
            this.menuPanel.Controls.Add(this.cbAlgo);
            this.menuPanel.Controls.Add(this.bReset);
            this.menuPanel.Controls.Add(this.bLaunch);
            this.menuPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.menuPanel.Location = new System.Drawing.Point(0, 0);
            this.menuPanel.Margin = new System.Windows.Forms.Padding(0);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(1384, 100);
            this.menuPanel.TabIndex = 0;
            // 
            // chGoal
            // 
            this.chGoal.Appearance = System.Windows.Forms.Appearance.Button;
            this.chGoal.AutoSize = true;
            this.chGoal.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chGoal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chGoal.Location = new System.Drawing.Point(161, 3);
            this.chGoal.Name = "chGoal";
            this.chGoal.Size = new System.Drawing.Size(86, 31);
            this.chGoal.TabIndex = 6;
            this.chGoal.Text = "Goal Tile";
            this.chGoal.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chGoal.UseVisualStyleBackColor = true;
            this.chGoal.CheckedChanged += new System.EventHandler(this.chGoal_CheckedChanged);
            // 
            // chStart
            // 
            this.chStart.Appearance = System.Windows.Forms.Appearance.Button;
            this.chStart.AutoSize = true;
            this.chStart.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chStart.Location = new System.Drawing.Point(43, 3);
            this.chStart.Name = "chStart";
            this.chStart.Size = new System.Drawing.Size(86, 31);
            this.chStart.TabIndex = 5;
            this.chStart.Text = "Start Tile";
            this.chStart.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chStart.UseVisualStyleBackColor = true;
            this.chStart.CheckedChanged += new System.EventHandler(this.chStart_CheckedChanged);
            // 
            // cbAlgo
            // 
            this.cbAlgo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAlgo.FormattingEnabled = true;
            this.cbAlgo.Items.AddRange(new object[] {
            "Dijkstra",
            "A*"});
            this.cbAlgo.Location = new System.Drawing.Point(268, 5);
            this.cbAlgo.Name = "cbAlgo";
            this.cbAlgo.Size = new System.Drawing.Size(121, 29);
            this.cbAlgo.TabIndex = 4;
            // 
            // bReset
            // 
            this.bReset.FlatAppearance.BorderSize = 0;
            this.bReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bReset.Location = new System.Drawing.Point(527, 0);
            this.bReset.Name = "bReset";
            this.bReset.Size = new System.Drawing.Size(132, 100);
            this.bReset.TabIndex = 3;
            this.bReset.Text = "Reset";
            this.bReset.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bReset.UseVisualStyleBackColor = true;
            this.bReset.Click += new System.EventHandler(this.bReset_Click);
            // 
            // bLaunch
            // 
            this.bLaunch.FlatAppearance.BorderSize = 0;
            this.bLaunch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bLaunch.Location = new System.Drawing.Point(395, 0);
            this.bLaunch.Name = "bLaunch";
            this.bLaunch.Size = new System.Drawing.Size(132, 100);
            this.bLaunch.TabIndex = 2;
            this.bLaunch.Text = "Start";
            this.bLaunch.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bLaunch.UseVisualStyleBackColor = true;
            this.bLaunch.Click += new System.EventHandler(this.bLaunch_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.ColumnCount = 1;
            this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.mainPanel.Location = new System.Drawing.Point(0, 100);
            this.mainPanel.Margin = new System.Windows.Forms.Padding(0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.RowCount = 1;
            this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.mainPanel.Size = new System.Drawing.Size(1384, 661);
            this.mainPanel.TabIndex = 2;
            // 
            // AlgoVis
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1384, 761);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.menuPanel);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MinimizeBox = false;
            this.Name = "AlgoVis";
            this.Text = "Algorithm Visualizer";
            this.Load += new System.EventHandler(this.AlgoVis_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AlgoVis_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.AlgoVis_KeyUp);
            this.menuPanel.ResumeLayout(false);
            this.menuPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel menuPanel;
        private System.Windows.Forms.TableLayoutPanel mainPanel;
        private System.Windows.Forms.Button bLaunch;
        private System.Windows.Forms.Button bReset;
        private System.Windows.Forms.ComboBox cbAlgo;
        private System.Windows.Forms.CheckBox chStart;
        private System.Windows.Forms.CheckBox chGoal;
    }
}

