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
    public partial class PurchaseForm : Form
    {
        private string connectionString =
                "Data Source = (local);" + "Initial Catalog = 車燈工廠;" +
                "Integrated Security = True;" + "TrustServerCertificate = True;";

        private DataTable purchaseDetailTable = new DataTable();

        public PurchaseForm()
        {
            InitializeComponent();

            dgvPurchaseDetail.ReadOnly = true;
            dgvPurchaseDetail.AllowUserToAddRows = false;
            dgvPurchaseDetail.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            LoadSupplierComboBox();
            LoadMaterialComboBox();
            InitializePurchaseDetailTable();

            txtPurchaseOrderNo.ReadOnly = true;
            txtPurchaseOrderNo.Text = GeneratePurchaseOrderNo();
        }

        private string GeneratePurchaseOrderNo()
        {
            string prefix = "PO" + DateTime.Today.ToString("yyyyMMdd");

            string sql = @"
                            SELECT
	                            ISNULL( MAX( TRY_CONVERT(INT,RIGHT(採購訂單編號, 3))), 0 ) + 1
                            FROM dbo.採購訂單
                            WHERE 採購訂單編號 LIKE @Prefix + '%';";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.Add("@Prefix", SqlDbType.VarChar, 20).Value = prefix;
                connection.Open();
                int nextNumber = Convert.ToInt32(command.ExecuteScalar());
                return prefix + nextNumber.ToString("000");
            }
        }

        private void LoadSupplierComboBox()
        {
            string sql = @"
                            SELECT
                                供應商ID,
                                供應商名稱
                                FROM dbo.供應商
                                WHERE 是否啟用 = 1
                                ORDER BY 供應商ID;
                            ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);

                DataTable table = new DataTable();

                adapter.Fill(table);

                cmbSupplier.DataSource = table;

                cmbSupplier.DisplayMember = "供應商名稱";

                cmbSupplier.ValueMember = "供應商ID";
            }
        }

        private void LoadMaterialComboBox()
        {
            string sql = @"
                            SELECT
                                物料ID,
                                物料編號,
                                物料名稱
                                FROM dbo.物料
                                WHERE 是否啟用 = 1
                                ORDER BY 物料ID;
                            ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);

                DataTable table = new DataTable();

                adapter.Fill(table);

                cmbMaterial.DataSource = table;

                cmbMaterial.DisplayMember = "物料名稱";

                cmbMaterial.ValueMember = "物料ID";
            }
        }

        //建立暫時資料表
        private void InitializePurchaseDetailTable()
        {
            purchaseDetailTable.Columns.Add("項次", typeof(int));

            purchaseDetailTable.Columns.Add("物料ID", typeof(int));

            purchaseDetailTable.Columns.Add("物料編號", typeof(string));

            purchaseDetailTable.Columns.Add("物料名稱", typeof(string));

            purchaseDetailTable.Columns.Add("數量", typeof(decimal));

            purchaseDetailTable.Columns.Add("單價", typeof(decimal));

            purchaseDetailTable.Columns.Add("小計", typeof(decimal));

            dgvPurchaseDetail.DataSource = purchaseDetailTable;
        }

        private void btnAddPurchaseDetail_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtPurchaseQty.Text, out decimal quantity))
            {
                MessageBox.Show("請輸入數字");
                return;
            }
            if (!decimal.TryParse(txtUnitPrice.Text, out decimal unitPrice))
            {
                MessageBox.Show("請輸入數字");
                return;
            }
            if (quantity <= 0)
            {
                MessageBox.Show("數量必須大於 0");
                return;
            }
            if (unitPrice < 0)
            {
                MessageBox.Show("單價不可小於 0");
                return;
            }

            int materialId = Convert.ToInt32(cmbMaterial.SelectedValue);

            DataRowView selectedMaterial = (DataRowView)cmbMaterial.SelectedItem;

            string materialCode = selectedMaterial["物料編號"].ToString();

            string materialName = selectedMaterial["物料名稱"].ToString();

            int lineNo = purchaseDetailTable.Rows.Count + 1;

            decimal subtotal = quantity * unitPrice;

            purchaseDetailTable.Rows.Add(
                lineNo,
                materialId,
                materialCode,
                materialName,
                quantity,
                unitPrice,
                subtotal
                );
        }

        private int CreatePurchaseOrderHeader(SqlConnection connection, SqlTransaction transaction)
        {
            string sql = @"
                          INSERT INTO dbo.採購訂單(
                            採購訂單編號,
                            供應商ID,
                            訂單日期
                            )
                           VALUES(
                            @採購訂單編號,
                            @供應商ID,
                            @訂單日期
                            )
                            SELECT CAST(SCOPE_IDENTITY() AS INT);
                          ";
            using (SqlCommand command = new SqlCommand(sql, connection, transaction))
            {
                int supplierId = Convert.ToInt32(cmbSupplier.SelectedValue);

                command.Parameters.Add("@採購訂單編號", SqlDbType.VarChar, 30).Value = txtPurchaseOrderNo.Text;

                command.Parameters.Add("@供應商ID", SqlDbType.Int).Value = supplierId;

                command.Parameters.Add("@訂單日期", SqlDbType.Date).Value = dtpOrderDate.Value.Date;

                int purchaseOrderId = Convert.ToInt32(command.ExecuteScalar());

                return purchaseOrderId;
            }
        }

        private void btnCreatePurchaseOrder_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPurchaseOrderNo.Text))
            {
                MessageBox.Show("請輸入採購訂單編號");
                return;
            }
            if (purchaseDetailTable.Rows.Count == 0)
            {
                MessageBox.Show("請至少加入一筆採購明細");
                return;
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    //1. 建立 header,拿回新id
                    int purchaseOrderId = CreatePurchaseOrderHeader(connection, transaction);
                    //2. 寫入全部 Detail
                    InsertPurchaseOrderDetails(connection, transaction, purchaseOrderId);
                    //3. 全部成功才正式保存
                    transaction.Commit();

                    MessageBox.Show("採購訂單建立成功 \n" + "採購訂單ID = " + purchaseOrderId);

                    purchaseDetailTable.Clear();
                    txtPurchaseOrderNo.Clear();
                    txtPurchaseQty.Clear();
                    txtUnitPrice.Clear();
                    txtPurchaseOrderNo.Text = GeneratePurchaseOrderNo();
                }
                catch (SqlException ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("建立採購訂單失敗 \n" + ex.Message);
                }
            }
        }

        //把佔存DataTable寫進採購訂單明細
        private void InsertPurchaseOrderDetails(
            SqlConnection connection, SqlTransaction transaction, int purchaseOrderId)
        {
            string sql = @"
                            INSERT INTO dbo.採購訂單明細
                            (
                                採購訂單ID,
                                項次,
                                物料ID,
                                數量,
                                單價
                            )
                            VALUES
                            (
                                @採購訂單ID,
                                @項次,
                                @物料ID,
                                @數量,
                                @單價
                            );";
            foreach (DataRow row in purchaseDetailTable.Rows)
            {
                using (SqlCommand command = new SqlCommand(sql, connection, transaction))
                {
                    command.Parameters.Add("@採購訂單ID", SqlDbType.Int).Value = purchaseOrderId;

                    command.Parameters.Add("@項次", SqlDbType.Int).Value = Convert.ToInt32(row["項次"]);

                    command.Parameters.Add("@物料ID", SqlDbType.Int).Value = Convert.ToInt32(row["物料ID"]);

                    SqlParameter quantityParameter = command.Parameters.Add("@數量", SqlDbType.Decimal);

                    quantityParameter.Precision = 18;
                    quantityParameter.Scale = 3;
                    quantityParameter.Value = Convert.ToDecimal(row["數量"]);

                    SqlParameter priceParameter = command.Parameters.Add("@單價", SqlDbType.Decimal);

                    priceParameter.Precision = 18;
                    priceParameter.Scale = 2;
                    priceParameter.Value = Convert.ToDecimal(row["單價"]);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
