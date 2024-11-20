namespace ZazaGsm.View
{
    partial class SettingsView
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
            lblDbAddress = new Label();
            lblDbName = new Label();
            lblUsrName = new Label();
            lblUsrPassword = new Label();
            inpDbAddress = new TextBox();
            inpDbName = new TextBox();
            inpUsrName = new TextBox();
            inpUsrPassword = new TextBox();
            SuspendLayout();
            // 
            // lblDbAddress
            // 
            lblDbAddress.AutoSize = true;
            lblDbAddress.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            lblDbAddress.Location = new Point(8, 5);
            lblDbAddress.Name = "lblDbAddress";
            lblDbAddress.Size = new Size(308, 35);
            lblDbAddress.TabIndex = 0;
            lblDbAddress.Text = "Adatbázis URL vagy IP cím";
            // 
            // lblDbName
            // 
            lblDbName.AutoSize = true;
            lblDbName.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            lblDbName.Location = new Point(8, 87);
            lblDbName.Name = "lblDbName";
            lblDbName.Size = new Size(182, 35);
            lblDbName.TabIndex = 1;
            lblDbName.Text = "Adatbázis neve";
            // 
            // lblUsrName
            // 
            lblUsrName.AutoSize = true;
            lblUsrName.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            lblUsrName.Location = new Point(8, 169);
            lblUsrName.Name = "lblUsrName";
            lblUsrName.Size = new Size(384, 35);
            lblUsrName.TabIndex = 2;
            lblUsrName.Text = "Adatbázis szintű felhasználó neve";
            // 
            // lblUsrPassword
            // 
            lblUsrPassword.AutoSize = true;
            lblUsrPassword.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            lblUsrPassword.Location = new Point(8, 251);
            lblUsrPassword.Name = "lblUsrPassword";
            lblUsrPassword.Size = new Size(417, 35);
            lblUsrPassword.TabIndex = 3;
            lblUsrPassword.Text = "Adatbázis szintű felhasználó jelszava";
            // 
            // inpDbAddress
            // 
            inpDbAddress.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            inpDbAddress.Location = new Point(8, 43);
            inpDbAddress.Name = "inpDbAddress";
            inpDbAddress.Size = new Size(642, 41);
            inpDbAddress.TabIndex = 4;
            inpDbAddress.Leave += Inp_Leave;
            // 
            // inpDbName
            // 
            inpDbName.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            inpDbName.Location = new Point(8, 125);
            inpDbName.Name = "inpDbName";
            inpDbName.Size = new Size(642, 41);
            inpDbName.TabIndex = 5;
            inpDbName.Leave += Inp_Leave;
            // 
            // inpUsrName
            // 
            inpUsrName.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            inpUsrName.Location = new Point(8, 207);
            inpUsrName.Name = "inpUsrName";
            inpUsrName.Size = new Size(642, 41);
            inpUsrName.TabIndex = 6;
            inpUsrName.Leave += Inp_Leave;
            // 
            // inpUsrPassword
            // 
            inpUsrPassword.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            inpUsrPassword.Location = new Point(8, 289);
            inpUsrPassword.Name = "inpUsrPassword";
            inpUsrPassword.Size = new Size(642, 41);
            inpUsrPassword.TabIndex = 7;
            inpUsrPassword.Leave += Inp_Leave;
            // 
            // SettingsView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(inpUsrPassword);
            Controls.Add(inpUsrName);
            Controls.Add(inpDbName);
            Controls.Add(inpDbAddress);
            Controls.Add(lblUsrPassword);
            Controls.Add(lblUsrName);
            Controls.Add(lblDbName);
            Controls.Add(lblDbAddress);
            Name = "SettingsView";
            Padding = new Padding(5);
            Size = new Size(658, 340);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblDbAddress;
        private Label lblDbName;
        private Label lblUsrName;
        private Label lblUsrPassword;
        private TextBox inpDbAddress;
        private TextBox inpDbName;
        private TextBox inpUsrName;
        private TextBox inpUsrPassword;
    }
}
