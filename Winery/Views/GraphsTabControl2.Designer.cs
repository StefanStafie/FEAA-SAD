namespace Winery.Views
{
    partial class GraphsTabControl2
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
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.clientAgeTo1 = new System.Windows.Forms.NumericUpDown();
            this.clientAgeFrom1 = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.recommandationLabel1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CreateGraph1 = new System.Windows.Forms.Button();
            this.plotView1 = new OxyPlot.WindowsForms.PlotView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.recommendButton2 = new System.Windows.Forms.Button();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.label5 = new System.Windows.Forms.Label();
            this.flowLayoutPanel21 = new System.Windows.Forms.FlowLayoutPanel();
            this.label11 = new System.Windows.Forms.Label();
            this.flowLayoutPanel22 = new System.Windows.Forms.FlowLayoutPanel();
            this.wINESBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet2 = new Winery.DataSet2();
            this.wINESTableAdapter = new Winery.DataSet2TableAdapters.WINESTableAdapter();
            this.oracleCommand1 = new Oracle.ManagedDataAccess.Client.OracleCommand();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clientAgeTo1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientAgeFrom1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wINESBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet2)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1039, 381);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1031, 355);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Male/Female sales + recommendation";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(this.clientAgeTo1);
            this.splitContainer1.Panel1.Controls.Add(this.clientAgeFrom1);
            this.splitContainer1.Panel1.Controls.Add(this.label10);
            this.splitContainer1.Panel1.Controls.Add(this.recommandationLabel1);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.CreateGraph1);
            this.splitContainer1.Panel1MinSize = 276;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.plotView1);
            this.splitContainer1.Size = new System.Drawing.Size(1025, 349);
            this.splitContainer1.SplitterDistance = 276;
            this.splitContainer1.TabIndex = 0;
            // 
            // clientAgeTo1
            // 
            this.clientAgeTo1.Location = new System.Drawing.Point(199, 147);
            this.clientAgeTo1.Minimum = new decimal(new int[] {
            18,
            0,
            0,
            0});
            this.clientAgeTo1.Name = "clientAgeTo1";
            this.clientAgeTo1.Size = new System.Drawing.Size(64, 20);
            this.clientAgeTo1.TabIndex = 11;
            this.clientAgeTo1.Value = new decimal(new int[] {
            35,
            0,
            0,
            0});
            // 
            // clientAgeFrom1
            // 
            this.clientAgeFrom1.Location = new System.Drawing.Point(199, 121);
            this.clientAgeFrom1.Minimum = new decimal(new int[] {
            18,
            0,
            0,
            0});
            this.clientAgeFrom1.Name = "clientAgeFrom1";
            this.clientAgeFrom1.Size = new System.Drawing.Size(64, 20);
            this.clientAgeFrom1.TabIndex = 10;
            this.clientAgeFrom1.Value = new decimal(new int[] {
            18,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(68, 138);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "Clients Age";
            // 
            // recommandationLabel1
            // 
            this.recommandationLabel1.Location = new System.Drawing.Point(6, 208);
            this.recommandationLabel1.Name = "recommandationLabel1";
            this.recommandationLabel1.Size = new System.Drawing.Size(257, 241);
            this.recommandationLabel1.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(158, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "To";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(148, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "From";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(270, 59);
            this.label1.TabIndex = 2;
            this.label1.Text = "A line chart used to compare sales between males and females depending age.  Offe" +
    "rs a  recommandation for advertising a certain age group.";
            // 
            // CreateGraph1
            // 
            this.CreateGraph1.Location = new System.Drawing.Point(6, 170);
            this.CreateGraph1.Name = "CreateGraph1";
            this.CreateGraph1.Size = new System.Drawing.Size(257, 23);
            this.CreateGraph1.TabIndex = 1;
            this.CreateGraph1.Text = "Create Graph";
            this.CreateGraph1.UseVisualStyleBackColor = true;
            this.CreateGraph1.Click += new System.EventHandler(this.createGraph1_Click);
            // 
            // plotView1
            // 
            this.plotView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plotView1.Location = new System.Drawing.Point(0, 0);
            this.plotView1.Name = "plotView1";
            this.plotView1.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.plotView1.Size = new System.Drawing.Size(745, 349);
            this.plotView1.TabIndex = 0;
            this.plotView1.Text = "plotView1";
            this.plotView1.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.plotView1.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.plotView1.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.splitContainer2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1031, 355);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Wine Recommendations";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.comboBox2);
            this.splitContainer2.Panel1.Controls.Add(this.label4);
            this.splitContainer2.Panel1.Controls.Add(this.label6);
            this.splitContainer2.Panel1.Controls.Add(this.recommendButton2);
            this.splitContainer2.Panel1MinSize = 276;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer4);
            this.splitContainer2.Size = new System.Drawing.Size(1025, 349);
            this.splitContainer2.SplitterDistance = 276;
            this.splitContainer2.TabIndex = 1;
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(64, 77);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(199, 21);
            this.comboBox2.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "If you like:";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(3, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(270, 51);
            this.label6.TabIndex = 2;
            this.label6.Text = "Computes recommendations for people who bought a certain wine. Recommends what ot" +
    "her people bought and similar varieties.";
            // 
            // recommendButton2
            // 
            this.recommendButton2.Location = new System.Drawing.Point(6, 104);
            this.recommendButton2.Name = "recommendButton2";
            this.recommendButton2.Size = new System.Drawing.Size(257, 23);
            this.recommendButton2.TabIndex = 1;
            this.recommendButton2.Text = "Get Recommendations";
            this.recommendButton2.UseVisualStyleBackColor = true;
            this.recommendButton2.Click += new System.EventHandler(this.computeWineRecommendation2_Click);
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.label5);
            this.splitContainer4.Panel1.Controls.Add(this.flowLayoutPanel21);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.label11);
            this.splitContainer4.Panel2.Controls.Add(this.flowLayoutPanel22);
            this.splitContainer4.Size = new System.Drawing.Size(745, 349);
            this.splitContainer4.SplitterDistance = 440;
            this.splitContainer4.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Similar Wines";
            // 
            // flowLayoutPanel21
            // 
            this.flowLayoutPanel21.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel21.AutoScroll = true;
            this.flowLayoutPanel21.Location = new System.Drawing.Point(3, 36);
            this.flowLayoutPanel21.Name = "flowLayoutPanel21";
            this.flowLayoutPanel21.Size = new System.Drawing.Size(434, 310);
            this.flowLayoutPanel21.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(24, 13);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(98, 13);
            this.label11.TabIndex = 3;
            this.label11.Text = "People also bought";
            // 
            // flowLayoutPanel22
            // 
            this.flowLayoutPanel22.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel22.AutoScroll = true;
            this.flowLayoutPanel22.Location = new System.Drawing.Point(3, 36);
            this.flowLayoutPanel22.Name = "flowLayoutPanel22";
            this.flowLayoutPanel22.Size = new System.Drawing.Size(295, 310);
            this.flowLayoutPanel22.TabIndex = 2;
            // 
            // wINESBindingSource
            // 
            this.wINESBindingSource.DataMember = "WINES";
            this.wINESBindingSource.DataSource = this.dataSet2;
            // 
            // dataSet2
            // 
            this.dataSet2.DataSetName = "DataSet2";
            this.dataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // wINESTableAdapter
            // 
            this.wINESTableAdapter.ClearBeforeFill = true;
            // 
            // oracleCommand1
            // 
            this.oracleCommand1.Transaction = null;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(9, 199);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(254, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "Export to excel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.exportToExcelButton1_Click);
            // 
            // GraphsTabControl2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "GraphsTabControl2";
            this.Size = new System.Drawing.Size(1039, 381);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.clientAgeTo1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientAgeFrom1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel1.PerformLayout();
            this.splitContainer4.Panel2.ResumeLayout(false);
            this.splitContainer4.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.wINESBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button CreateGraph1;
        private System.Windows.Forms.BindingSource wINESBindingSource;
        private DataSet2 dataSet2;
        private DataSet2TableAdapters.WINESTableAdapter wINESTableAdapter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.Button recommendButton2;
        private System.Windows.Forms.Label recommandationLabel1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown clientAgeTo1;
        private System.Windows.Forms.NumericUpDown clientAgeFrom1;
        private Oracle.ManagedDataAccess.Client.OracleCommand oracleCommand1;
        public System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label4;
        private OxyPlot.WindowsForms.PlotView plotView1;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel21;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel22;
        private System.Windows.Forms.Button button1;
    }
}
