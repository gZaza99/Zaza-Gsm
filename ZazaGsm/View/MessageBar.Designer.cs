namespace ZazaGsm.View
{
    partial class MessageBar
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
            LblMessage = new Label();
            BtnClose = new Button();
            SuspendLayout();
            // 
            // LblMessage
            // 
            LblMessage.AutoSize = true;
            LblMessage.ForeColor = Color.White;
            LblMessage.Location = new Point(3, 6);
            LblMessage.Name = "LblMessage";
            LblMessage.Size = new Size(67, 20);
            LblMessage.TabIndex = 4;
            LblMessage.Text = "Message";
            // 
            // BtnClose
            // 
            BtnClose.BackgroundImage = Properties.Resources.cross;
            BtnClose.BackgroundImageLayout = ImageLayout.Stretch;
            BtnClose.Cursor = Cursors.Hand;
            BtnClose.FlatStyle = FlatStyle.Flat;
            BtnClose.Location = new Point(117, 0);
            BtnClose.Name = "BtnClose";
            BtnClose.Size = new Size(33, 33);
            BtnClose.TabIndex = 3;
            BtnClose.UseVisualStyleBackColor = false;
            // 
            // MessageBar
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            Controls.Add(LblMessage);
            Controls.Add(BtnClose);
            Name = "MessageBar";
            Size = new Size(150, 33);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LblMessage;
        private Button BtnClose;
    }
}
