using ZazaGsm.Properties;

namespace ZazaGsm.View
{
    partial class NavigationView
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
            components = new System.ComponentModel.Container();
            BtnSettings = new Button();
            BtnCustomers = new Button();
            BtnTasks = new Button();
            BtnDevices = new Button();
            BtnInvoices = new Button();
            ToolTip = new ToolTip(components);
            SuspendLayout();
            // 
            // BtnSettings
            // 
            BtnSettings.BackgroundImage = Resources.settings;
            BtnSettings.BackgroundImageLayout = ImageLayout.Stretch;
            BtnSettings.Location = new Point(8, 8);
            BtnSettings.Name = "BtnSettings";
            BtnSettings.Size = new Size(86, 86);
            BtnSettings.TabIndex = 0;
            BtnSettings.UseVisualStyleBackColor = true;
            BtnSettings.Click += NavButtonClick;
            BtnSettings.MouseEnter += OnMouseEnter;
            BtnSettings.MouseLeave += OnMouseLeave;
            // 
            // BtnCustomers
            // 
            BtnCustomers.BackgroundImage = Resources.user;
            BtnCustomers.BackgroundImageLayout = ImageLayout.Stretch;
            BtnCustomers.Location = new Point(100, 8);
            BtnCustomers.Name = "BtnCustomers";
            BtnCustomers.Size = new Size(86, 86);
            BtnCustomers.TabIndex = 1;
            BtnCustomers.UseVisualStyleBackColor = true;
            BtnCustomers.Click += NavButtonClick;
            BtnCustomers.MouseEnter += OnMouseEnter;
            BtnCustomers.MouseLeave += OnMouseLeave;
            // 
            // BtnTasks
            // 
            BtnTasks.BackgroundImage = Resources.task;
            BtnTasks.BackgroundImageLayout = ImageLayout.Stretch;
            BtnTasks.Location = new Point(192, 8);
            BtnTasks.Name = "BtnTasks";
            BtnTasks.Size = new Size(86, 86);
            BtnTasks.TabIndex = 2;
            BtnTasks.UseVisualStyleBackColor = true;
            BtnTasks.Click += NavButtonClick;
            BtnTasks.MouseEnter += OnMouseEnter;
            BtnTasks.MouseLeave += OnMouseLeave;
            // 
            // BtnDevices
            // 
            BtnDevices.BackgroundImage = Resources.device;
            BtnDevices.BackgroundImageLayout = ImageLayout.Stretch;
            BtnDevices.Location = new Point(284, 8);
            BtnDevices.Name = "BtnDevices";
            BtnDevices.Size = new Size(86, 86);
            BtnDevices.TabIndex = 3;
            BtnDevices.UseVisualStyleBackColor = true;
            BtnDevices.Click += NavButtonClick;
            BtnDevices.MouseEnter += OnMouseEnter;
            BtnDevices.MouseLeave += OnMouseLeave;
            // 
            // BtnInvoices
            // 
            BtnInvoices.BackgroundImage = Resources.invoice;
            BtnInvoices.BackgroundImageLayout = ImageLayout.Stretch;
            BtnInvoices.Location = new Point(376, 8);
            BtnInvoices.Name = "BtnInvoices";
            BtnInvoices.Size = new Size(86, 86);
            BtnInvoices.TabIndex = 4;
            BtnInvoices.UseVisualStyleBackColor = true;
            BtnInvoices.Click += NavButtonClick;
            BtnInvoices.MouseEnter += OnMouseEnter;
            BtnInvoices.MouseLeave += OnMouseLeave;
            // 
            // NavigationView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(BtnInvoices);
            Controls.Add(BtnDevices);
            Controls.Add(BtnTasks);
            Controls.Add(BtnCustomers);
            Controls.Add(BtnSettings);
            Name = "NavigationView";
            Padding = new Padding(5);
            Size = new Size(470, 102);
            ResumeLayout(false);
        }

        #endregion

        private Button BtnSettings;
        private Button BtnCustomers;
        private Button BtnTasks;
        private Button BtnDevices;
        private Button BtnInvoices;
        private ToolTip ToolTip;
    }
}
