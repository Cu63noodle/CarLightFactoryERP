using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarLightFactoryERP
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnMaterial_Click(object sender, EventArgs e)
        {
            MaterialForm form = new MaterialForm();
            form.Show();
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            SupplierForm form = new SupplierForm();
            form.Show();
        }

        private void btnPurchase_Click(object sender, EventArgs e)
        {
            PurchaseForm form = new PurchaseForm();
            form.Show();
        }

        private void btnReceiving_Click(object sender, EventArgs e)
        {
            ReceivingForm form = new ReceivingForm();
            form.Show();
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            InventoryForm form = new InventoryForm();
            form.Show();
        }
    }
}
