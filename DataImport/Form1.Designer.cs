namespace DataImport
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            btnLoadData = new Button();
            formsPlot1 = new ScottPlot.FormsPlot();
            btnExport = new Button();
            btnExportDb = new Button();
            SuspendLayout();
            // 
            // btnLoadData
            // 
            btnLoadData.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLoadData.Location = new Point(883, 41);
            btnLoadData.Name = "btnLoadData";
            btnLoadData.Size = new Size(83, 30);
            btnLoadData.TabIndex = 0;
            btnLoadData.Text = "读取数据";
            btnLoadData.UseVisualStyleBackColor = true;
            btnLoadData.Click += btnLoadData_Click;
            // 
            // formsPlot1
            // 
            formsPlot1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            formsPlot1.Location = new Point(13, 12);
            formsPlot1.Margin = new Padding(4, 3, 4, 3);
            formsPlot1.Name = "formsPlot1";
            formsPlot1.Size = new Size(852, 477);
            formsPlot1.TabIndex = 1;
            // 
            // btnExport
            // 
            btnExport.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExport.Location = new Point(883, 75);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(83, 30);
            btnExport.TabIndex = 0;
            btnExport.Text = "导出CSV";
            btnExport.UseVisualStyleBackColor = true;
            btnExport.Click += btnExport_Click;
            // 
            // btnExportDb
            // 
            btnExportDb.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExportDb.Location = new Point(883, 111);
            btnExportDb.Name = "btnExportDb";
            btnExportDb.Size = new Size(83, 30);
            btnExportDb.TabIndex = 0;
            btnExportDb.Text = "导出数据库";
            btnExportDb.UseVisualStyleBackColor = true;
            btnExportDb.Click += btnExportDb_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(993, 501);
            Controls.Add(formsPlot1);
            Controls.Add(btnExportDb);
            Controls.Add(btnExport);
            Controls.Add(btnLoadData);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "数据输入";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btnLoadData;
        private ScottPlot.FormsPlot formsPlot1;
        private Button btnExport;
        private Button btnExportDb;
    }
}