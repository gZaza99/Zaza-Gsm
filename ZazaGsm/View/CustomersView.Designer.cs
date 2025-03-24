namespace ZazaGsm.View
{
    partial class CustomersView
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
            PanelFilter = new Panel();
            FilterView = new FilterView1();
            PanelMain = new Panel();
            Grid = new DataGridView();
            ColName = new DataGridViewTextBoxColumn();
            ColDept = new DataGridViewTextBoxColumn();
            ColBarcode = new DataGridViewTextBoxColumn();
            PanelFilter.SuspendLayout();
            PanelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Grid).BeginInit();
            SuspendLayout();
            // 
            // PanelFilter
            // 
            PanelFilter.Controls.Add(FilterView);
            PanelFilter.Dock = DockStyle.Top;
            PanelFilter.Location = new Point(0, 0);
            PanelFilter.Name = "PanelFilter";
            PanelFilter.Size = new Size(715, 85);
            PanelFilter.TabIndex = 1;
            // 
            // FilterView
            // 
            FilterView.Dock = DockStyle.Fill;
            FilterView.Location = new Point(0, 0);
            FilterView.Name = "FilterView";
            FilterView.Size = new Size(715, 85);
            FilterView.TabIndex = 0;
            // 
            // PanelMain
            // 
            PanelMain.Controls.Add(Grid);
            PanelMain.Dock = DockStyle.Fill;
            PanelMain.Location = new Point(0, 85);
            PanelMain.Name = "PanelMain";
            PanelMain.Size = new Size(715, 277);
            PanelMain.TabIndex = 2;
            // 
            // Grid
            // 
            Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            Grid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            Grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Grid.Columns.AddRange(new DataGridViewColumn[] { ColName, ColDept, ColBarcode });
            Grid.Dock = DockStyle.Fill;
            Grid.Location = new Point(0, 0);
            Grid.Name = "Grid";
            Grid.RowHeadersWidth = 80;
            Grid.RowTemplate.Height = 29;
            Grid.Size = new Size(715, 277);
            Grid.TabIndex = 0;
            // 
            // ColName
            // 
            ColName.HeaderText = "Name";
            ColName.MinimumWidth = 6;
            ColName.Name = "ColName";
            // 
            // ColDept
            // 
            ColDept.HeaderText = "Dept";
            ColDept.MinimumWidth = 6;
            ColDept.Name = "ColDept";
            // 
            // ColBarcode
            // 
            ColBarcode.HeaderText = "Barcode";
            ColBarcode.MinimumWidth = 6;
            ColBarcode.Name = "ColBarcode";
            // 
            // CustomersView
            // 
            AutoScaleDimensions = new SizeF(12F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(PanelMain);
            Controls.Add(PanelFilter);
            Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(7, 4, 7, 4);
            Name = "CustomersView";
            Size = new Size(715, 362);
            PanelFilter.ResumeLayout(false);
            PanelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Grid).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel PanelFilter;
        private Panel PanelMain;
        private DataGridView Grid;
        private DataGridViewTextBoxColumn ColName;
        private DataGridViewTextBoxColumn ColDept;
        private DataGridViewTextBoxColumn ColBarcode;
        private FilterView1 FilterView;
    }
}
