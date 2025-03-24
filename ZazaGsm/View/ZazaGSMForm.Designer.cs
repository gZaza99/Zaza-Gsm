namespace ZazaGsm
{
    partial class ZazaGSMForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZazaGSMForm));
            navPanel = new Panel();
            navigationPanel = new ZazaGsm.View.NavigationView();
            btnReload = new Button();
            mainPanel = new Panel();
            PanelMessage = new Panel();
            MessageBar1 = new ZazaGsm.View.MessageBar();
            ToolTip = new ToolTip(components);
            navPanel.SuspendLayout();
            mainPanel.SuspendLayout();
            PanelMessage.SuspendLayout();
            SuspendLayout();
            // 
            // navPanel
            // 
            navPanel.Controls.Add(navigationPanel);
            navPanel.Controls.Add(btnReload);
            navPanel.Dock = DockStyle.Bottom;
            navPanel.Location = new Point(0, 631);
            navPanel.Name = "navPanel";
            navPanel.Padding = new Padding(10);
            navPanel.Size = new Size(754, 112);
            navPanel.TabIndex = 0;
            // 
            // navigationPanel
            // 
            navigationPanel.Location = new Point(143, 0);
            navigationPanel.Name = "navigationPanel";
            navigationPanel.Padding = new Padding(5);
            navigationPanel.Size = new Size(469, 101);
            navigationPanel.TabIndex = 1;
            // 
            // btnReload
            // 
            btnReload.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnReload.BackgroundImage = (Image)resources.GetObject("btnReload.BackgroundImage");
            btnReload.BackgroundImageLayout = ImageLayout.Zoom;
            btnReload.Location = new Point(656, 8);
            btnReload.Name = "btnReload";
            btnReload.Size = new Size(86, 86);
            btnReload.TabIndex = 0;
            btnReload.UseVisualStyleBackColor = true;
            btnReload.Click += BtnReload_Click;
            btnReload.MouseEnter += BtnReload_MouseEnter;
            btnReload.MouseLeave += BtnReload_MouseLeave;
            // 
            // mainPanel
            // 
            mainPanel.Controls.Add(PanelMessage);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 0);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(754, 631);
            mainPanel.TabIndex = 1;
            // 
            // PanelMessage
            // 
            PanelMessage.Controls.Add(MessageBar1);
            PanelMessage.Dock = DockStyle.Top;
            PanelMessage.Location = new Point(0, 0);
            PanelMessage.Name = "PanelMessage";
            PanelMessage.Size = new Size(754, 33);
            PanelMessage.TabIndex = 0;
            PanelMessage.Visible = false;
            // 
            // MessageBar1
            // 
            MessageBar1.BackColor = SystemColors.ActiveCaption;
            MessageBar1.Dock = DockStyle.Top;
            MessageBar1.Location = new Point(0, 0);
            MessageBar1.Name = "MessageBar1";
            MessageBar1.Size = new Size(754, 33);
            MessageBar1.TabIndex = 0;
            // 
            // ZazaGSMForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(754, 743);
            Controls.Add(mainPanel);
            Controls.Add(navPanel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(772, 790);
            Name = "ZazaGSMForm";
            Text = "Zaza GSM";
            WindowState = FormWindowState.Maximized;
            Resize += OnResize;
            navPanel.ResumeLayout(false);
            mainPanel.ResumeLayout(false);
            PanelMessage.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel navPanel;
        private Panel mainPanel;
        private Button btnReload;
        private ToolTip ToolTip;
        private Panel PanelMessage;
        private View.MessageBar MessageBar1;
        private View.NavigationView navigationPanel;
    }
}