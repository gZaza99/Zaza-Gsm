namespace ZazaGsm.View
{
    partial class InvoicesView
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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            PanelFilter = new Panel();
            FilterView = new FilterView1();
            PanelMain = new Panel();
            splitContainer1 = new SplitContainer();
            GridInvoices = new DataGridView();
            ColTotalSum = new DataGridViewTextBoxColumn();
            ColHeadCurrency = new DataGridViewTextBoxColumn();
            ColName = new DataGridViewTextBoxColumn();
            ColCustomer = new DataGridViewTextBoxColumn();
            ColHeadStatus = new DataGridViewTextBoxColumn();
            GridInvoiceItems = new DataGridView();
            ColSum = new DataGridViewTextBoxColumn();
            ColCurrency = new DataGridViewTextBoxColumn();
            ColRemarks = new DataGridViewTextBoxColumn();
            ColStatus = new DataGridViewComboBoxColumn();
            ColIssue = new DataGridViewTextBoxColumn();
            PanelFilter.SuspendLayout();
            PanelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)GridInvoices).BeginInit();
            ((System.ComponentModel.ISupportInitialize)GridInvoiceItems).BeginInit();
            SuspendLayout();
            // 
            // PanelFilter
            // 
            PanelFilter.Controls.Add(FilterView);
            PanelFilter.Dock = DockStyle.Top;
            PanelFilter.Location = new Point(0, 0);
            PanelFilter.Name = "PanelFilter";
            PanelFilter.Size = new Size(715, 85);
            PanelFilter.TabIndex = 0;
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
            PanelMain.Controls.Add(splitContainer1);
            PanelMain.Dock = DockStyle.Fill;
            PanelMain.Location = new Point(0, 85);
            PanelMain.Name = "PanelMain";
            PanelMain.Size = new Size(715, 615);
            PanelMain.TabIndex = 1;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(GridInvoices);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(GridInvoiceItems);
            splitContainer1.Size = new Size(715, 615);
            splitContainer1.SplitterDistance = 303;
            splitContainer1.TabIndex = 0;
            // 
            // GridInvoices
            // 
            GridInvoices.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            GridInvoices.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            GridInvoices.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            GridInvoices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GridInvoices.Columns.AddRange(new DataGridViewColumn[] { ColTotalSum, ColHeadCurrency, ColName, ColCustomer, ColHeadStatus });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            GridInvoices.DefaultCellStyle = dataGridViewCellStyle2;
            GridInvoices.Dock = DockStyle.Fill;
            GridInvoices.Location = new Point(0, 0);
            GridInvoices.Name = "GridInvoices";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            GridInvoices.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            GridInvoices.RowHeadersWidth = 80;
            GridInvoices.RowTemplate.Height = 29;
            GridInvoices.Size = new Size(715, 303);
            GridInvoices.TabIndex = 0;
            GridInvoices.CellClick += GridInvoices_CellClick;
            GridInvoices.RowLeave += GridInvoices_RowLeave;
            // 
            // ColTotalSum
            // 
            ColTotalSum.HeaderText = "Végösszeg";
            ColTotalSum.MinimumWidth = 6;
            ColTotalSum.Name = "ColTotalSum";
            ColTotalSum.ReadOnly = true;
            // 
            // ColHeadCurrency
            // 
            ColHeadCurrency.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            ColHeadCurrency.HeaderText = "Valuta";
            ColHeadCurrency.MinimumWidth = 6;
            ColHeadCurrency.Name = "ColHeadCurrency";
            ColHeadCurrency.Width = 70;
            // 
            // ColName
            // 
            ColName.HeaderText = "Ügyfél név";
            ColName.MinimumWidth = 6;
            ColName.Name = "ColName";
            ColName.ReadOnly = true;
            // 
            // ColCustomer
            // 
            ColCustomer.HeaderText = "Ügyfél ID";
            ColCustomer.MinimumWidth = 6;
            ColCustomer.Name = "ColCustomer";
            // 
            // ColHeadStatus
            // 
            ColHeadStatus.HeaderText = "Státusz";
            ColHeadStatus.MinimumWidth = 6;
            ColHeadStatus.Name = "ColHeadStatus";
            ColHeadStatus.ReadOnly = true;
            // 
            // GridInvoiceItems
            // 
            GridInvoiceItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            GridInvoiceItems.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            GridInvoiceItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            GridInvoiceItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GridInvoiceItems.Columns.AddRange(new DataGridViewColumn[] { ColSum, ColCurrency, ColRemarks, ColStatus, ColIssue });
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = SystemColors.Window;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            GridInvoiceItems.DefaultCellStyle = dataGridViewCellStyle5;
            GridInvoiceItems.Dock = DockStyle.Fill;
            GridInvoiceItems.Location = new Point(0, 0);
            GridInvoiceItems.Name = "GridInvoiceItems";
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = SystemColors.Control;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle6.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            GridInvoiceItems.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            GridInvoiceItems.RowHeadersWidth = 80;
            GridInvoiceItems.RowTemplate.Height = 29;
            GridInvoiceItems.Size = new Size(715, 308);
            GridInvoiceItems.TabIndex = 0;
            // 
            // ColSum
            // 
            ColSum.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            ColSum.FillWeight = 68F;
            ColSum.HeaderText = "Összeg";
            ColSum.MinimumWidth = 6;
            ColSum.Name = "ColSum";
            ColSum.Width = 81;
            // 
            // ColCurrency
            // 
            ColCurrency.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            ColCurrency.FillWeight = 60F;
            ColCurrency.HeaderText = "Valuta";
            ColCurrency.MinimumWidth = 6;
            ColCurrency.Name = "ColCurrency";
            ColCurrency.Width = 71;
            // 
            // ColRemarks
            // 
            ColRemarks.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ColRemarks.FillWeight = 139.3926F;
            ColRemarks.HeaderText = "Leítás";
            ColRemarks.MinimumWidth = 6;
            ColRemarks.Name = "ColRemarks";
            // 
            // ColStatus
            // 
            ColStatus.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            ColStatus.FillWeight = 139.3926F;
            ColStatus.HeaderText = "Státusz";
            ColStatus.MinimumWidth = 6;
            ColStatus.Name = "ColStatus";
            ColStatus.Resizable = DataGridViewTriState.True;
            ColStatus.Width = 165;
            // 
            // ColIssue
            // 
            ColIssue.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            ColIssue.FillWeight = 57.75401F;
            ColIssue.HeaderText = "FID";
            ColIssue.MinimumWidth = 6;
            ColIssue.Name = "ColIssue";
            ColIssue.Resizable = DataGridViewTriState.True;
            ColIssue.SortMode = DataGridViewColumnSortMode.NotSortable;
            ColIssue.Width = 68;
            // 
            // InvoicesView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(PanelMain);
            Controls.Add(PanelFilter);
            Name = "InvoicesView";
            Size = new Size(715, 700);
            PanelFilter.ResumeLayout(false);
            PanelMain.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)GridInvoices).EndInit();
            ((System.ComponentModel.ISupportInitialize)GridInvoiceItems).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel PanelFilter;
        private Panel PanelMain;
        private SplitContainer splitContainer1;
        private DataGridView GridInvoices;
        private DataGridView GridInvoiceItems;
        private FilterView1 FilterView;
        private DataGridViewTextBoxColumn ColTotalSum;
        private DataGridViewTextBoxColumn ColHeadCurrency;
        private DataGridViewTextBoxColumn ColName;
        private DataGridViewTextBoxColumn ColCustomer;
        private DataGridViewTextBoxColumn ColHeadStatus;
        private DataGridViewTextBoxColumn ColSum;
        private DataGridViewTextBoxColumn ColCurrency;
        private DataGridViewTextBoxColumn ColRemarks;
        private DataGridViewComboBoxColumn ColStatus;
        private DataGridViewTextBoxColumn ColIssue;
    }
}
