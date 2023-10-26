namespace Winery.Views
{
    partial class GraphsTabControl3
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
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label12 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.wineList2 = new System.Windows.Forms.CheckedListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.plotView2 = new OxyPlot.WindowsForms.PlotView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.computeResultLabel3 = new System.Windows.Forms.Label();
            this.gender3 = new System.Windows.Forms.ComboBox();
            this.label36 = new System.Windows.Forms.Label();
            this.ageNumeric3 = new System.Windows.Forms.NumericUpDown();
            this.label31 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.computeResultButton3 = new System.Windows.Forms.Button();
            this.plotView3 = new OxyPlot.WindowsForms.PlotView();
            this.wINESBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet2 = new Winery.DataSet2();
            this.wINESTableAdapter = new Winery.DataSet2TableAdapters.WINESTableAdapter();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ageNumeric3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wINESBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet2)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1027, 562);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1019, 536);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Wines Hierarchical Explorer";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.flowLayoutPanel1);
            this.splitContainer1.Panel2.Controls.Add(this.label12);
            this.splitContainer1.Size = new System.Drawing.Size(1013, 530);
            this.splitContainer1.SplitterDistance = 426;
            this.splitContainer1.TabIndex = 0;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(426, 530);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 54);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(583, 476);
            this.flowLayoutPanel1.TabIndex = 12;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(19, 13);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(234, 13);
            this.label12.TabIndex = 11;
            this.label12.Text = "Provide a treeview access to each of the wines.";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.splitContainer2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1019, 536);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Wine varieties and age";
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
            this.splitContainer2.Panel1.Controls.Add(this.button2);
            this.splitContainer2.Panel1.Controls.Add(this.button3);
            this.splitContainer2.Panel1.Controls.Add(this.wineList2);
            this.splitContainer2.Panel1.Controls.Add(this.label6);
            this.splitContainer2.Panel1.Controls.Add(this.button4);
            this.splitContainer2.Panel1MinSize = 276;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.plotView2);
            this.splitContainer2.Size = new System.Drawing.Size(1013, 530);
            this.splitContainer2.SplitterDistance = 276;
            this.splitContainer2.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(104, 166);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(83, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Select ALL";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.selectAllbutton2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(6, 166);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(92, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "Clear Selection";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.clearAllButton2_Click);
            // 
            // wineList2
            // 
            this.wineList2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.wineList2.CheckOnClick = true;
            this.wineList2.FormattingEnabled = true;
            this.wineList2.Location = new System.Drawing.Point(6, 195);
            this.wineList2.Name = "wineList2";
            this.wineList2.Size = new System.Drawing.Size(257, 334);
            this.wineList2.Sorted = true;
            this.wineList2.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(3, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(270, 51);
            this.label6.TabIndex = 2;
            this.label6.Text = "A line chart for highlighting the link between the age of the buyer and the varie" +
    "ty of wine";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(6, 67);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(257, 23);
            this.button4.TabIndex = 1;
            this.button4.Text = "Create Graph";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.createGraph2_Click);
            // 
            // plotView2
            // 
            this.plotView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plotView2.Location = new System.Drawing.Point(0, 0);
            this.plotView2.Name = "plotView2";
            this.plotView2.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.plotView2.Size = new System.Drawing.Size(733, 530);
            this.plotView2.TabIndex = 0;
            this.plotView2.Text = "plotView2";
            this.plotView2.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.plotView2.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.plotView2.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.splitContainer3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1019, 536);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Compute favourite wine variety ";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.computeResultLabel3);
            this.splitContainer3.Panel1.Controls.Add(this.gender3);
            this.splitContainer3.Panel1.Controls.Add(this.label36);
            this.splitContainer3.Panel1.Controls.Add(this.ageNumeric3);
            this.splitContainer3.Panel1.Controls.Add(this.label31);
            this.splitContainer3.Panel1.Controls.Add(this.label9);
            this.splitContainer3.Panel1.Controls.Add(this.computeResultButton3);
            this.splitContainer3.Panel1MinSize = 276;
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.plotView3);
            this.splitContainer3.Size = new System.Drawing.Size(1019, 536);
            this.splitContainer3.SplitterDistance = 276;
            this.splitContainer3.TabIndex = 2;
            // 
            // computeResultLabel3
            // 
            this.computeResultLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.computeResultLabel3.Location = new System.Drawing.Point(6, 170);
            this.computeResultLabel3.Name = "computeResultLabel3";
            this.computeResultLabel3.Size = new System.Drawing.Size(257, 328);
            this.computeResultLabel3.TabIndex = 34;
            // 
            // gender3
            // 
            this.gender3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gender3.FormattingEnabled = true;
            this.gender3.Items.AddRange(new object[] {
            "male",
            "female"});
            this.gender3.Location = new System.Drawing.Point(119, 67);
            this.gender3.Name = "gender3";
            this.gender3.Size = new System.Drawing.Size(144, 21);
            this.gender3.TabIndex = 33;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(16, 67);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(74, 13);
            this.label36.TabIndex = 32;
            this.label36.Text = "Client Gender:";
            // 
            // ageNumeric3
            // 
            this.ageNumeric3.Location = new System.Drawing.Point(119, 94);
            this.ageNumeric3.Minimum = new decimal(new int[] {
            18,
            0,
            0,
            0});
            this.ageNumeric3.Name = "ageNumeric3";
            this.ageNumeric3.Size = new System.Drawing.Size(144, 20);
            this.ageNumeric3.TabIndex = 30;
            this.ageNumeric3.Value = new decimal(new int[] {
            18,
            0,
            0,
            0});
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(61, 101);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(29, 13);
            this.label31.TabIndex = 31;
            this.label31.Text = "Age:";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(3, 13);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(270, 51);
            this.label9.TabIndex = 2;
            this.label9.Text = "Find the best sold wine variety, based on age and gender.";
            // 
            // computeResultButton3
            // 
            this.computeResultButton3.Location = new System.Drawing.Point(6, 120);
            this.computeResultButton3.Name = "computeResultButton3";
            this.computeResultButton3.Size = new System.Drawing.Size(257, 23);
            this.computeResultButton3.TabIndex = 1;
            this.computeResultButton3.Text = "Compute result";
            this.computeResultButton3.UseVisualStyleBackColor = true;
            this.computeResultButton3.Click += new System.EventHandler(this.computeResultButton3_Click);
            // 
            // plotView3
            // 
            this.plotView3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plotView3.Location = new System.Drawing.Point(0, 0);
            this.plotView3.Name = "plotView3";
            this.plotView3.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.plotView3.Size = new System.Drawing.Size(739, 536);
            this.plotView3.TabIndex = 0;
            this.plotView3.Text = "plotView3";
            this.plotView3.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.plotView3.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.plotView3.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
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
            // GraphsTabControl3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "GraphsTabControl3";
            this.Size = new System.Drawing.Size(1027, 562);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ageNumeric3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wINESBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.BindingSource wINESBindingSource;
        private DataSet2 dataSet2;
        private DataSet2TableAdapters.WINESTableAdapter wINESTableAdapter;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.CheckedListBox wineList2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button4;
        private OxyPlot.WindowsForms.PlotView plotView2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button computeResultButton3;
        private OxyPlot.WindowsForms.PlotView plotView3;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox gender3;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.NumericUpDown ageNumeric3;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label computeResultLabel3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}
