namespace Winery.Views
{
    partial class GraphsTabControl1
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
            this.SelectAllButton1 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimeTo1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimeFrom1 = new System.Windows.Forms.DateTimePicker();
            this.wineryList1 = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CreateGraph1 = new System.Windows.Forms.Button();
            this.plotView1 = new OxyPlot.WindowsForms.PlotView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimeTo2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimeFrom2 = new System.Windows.Forms.DateTimePicker();
            this.wineryList2 = new System.Windows.Forms.CheckedListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.plotView2 = new OxyPlot.WindowsForms.PlotView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.selectAllButton3 = new System.Windows.Forms.Button();
            this.clearSelectionButton3 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dateTimeTo3 = new System.Windows.Forms.DateTimePicker();
            this.dateTimeFrom3 = new System.Windows.Forms.DateTimePicker();
            this.wineryList3 = new System.Windows.Forms.CheckedListBox();
            this.label9 = new System.Windows.Forms.Label();
            this.createGraph3 = new System.Windows.Forms.Button();
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
            this.tabControl1.Size = new System.Drawing.Size(1565, 893);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1557, 867);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Daily winery sales";
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
            this.splitContainer1.Panel1.Controls.Add(this.SelectAllButton1);
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.dateTimeTo1);
            this.splitContainer1.Panel1.Controls.Add(this.dateTimeFrom1);
            this.splitContainer1.Panel1.Controls.Add(this.wineryList1);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.CreateGraph1);
            this.splitContainer1.Panel1MinSize = 276;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.plotView1);
            this.splitContainer1.Size = new System.Drawing.Size(1551, 861);
            this.splitContainer1.SplitterDistance = 276;
            this.splitContainer1.TabIndex = 0;
            // 
            // SelectAllButton1
            // 
            this.SelectAllButton1.Location = new System.Drawing.Point(104, 166);
            this.SelectAllButton1.Name = "SelectAllButton1";
            this.SelectAllButton1.Size = new System.Drawing.Size(83, 23);
            this.SelectAllButton1.TabIndex = 9;
            this.SelectAllButton1.Text = "Select ALL";
            this.SelectAllButton1.UseVisualStyleBackColor = true;
            this.SelectAllButton1.Click += new System.EventHandler(this.SelectAllButton1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 166);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Clear Selection";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ClearSelectionButton1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "To";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "From";
            // 
            // dateTimeTo1
            // 
            this.dateTimeTo1.Location = new System.Drawing.Point(69, 92);
            this.dateTimeTo1.Name = "dateTimeTo1";
            this.dateTimeTo1.Size = new System.Drawing.Size(194, 20);
            this.dateTimeTo1.TabIndex = 5;
            this.dateTimeTo1.Value = new System.DateTime(2021, 1, 1, 13, 57, 0, 0);
            // 
            // dateTimeFrom1
            // 
            this.dateTimeFrom1.Location = new System.Drawing.Point(69, 66);
            this.dateTimeFrom1.Name = "dateTimeFrom1";
            this.dateTimeFrom1.Size = new System.Drawing.Size(194, 20);
            this.dateTimeFrom1.TabIndex = 4;
            this.dateTimeFrom1.Value = new System.DateTime(2020, 1, 1, 13, 57, 0, 0);
            // 
            // wineryList1
            // 
            this.wineryList1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.wineryList1.CheckOnClick = true;
            this.wineryList1.FormattingEnabled = true;
            this.wineryList1.Location = new System.Drawing.Point(6, 195);
            this.wineryList1.Name = "wineryList1";
            this.wineryList1.Size = new System.Drawing.Size(257, 604);
            this.wineryList1.Sorted = true;
            this.wineryList1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(270, 51);
            this.label1.TabIndex = 2;
            this.label1.Text = "A line chart used to compare sales between wineries. Highlightes max and min sale" +
    "s periods for each winery.";
            // 
            // CreateGraph1
            // 
            this.CreateGraph1.Location = new System.Drawing.Point(6, 118);
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
            this.plotView1.Size = new System.Drawing.Size(1271, 861);
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
            this.tabPage2.Size = new System.Drawing.Size(1557, 867);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Weekly compound winery sales";
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
            this.splitContainer2.Panel1.Controls.Add(this.label4);
            this.splitContainer2.Panel1.Controls.Add(this.label5);
            this.splitContainer2.Panel1.Controls.Add(this.dateTimeTo2);
            this.splitContainer2.Panel1.Controls.Add(this.dateTimeFrom2);
            this.splitContainer2.Panel1.Controls.Add(this.wineryList2);
            this.splitContainer2.Panel1.Controls.Add(this.label6);
            this.splitContainer2.Panel1.Controls.Add(this.button4);
            this.splitContainer2.Panel1MinSize = 276;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.plotView2);
            this.splitContainer2.Size = new System.Drawing.Size(1551, 861);
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "To";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "From";
            // 
            // dateTimeTo2
            // 
            this.dateTimeTo2.Location = new System.Drawing.Point(69, 92);
            this.dateTimeTo2.Name = "dateTimeTo2";
            this.dateTimeTo2.Size = new System.Drawing.Size(194, 20);
            this.dateTimeTo2.TabIndex = 5;
            this.dateTimeTo2.Value = new System.DateTime(2021, 1, 1, 13, 59, 0, 0);
            // 
            // dateTimeFrom2
            // 
            this.dateTimeFrom2.Location = new System.Drawing.Point(69, 66);
            this.dateTimeFrom2.Name = "dateTimeFrom2";
            this.dateTimeFrom2.Size = new System.Drawing.Size(194, 20);
            this.dateTimeFrom2.TabIndex = 4;
            this.dateTimeFrom2.Value = new System.DateTime(2020, 1, 1, 13, 59, 0, 0);
            // 
            // wineryList2
            // 
            this.wineryList2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.wineryList2.CheckOnClick = true;
            this.wineryList2.FormattingEnabled = true;
            this.wineryList2.Location = new System.Drawing.Point(6, 195);
            this.wineryList2.Name = "wineryList2";
            this.wineryList2.Size = new System.Drawing.Size(257, 604);
            this.wineryList2.Sorted = true;
            this.wineryList2.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(3, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(270, 51);
            this.label6.TabIndex = 2;
            this.label6.Text = "A bar chart used for visualising the weekly sales of wineries, in a certain time " +
    "period.";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(6, 118);
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
            this.plotView2.Size = new System.Drawing.Size(1271, 861);
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
            this.tabPage3.Size = new System.Drawing.Size(1557, 867);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Winery sales pie chart";
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
            this.splitContainer3.Panel1.Controls.Add(this.selectAllButton3);
            this.splitContainer3.Panel1.Controls.Add(this.clearSelectionButton3);
            this.splitContainer3.Panel1.Controls.Add(this.label7);
            this.splitContainer3.Panel1.Controls.Add(this.label8);
            this.splitContainer3.Panel1.Controls.Add(this.dateTimeTo3);
            this.splitContainer3.Panel1.Controls.Add(this.dateTimeFrom3);
            this.splitContainer3.Panel1.Controls.Add(this.wineryList3);
            this.splitContainer3.Panel1.Controls.Add(this.label9);
            this.splitContainer3.Panel1.Controls.Add(this.createGraph3);
            this.splitContainer3.Panel1MinSize = 276;
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.plotView3);
            this.splitContainer3.Size = new System.Drawing.Size(1557, 867);
            this.splitContainer3.SplitterDistance = 276;
            this.splitContainer3.TabIndex = 2;
            // 
            // selectAllButton3
            // 
            this.selectAllButton3.Location = new System.Drawing.Point(104, 166);
            this.selectAllButton3.Name = "selectAllButton3";
            this.selectAllButton3.Size = new System.Drawing.Size(83, 23);
            this.selectAllButton3.TabIndex = 9;
            this.selectAllButton3.Text = "Select ALL";
            this.selectAllButton3.UseVisualStyleBackColor = true;
            this.selectAllButton3.Click += new System.EventHandler(this.selectAllButton3_Click);
            // 
            // clearSelectionButton3
            // 
            this.clearSelectionButton3.Location = new System.Drawing.Point(6, 166);
            this.clearSelectionButton3.Name = "clearSelectionButton3";
            this.clearSelectionButton3.Size = new System.Drawing.Size(92, 23);
            this.clearSelectionButton3.TabIndex = 8;
            this.clearSelectionButton3.Text = "Clear Selection";
            this.clearSelectionButton3.UseVisualStyleBackColor = true;
            this.clearSelectionButton3.Click += new System.EventHandler(this.clearSelectionButton3_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(32, 98);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(20, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "To";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 72);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "From";
            // 
            // dateTimeTo3
            // 
            this.dateTimeTo3.Location = new System.Drawing.Point(69, 92);
            this.dateTimeTo3.Name = "dateTimeTo3";
            this.dateTimeTo3.Size = new System.Drawing.Size(194, 20);
            this.dateTimeTo3.TabIndex = 5;
            this.dateTimeTo3.Value = new System.DateTime(2021, 1, 1, 13, 59, 0, 0);
            // 
            // dateTimeFrom3
            // 
            this.dateTimeFrom3.Location = new System.Drawing.Point(69, 66);
            this.dateTimeFrom3.Name = "dateTimeFrom3";
            this.dateTimeFrom3.Size = new System.Drawing.Size(194, 20);
            this.dateTimeFrom3.TabIndex = 4;
            this.dateTimeFrom3.Value = new System.DateTime(2020, 1, 1, 13, 59, 0, 0);
            // 
            // wineryList3
            // 
            this.wineryList3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.wineryList3.CheckOnClick = true;
            this.wineryList3.FormattingEnabled = true;
            this.wineryList3.Location = new System.Drawing.Point(6, 195);
            this.wineryList3.Name = "wineryList3";
            this.wineryList3.Size = new System.Drawing.Size(257, 604);
            this.wineryList3.Sorted = true;
            this.wineryList3.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(3, 13);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(270, 51);
            this.label9.TabIndex = 2;
            this.label9.Text = "A pie chart used for visualising the sales of each winery in the time period.";
            // 
            // createGraph3
            // 
            this.createGraph3.Location = new System.Drawing.Point(6, 118);
            this.createGraph3.Name = "createGraph3";
            this.createGraph3.Size = new System.Drawing.Size(257, 23);
            this.createGraph3.TabIndex = 1;
            this.createGraph3.Text = "Create Graph";
            this.createGraph3.UseVisualStyleBackColor = true;
            this.createGraph3.Click += new System.EventHandler(this.createGraph3_Click);
            // 
            // plotView3
            // 
            this.plotView3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plotView3.Location = new System.Drawing.Point(0, 0);
            this.plotView3.Name = "plotView3";
            this.plotView3.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.plotView3.Size = new System.Drawing.Size(1277, 867);
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
            // GraphsTabControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "GraphsTabControl1";
            this.Size = new System.Drawing.Size(1565, 893);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
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
        private OxyPlot.WindowsForms.PlotView plotView1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimeTo1;
        private System.Windows.Forms.DateTimePicker dateTimeFrom1;
        private System.Windows.Forms.CheckedListBox wineryList1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button SelectAllButton1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimeTo2;
        private System.Windows.Forms.DateTimePicker dateTimeFrom2;
        private System.Windows.Forms.CheckedListBox wineryList2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button4;
        private OxyPlot.WindowsForms.PlotView plotView2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Button selectAllButton3;
        private System.Windows.Forms.Button clearSelectionButton3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dateTimeTo3;
        private System.Windows.Forms.DateTimePicker dateTimeFrom3;
        private System.Windows.Forms.CheckedListBox wineryList3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button createGraph3;
        private OxyPlot.WindowsForms.PlotView plotView3;
    }
}
