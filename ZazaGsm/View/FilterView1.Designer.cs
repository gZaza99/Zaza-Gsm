namespace ZazaGsm.View
{
    partial class FilterView1
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
            Panel = new Panel();
            TxtbValue = new TextBox();
            CheckNegate = new CheckBox();
            ComboRelation = new ComboBox();
            ComboPropertyFilter = new ComboBox();
            LblFilter = new Label();
            Panel.SuspendLayout();
            SuspendLayout();
            // 
            // Panel
            // 
            Panel.Controls.Add(TxtbValue);
            Panel.Controls.Add(CheckNegate);
            Panel.Controls.Add(ComboRelation);
            Panel.Controls.Add(ComboPropertyFilter);
            Panel.Controls.Add(LblFilter);
            Panel.Dock = DockStyle.Fill;
            Panel.Location = new Point(0, 0);
            Panel.Name = "Panel";
            Panel.Size = new Size(715, 85);
            Panel.TabIndex = 0;
            // 
            // TxtbValue
            // 
            TxtbValue.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            TxtbValue.Location = new Point(396, 31);
            TxtbValue.Name = "TxtbValue";
            TxtbValue.Size = new Size(315, 34);
            TxtbValue.TabIndex = 9;
            // 
            // CheckNegate
            // 
            CheckNegate.AutoSize = true;
            CheckNegate.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            CheckNegate.Location = new Point(160, 33);
            CheckNegate.Name = "CheckNegate";
            CheckNegate.Size = new Size(77, 32);
            CheckNegate.TabIndex = 8;
            CheckNegate.Text = "NEM";
            CheckNegate.UseVisualStyleBackColor = true;
            // 
            // ComboRelation
            // 
            ComboRelation.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ComboRelation.FormattingEnabled = true;
            ComboRelation.Items.AddRange(new object[] { "Equals", "Contains" });
            ComboRelation.Location = new Point(239, 30);
            ComboRelation.Name = "ComboRelation";
            ComboRelation.Size = new Size(151, 36);
            ComboRelation.TabIndex = 7;
            // 
            // ComboPropertyFilter
            // 
            ComboPropertyFilter.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ComboPropertyFilter.FormattingEnabled = true;
            ComboPropertyFilter.Location = new Point(3, 31);
            ComboPropertyFilter.Name = "ComboPropertyFilter";
            ComboPropertyFilter.Size = new Size(151, 36);
            ComboPropertyFilter.TabIndex = 6;
            // 
            // LblFilter
            // 
            LblFilter.AutoSize = true;
            LblFilter.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            LblFilter.Location = new Point(3, 0);
            LblFilter.Name = "LblFilter";
            LblFilter.Size = new Size(61, 28);
            LblFilter.TabIndex = 5;
            LblFilter.Text = "Szűrő";
            // 
            // FilterView1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(Panel);
            Name = "FilterView1";
            Size = new Size(715, 85);
            Panel.ResumeLayout(false);
            Panel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel Panel;
        private TextBox TxtbValue;
        private CheckBox CheckNegate;
        private ComboBox ComboRelation;
        private ComboBox ComboPropertyFilter;
        private Label LblFilter;
    }
}
