using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace CarLightFactoryERP
{
    public partial class ReceivingForm : Form
    {
        private string connectionString =
                "Data Source = (local);" + "Initial Catalog = 車燈工廠;" +
                "Integrated Security = True;" + "TrustServerCertificate = True;";

        public ReceivingForm()
        {
            InitializeComponent();

            LoadPendingPurchaseOrders();

            dgvReceivingDetail.ReadOnly = true;
            dgvReceivingDetail.AllowUserToAddRows = false;
        }

        private void LoadPendingPurchaseOrders()
        {
            string sql =
                @"
                    SELECT
                        採購訂單ID,
                        採購訂單編號
                    FROM dbo.採購訂單
                    WHERE 狀態 = N'待入庫'
                    ORDER BY 採購訂單ID;
                ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);

                DataTable table = new DataTable();

                adapter.Fill(table);

                cmbPendingPurchaseOrder.DisplayMember = "採購訂單編號";

                cmbPendingPurchaseOrder.ValueMember = "採購訂單ID";

                cmbPendingPurchaseOrder.DataSource = table;
            }

            if(cmbPendingPurchaseOrder.Items.Count == 0)
            {
                dgvReceivingDetail.DataSource = null;
            }
        }

        private void LoadPendingPurchaseOrderDetail()
        {
            if (cmbPendingPurchaseOrder.SelectedValue == null)
            {
                return;
            }
            int purchaseOrderId = Convert.ToInt32(cmbPendingPurchaseOrder.SelectedValue);

            string sql = @"
                            SELECT 
                                PD.項次,
                                M.物料編號,
                                M.物料名稱,
                                PD.數量,
                                PD.單價
                            FROM dbo.採購訂單明細 AS PD
                            INNER JOIN dbo.物料 AS M
                                ON PD.物料ID = M.物料ID
                            WHERE PD.採購訂單ID = @採購訂單ID
                            ORDER BY PD.項次;
                            ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);

                adapter.SelectCommand.Parameters.Add("@採購訂單ID",SqlDbType.Int).Value = purchaseOrderId;

                DataTable table = new DataTable();

                adapter.Fill(table);

                dgvReceivingDetail.DataSource = table;
            }
        }

        private void cmbPendingPurchaseOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadPendingPurchaseOrderDetail();
        }

        private void btnReceivePurchaseOrder_Click(object sender, EventArgs e)
        {
            if (cmbPendingPurchaseOrder.SelectedValue == null)
            {
                MessageBox.Show("請選擇待入庫採購訂單");
                return;
            }

            int purchaseOrderId = Convert.ToInt32(cmbPendingPurchaseOrder.SelectedValue);

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("dbo.usp_採購入庫", connection))
            {
                // 執行預存程序
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@採購訂單ID", SqlDbType.Int).Value = purchaseOrderId;

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("採購入庫成功");
                    LoadPendingPurchaseOrders();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("採購入庫失敗" + ex.Message);
                }
            }
        }
    }
}
