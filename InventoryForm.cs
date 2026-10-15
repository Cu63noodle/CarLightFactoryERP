using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarLightFactoryERP
{
    public partial class InventoryForm : Form
    {
        private string connectionString =
                "Data Source = (local);" + "Initial Catalog = 車燈工廠;" +
                "Integrated Security = True;" + "TrustServerCertificate = True;";

        public InventoryForm()
        {
            InitializeComponent();

            dgvInventory.ReadOnly = true;
            dgvInventory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInventory.MultiSelect = false;
            dgvInventory.AllowUserToAddRows = false;
        }

        private void LoadCurrentInventory()
        {
            string sql = @" 
                        SELECT
                            倉庫編號,
                            倉庫名稱,
                            物料編號,
                            物料名稱,
                            目前庫存,
                            安全庫存,
                            庫存狀態
                        FROM dbo.vw_庫存狀態
                        ORDER BY 倉庫編號, 物料編號;
                        ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);

                DataTable table = new DataTable();

                adapter.Fill(table);

                dgvInventory.DataSource = table;
            }
        }

        private void btnCurrentInventory_Click(object sender, EventArgs e)
        {
            LoadCurrentInventory();
        }

        private void LoadLowStock()
        {
            string sql = @"SELECT
                            倉庫編號,
	                        倉庫名稱,
	                        物料編號,
	                        物料名稱,
	                        目前庫存,
	                        安全庫存,
	                        庫存狀態
                            FROM dbo.vw_庫存狀態
                            WHERE 庫存狀態 = N'低庫存'
                            ORDER BY 倉庫編號, 物料編號;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);

                DataTable table = new DataTable();

                adapter.Fill(table);

                dgvInventory.DataSource = table;
            }
        }

        private void btnLowStock_Click(object sender, EventArgs e)
        {
            LoadLowStock();
        }

        private void LoadStockTransactions()
        {
            string sql = @"
                            SELECT
	                            ST.異動時間,
	                            W.倉庫編號,
	                            W.倉庫名稱,
	                            M.物料編號,
	                            M.物料名稱,
	                            ST.異動類型,
	                            ST.數量,
	                            ST.參考編號
                                FROM dbo.庫存異動 AS ST
                                INNER JOIN dbo.倉庫 AS W
	                                ON ST.倉庫ID = W.倉庫ID
                                INNER JOIN dbo.物料 AS M
	                                ON ST.物料ID = M.物料ID
                                ORDER BY ST.異動時間 DESC;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);

                DataTable table = new DataTable();

                adapter.Fill(table);

                dgvInventory.DataSource = table;
            }
        }

        private void btnStockTransaction_Click(object sender, EventArgs e)
        {
            LoadStockTransactions();
        }
    }
}
