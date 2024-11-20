namespace ZazaGsm.View
{
    partial class DevicesView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DevicesView));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            panel1 = new Panel();
            splitContainer1 = new SplitContainer();
            BtnInvoices = new Button();
            FilterView = new FilterView2();
            PictureBox = new PictureBox();
            panel2 = new Panel();
            Grid = new DataGridView();
            ColType = new DataGridViewTextBoxColumn();
            ColFrontImagePath = new DataGridViewTextBoxColumn();
            ColBackImagePath = new DataGridViewTextBoxColumn();
            ColBarcode = new DataGridViewTextBoxColumn();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PictureBox).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Grid).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(splitContainer1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(772, 124);
            panel1.TabIndex = 0;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.FixedPanel = FixedPanel.Panel2;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(BtnInvoices);
            splitContainer1.Panel1.Controls.Add(FilterView);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(PictureBox);
            splitContainer1.Size = new Size(772, 124);
            splitContainer1.SplitterDistance = 564;
            splitContainer1.TabIndex = 0;
            // 
            // BtnInvoices
            // 
            BtnInvoices.BackgroundImage = (Image)resources.GetObject("BtnInvoices.BackgroundImage");
            BtnInvoices.BackgroundImageLayout = ImageLayout.Stretch;
            BtnInvoices.Location = new Point(455, 23);
            BtnInvoices.Name = "BtnInvoices";
            BtnInvoices.Size = new Size(86, 86);
            BtnInvoices.TabIndex = 5;
            BtnInvoices.UseVisualStyleBackColor = true;
            BtnInvoices.Click += BtnInvoices_Click;
            // 
            // FilterView
            // 
            FilterView.Dock = DockStyle.Fill;
            FilterView.Location = new Point(0, 0);
            FilterView.Name = "FilterView";
            FilterView.Size = new Size(564, 124);
            FilterView.TabIndex = 0;
            // 
            // PictureBox
            // 
            PictureBox.BackColor = SystemColors.ControlLightLight;
            PictureBox.Dock = DockStyle.Fill;
            PictureBox.Location = new Point(0, 0);
            PictureBox.Name = "PictureBox";
            PictureBox.Size = new Size(204, 124);
            PictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBox.TabIndex = 0;
            PictureBox.TabStop = false;
            // 
            // panel2
            // 
            panel2.Controls.Add(Grid);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 124);
            panel2.Name = "panel2";
            panel2.Size = new Size(772, 359);
            panel2.TabIndex = 1;
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
            Grid.Columns.AddRange(new DataGridViewColumn[] { ColType, ColFrontImagePath, ColBackImagePath, ColBarcode });
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
            Grid.Size = new Size(772, 359);
            Grid.TabIndex = 0;
            Grid.CellEnter += Grid_CellEnter;
            // 
            // ColType
            // 
            ColType.HeaderText = "Type";
            ColType.MinimumWidth = 6;
            ColType.Name = "ColType";
            // 
            // ColFrontImagePath
            // 
            ColFrontImagePath.HeaderText = "Front image";
            ColFrontImagePath.MinimumWidth = 6;
            ColFrontImagePath.Name = "ColFrontImagePath";
            // 
            // ColBackImagePath
            // 
            ColBackImagePath.HeaderText = "Back image";
            ColBackImagePath.MinimumWidth = 6;
            ColBackImagePath.Name = "ColBackImagePath";
            // 
            // ColBarcode
            // 
            ColBarcode.HeaderText = "Barcode";
            ColBarcode.MinimumWidth = 6;
            ColBarcode.Name = "ColBarcode";
            // 
            // DevicesView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "DevicesView";
            Size = new Size(772, 483);
            panel1.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)PictureBox).EndInit();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Grid).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private SplitContainer splitContainer1;
        private Panel panel2;
        private DataGridView Grid;
        private FilterView2 FilterView;
        private PictureBox PictureBox;
        private Button BtnInvoices;
        private DataGridViewTextBoxColumn ColType;
        private DataGridViewTextBoxColumn ColFrontImagePath;
        private DataGridViewTextBoxColumn ColBackImagePath;
        private DataGridViewTextBoxColumn ColBarcode;
    }
}
