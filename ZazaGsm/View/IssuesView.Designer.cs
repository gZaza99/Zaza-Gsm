namespace ZazaGsm.View
{
    partial class IssuesView
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
            PanelFilter = new Panel();
            FilterView = new FilterView1();
            PanelDetails = new Panel();
            DtpAnnouncement = new DateTimePicker();
            DtpClosing = new DateTimePicker();
            LblClosing = new Label();
            LblAnnouncement = new Label();
            TxtbCustomer = new TextBox();
            LblCustomer = new Label();
            CheckPayed = new CheckBox();
            TxtbQuoCurrency = new TextBox();
            LblQuoCurrency = new Label();
            TxtbQuotation = new TextBox();
            LblQuotation = new Label();
            TxtbOpinion = new RichTextBox();
            TxtbComplaint = new RichTextBox();
            LblOpinion = new Label();
            LblComplaint = new Label();
            PanelGrid = new Panel();
            Grid = new DataGridView();
            ColDevice = new DataGridViewComboBoxColumn();
            ColComplaint = new DataGridViewTextBoxColumn();
            ColAccepted = new DataGridViewCheckBoxColumn();
            Status = new DataGridViewComboBoxColumn();
            ColStatusReason = new DataGridViewTextBoxColumn();
            PanelFilter.SuspendLayout();
            PanelDetails.SuspendLayout();
            PanelGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Grid).BeginInit();
            SuspendLayout();
            // 
            // PanelFilter
            // 
            PanelFilter.Controls.Add(FilterView);
            PanelFilter.Dock = DockStyle.Top;
            PanelFilter.Location = new Point(0, 0);
            PanelFilter.Name = "PanelFilter";
            PanelFilter.Size = new Size(716, 86);
            PanelFilter.TabIndex = 0;
            // 
            // FilterView
            // 
            FilterView.Dock = DockStyle.Top;
            FilterView.Location = new Point(0, 0);
            FilterView.Name = "FilterView";
            FilterView.Size = new Size(716, 85);
            FilterView.TabIndex = 0;
            // 
            // PanelDetails
            // 
            PanelDetails.Controls.Add(DtpAnnouncement);
            PanelDetails.Controls.Add(DtpClosing);
            PanelDetails.Controls.Add(LblClosing);
            PanelDetails.Controls.Add(LblAnnouncement);
            PanelDetails.Controls.Add(TxtbCustomer);
            PanelDetails.Controls.Add(LblCustomer);
            PanelDetails.Controls.Add(CheckPayed);
            PanelDetails.Controls.Add(TxtbQuoCurrency);
            PanelDetails.Controls.Add(LblQuoCurrency);
            PanelDetails.Controls.Add(TxtbQuotation);
            PanelDetails.Controls.Add(LblQuotation);
            PanelDetails.Controls.Add(TxtbOpinion);
            PanelDetails.Controls.Add(TxtbComplaint);
            PanelDetails.Controls.Add(LblOpinion);
            PanelDetails.Controls.Add(LblComplaint);
            PanelDetails.Dock = DockStyle.Bottom;
            PanelDetails.Location = new Point(0, 380);
            PanelDetails.Name = "PanelDetails";
            PanelDetails.Size = new Size(716, 239);
            PanelDetails.TabIndex = 1;
            // 
            // DtpAnnouncement
            // 
            DtpAnnouncement.Format = DateTimePickerFormat.Custom;
            DtpAnnouncement.Location = new Point(180, 202);
            DtpAnnouncement.Name = "DtpAnnouncement";
            DtpAnnouncement.Size = new Size(127, 27);
            DtpAnnouncement.TabIndex = 17;
            DtpAnnouncement.Value = new DateTime(2024, 7, 25, 0, 0, 0, 0);
            // 
            // DtpClosing
            // 
            DtpClosing.Format = DateTimePickerFormat.Custom;
            DtpClosing.Location = new Point(586, 202);
            DtpClosing.Name = "DtpClosing";
            DtpClosing.Size = new Size(127, 27);
            DtpClosing.TabIndex = 16;
            DtpClosing.Value = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            // 
            // LblClosing
            // 
            LblClosing.AutoSize = true;
            LblClosing.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            LblClosing.Location = new Point(435, 198);
            LblClosing.Name = "LblClosing";
            LblClosing.Size = new Size(149, 28);
            LblClosing.TabIndex = 14;
            LblClosing.Text = "Lezárás Dátuma";
            // 
            // LblAnnouncement
            // 
            LblAnnouncement.AutoSize = true;
            LblAnnouncement.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            LblAnnouncement.Location = new Point(5, 198);
            LblAnnouncement.Name = "LblAnnouncement";
            LblAnnouncement.Size = new Size(173, 28);
            LblAnnouncement.TabIndex = 12;
            LblAnnouncement.Text = "Bejelentés Dátuma";
            // 
            // TxtbCustomer
            // 
            TxtbCustomer.Enabled = false;
            TxtbCustomer.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            TxtbCustomer.Location = new Point(522, 155);
            TxtbCustomer.Name = "TxtbCustomer";
            TxtbCustomer.Size = new Size(191, 34);
            TxtbCustomer.TabIndex = 11;
            TxtbCustomer.Leave += InpControl_Leave;
            // 
            // LblCustomer
            // 
            LblCustomer.AutoSize = true;
            LblCustomer.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            LblCustomer.Location = new Point(447, 158);
            LblCustomer.Name = "LblCustomer";
            LblCustomer.Size = new Size(69, 28);
            LblCustomer.TabIndex = 10;
            LblCustomer.Text = "Ügyfél";
            // 
            // CheckPayed
            // 
            CheckPayed.AutoSize = true;
            CheckPayed.CheckAlign = ContentAlignment.MiddleRight;
            CheckPayed.Enabled = false;
            CheckPayed.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            CheckPayed.Location = new Point(443, 117);
            CheckPayed.Name = "CheckPayed";
            CheckPayed.Size = new Size(95, 32);
            CheckPayed.TabIndex = 9;
            CheckPayed.Text = "Fizetve";
            CheckPayed.UseVisualStyleBackColor = true;
            // 
            // TxtbQuoCurrency
            // 
            TxtbQuoCurrency.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            TxtbQuoCurrency.Location = new Point(522, 77);
            TxtbQuoCurrency.Name = "TxtbQuoCurrency";
            TxtbQuoCurrency.Size = new Size(191, 34);
            TxtbQuoCurrency.TabIndex = 7;
            TxtbQuoCurrency.Leave += InpControl_Leave;
            // 
            // LblQuoCurrency
            // 
            LblQuoCurrency.AutoSize = true;
            LblQuoCurrency.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            LblQuoCurrency.Location = new Point(450, 80);
            LblQuoCurrency.Name = "LblQuoCurrency";
            LblQuoCurrency.Size = new Size(66, 28);
            LblQuoCurrency.TabIndex = 6;
            LblQuoCurrency.Text = "Valuta";
            // 
            // TxtbQuotation
            // 
            TxtbQuotation.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            TxtbQuotation.Location = new Point(522, 37);
            TxtbQuotation.Name = "TxtbQuotation";
            TxtbQuotation.Size = new Size(191, 34);
            TxtbQuotation.TabIndex = 5;
            TxtbQuotation.Leave += InpControl_Leave;
            // 
            // LblQuotation
            // 
            LblQuotation.AutoSize = true;
            LblQuotation.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            LblQuotation.Location = new Point(443, 40);
            LblQuotation.Name = "LblQuotation";
            LblQuotation.Size = new Size(73, 28);
            LblQuotation.TabIndex = 4;
            LblQuotation.Text = "Ajánlat";
            // 
            // TxtbOpinion
            // 
            TxtbOpinion.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            TxtbOpinion.Location = new Point(211, 37);
            TxtbOpinion.Name = "TxtbOpinion";
            TxtbOpinion.Size = new Size(192, 152);
            TxtbOpinion.TabIndex = 3;
            TxtbOpinion.Text = "";
            TxtbOpinion.Leave += InpControl_Leave;
            // 
            // TxtbComplaint
            // 
            TxtbComplaint.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            TxtbComplaint.Location = new Point(5, 37);
            TxtbComplaint.Name = "TxtbComplaint";
            TxtbComplaint.Size = new Size(192, 152);
            TxtbComplaint.TabIndex = 2;
            TxtbComplaint.Text = "";
            TxtbComplaint.Leave += InpControl_Leave;
            // 
            // LblOpinion
            // 
            LblOpinion.AutoSize = true;
            LblOpinion.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            LblOpinion.Location = new Point(211, 6);
            LblOpinion.Name = "LblOpinion";
            LblOpinion.Size = new Size(96, 28);
            LblOpinion.TabIndex = 1;
            LblOpinion.Text = "Vélemény";
            // 
            // LblComplaint
            // 
            LblComplaint.AutoSize = true;
            LblComplaint.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            LblComplaint.Location = new Point(5, 6);
            LblComplaint.Name = "LblComplaint";
            LblComplaint.Size = new Size(70, 28);
            LblComplaint.TabIndex = 0;
            LblComplaint.Text = "Panasz";
            // 
            // PanelGrid
            // 
            PanelGrid.Controls.Add(Grid);
            PanelGrid.Dock = DockStyle.Fill;
            PanelGrid.Location = new Point(0, 86);
            PanelGrid.Name = "PanelGrid";
            PanelGrid.Size = new Size(716, 294);
            PanelGrid.TabIndex = 2;
            // 
            // Grid
            // 
            Grid.AllowUserToOrderColumns = true;
            Grid.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Grid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            Grid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            Grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            Grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Grid.Columns.AddRange(new DataGridViewColumn[] { ColDevice, ColComplaint, ColAccepted, Status, ColStatusReason });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            Grid.DefaultCellStyle = dataGridViewCellStyle3;
            Grid.Dock = DockStyle.Fill;
            Grid.Location = new Point(0, 0);
            Grid.Name = "Grid";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            Grid.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            Grid.RowHeadersWidth = 80;
            Grid.RowTemplate.DefaultCellStyle.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Grid.RowTemplate.Height = 56;
            Grid.Size = new Size(716, 294);
            Grid.TabIndex = 0;
            Grid.CellBeginEdit += Grid_CellBeginEdit;
            Grid.CellEnter += Grid_CellEnter;
            Grid.RowLeave += Grid_RowLeave;
            Grid.RowsAdded += Grid_RowsAdded;
            // 
            // ColDevice
            // 
            ColDevice.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ColDevice.FillWeight = 80F;
            ColDevice.HeaderText = "Eszköz";
            ColDevice.MinimumWidth = 6;
            ColDevice.Name = "ColDevice";
            // 
            // ColComplaint
            // 
            ColComplaint.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ColComplaint.FillWeight = 116.570786F;
            ColComplaint.HeaderText = "Panasz";
            ColComplaint.MinimumWidth = 6;
            ColComplaint.Name = "ColComplaint";
            // 
            // ColAccepted
            // 
            ColAccepted.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            ColAccepted.FillWeight = 60.99634F;
            ColAccepted.HeaderText = "Elfogadva";
            ColAccepted.MinimumWidth = 6;
            ColAccepted.Name = "ColAccepted";
            ColAccepted.Width = 77;
            // 
            // Status
            // 
            Status.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Status.DataPropertyName = "Complaint";
            Status.FillWeight = 116.570786F;
            Status.HeaderText = "Státus";
            Status.MinimumWidth = 6;
            Status.Name = "Status";
            Status.Width = 146;
            // 
            // ColStatusReason
            // 
            ColStatusReason.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            ColStatusReason.FillWeight = 116.570786F;
            ColStatusReason.HeaderText = "Státus oka";
            ColStatusReason.MinimumWidth = 6;
            ColStatusReason.Name = "ColStatusReason";
            ColStatusReason.Width = 147;
            // 
            // IssuesView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(PanelGrid);
            Controls.Add(PanelDetails);
            Controls.Add(PanelFilter);
            Name = "IssuesView";
            Size = new Size(716, 619);
            PanelFilter.ResumeLayout(false);
            PanelDetails.ResumeLayout(false);
            PanelDetails.PerformLayout();
            PanelGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Grid).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel PanelFilter;
        private Panel PanelDetails;
        private Panel PanelGrid;
        private DataGridView Grid;
        private Label LblComplaint;
        private Label LblOpinion;
        private RichTextBox TxtbOpinion;
        private RichTextBox TxtbComplaint;
        private TextBox TxtbQuotation;
        private Label LblQuotation;
        private TextBox TxtbQuoCurrency;
        private Label LblQuoCurrency;
        private CheckBox CheckPayed;
        private TextBox TxtbCustomer;
        private Label LblCustomer;
        private FilterView1 FilterView;
        private DataGridViewComboBoxColumn ColDevice;
        private DataGridViewTextBoxColumn ColComplaint;
        private DataGridViewCheckBoxColumn ColAccepted;
        private DataGridViewComboBoxColumn Status;
        private DataGridViewTextBoxColumn ColStatusReason;
        private Label LblAnnouncement;
        private Label LblClosing;
        private DateTimePicker DtpClosing;
        private DateTimePicker DtpAnnouncement;
    }
}
