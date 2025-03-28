﻿using ZazaGsm.Controller;
using ZazaGsm.Model;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ZazaGsm.Base;

namespace ZazaGsm.View
{
    public partial class DevicesView : UserControl
    {
        public CtrlDevice Controller { get; set; }

        public DevicesView()
        {
            InitializeComponent();
            Controller = new CtrlDevice();
            FilterView.ComboPropFilter.Items.AddRange(new string[5] { "Id", "Type", "Front image", "Back image", "Barcode" });
        }

        public void Clear()
        {
            if (Grid.InvokeRequired)
            {
                Grid.Invoke(Clear);
                return;
            }
            Grid.Rows.Clear();
            PictureBox.Image = null;
        }

        public void AddDevices(BaseDataStore<Device> devicesToAdd)
        {
            DataGridViewRow row;
            DataGridViewTextBoxCell cellType;
            DataGridViewTextBoxCell cellFrontImagePath;
            DataGridViewTextBoxCell cellBackImagePath;
            DataGridViewTextBoxCell cellBarcode;
            DeviceImage _deviceImage;
            for (int i = 0; i < devicesToAdd.Count; i++)
            {
                row = new DataGridViewRow();
                row.HeaderCell.Value = devicesToAdd[i].TableKey.Id.ToString();

                cellType = new DataGridViewTextBoxCell();
                cellType.Value = devicesToAdd[i].Type.ToString();
                row.Cells.Add(cellType);

                // Middle 2 columns are empty yet
                cellBarcode = new DataGridViewTextBoxCell();
                cellBarcode.Value = null;
                row.Cells.Add(cellBarcode);
                cellBarcode = new DataGridViewTextBoxCell();
                cellBarcode.Value = null;
                row.Cells.Add(cellBarcode);

                cellBarcode = new DataGridViewTextBoxCell();
                cellBarcode.Value = devicesToAdd[i].Barcode?.ToString();
                row.Cells.Add(cellBarcode);

                Grid.Invoke(() => Grid.Rows.Add(row));
            }
        }

        public void TryRefresh(bool forceRefresh = true)
        {
            if (forceRefresh)
                Controller.LoadData();
            Clear();
            AddDevices(Collection.DeviceDataStore);
        }

        private void BtnInvoices_Click(object sender, EventArgs e)
        {
            MessageBox.Show("A nyomtatás még nincs implementálva.");
        }

        private void Grid_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            /*int Id = Convert.ToInt32(Grid.Rows[e.RowIndex].HeaderCell.Value);
            Device device = Collection.DeviceDataStore.First(current => current.KeyIsSame(Id));
            if (device.Images.Count == 0)
                return;
            DeviceImage deviceImage = device.Images.Last();
            if (e.ColumnIndex != 2)
            {
                if (string.IsNullOrEmpty(deviceImage.FrontBefore))
                    return;
                PictureBox.Image = new Bitmap(deviceImage.FrontBefore);
            }
            else
            {
                if (string.IsNullOrEmpty(deviceImage.BackBefore))
                    return;
                PictureBox.Image = new Bitmap(deviceImage.BackBefore);
            }*/
        }
    }
}
