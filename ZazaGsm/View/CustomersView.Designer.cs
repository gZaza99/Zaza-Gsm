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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
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
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            Grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            Grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Grid.Columns.AddRange(new DataGridViewColumn[] { ColName, ColDept, ColBarcode });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            Grid.DefaultCellStyle = dataGridViewCellStyle2;
            Grid.Dock = DockStyle.Fill;
            Grid.Location = new Point(0, 0);
            Grid.Name = "Grid";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            Grid.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
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
