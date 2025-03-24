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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DevicesView));
            panel1 = new Panel();
            FilterView = new FilterView2();
            PictureBox = new PictureBox();
            panel2 = new Panel();
            Grid = new DataGridView();
            ColType = new DataGridViewTextBoxColumn();
            ColFrontImagePath = new DataGridViewTextBoxColumn();
            ColBackImagePath = new DataGridViewTextBoxColumn();
            ColBarcode = new DataGridViewTextBoxColumn();
            BtnInvoices = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PictureBox).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Grid).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(BtnInvoices);
            panel1.Controls.Add(FilterView);
            panel1.Controls.Add(PictureBox);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(772, 124);
            panel1.TabIndex = 0;
            // 
            // FilterView
            // 
            FilterView.Location = new Point(0, 0);
            FilterView.Name = "FilterView";
            FilterView.Size = new Size(394, 124);
            FilterView.TabIndex = 0;
            // 
            // PictureBox
            // 
            PictureBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            PictureBox.BackColor = SystemColors.ControlLightLight;
            PictureBox.Location = new Point(568, 0);
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
            // BtnInvoices
            // 
            BtnInvoices.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BtnInvoices.BackgroundImage = (Image)resources.GetObject("BtnInvoices.BackgroundImage");
            BtnInvoices.BackgroundImageLayout = ImageLayout.Stretch;
            BtnInvoices.Location = new Point(455, 21);
            BtnInvoices.Name = "BtnInvoices";
            BtnInvoices.Size = new Size(86, 86);
            BtnInvoices.TabIndex = 5;
            BtnInvoices.UseVisualStyleBackColor = true;
            BtnInvoices.Click += BtnInvoices_Click;
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
            ((System.ComponentModel.ISupportInitialize)PictureBox).EndInit();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Grid).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private DataGridView Grid;
        private FilterView2 FilterView;
        private PictureBox PictureBox;
        private DataGridViewTextBoxColumn ColType;
        private DataGridViewTextBoxColumn ColFrontImagePath;
        private DataGridViewTextBoxColumn ColBackImagePath;
        private DataGridViewTextBoxColumn ColBarcode;
        private Button BtnInvoices;
    }
}
