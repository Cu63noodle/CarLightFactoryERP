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
    public partial class MaterialForm : Form
    {
        private string connectionString =
                "Data Source = (local);" + "Initial Catalog = 車燈工廠;" +
                "Integrated Security = True;" + "TrustServerCertificate = True;";

        //使用者目前選到哪一筆物料
        private int selectedMaterialId = 0;

        public MaterialForm()
        {
            InitializeComponent();

            dgvMaterial.ReadOnly = true;
            dgvMaterial.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMaterial.MultiSelect = false;
            dgvMaterial.AllowUserToAddRows = false;

            LoadWarehouseComboBox();
        }

        private void LoadMaterial()
        {

            // 使用sql指令從sqlserver中帶回結果
            string sql =
                @" SELECT 物料ID, 物料編號, 物料名稱, 單位, 安全庫存, 是否啟用, 建立時間 FROM dbo.物料";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //執行SELECT並將結果傳回C#
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                // 存放資料用的暫時資料表
                DataTable table = new DataTable();
                adapter.Fill(table);
                dgvMaterial.DataSource = table;

            }
        }

        private void btnLoadMaterial_Click(object sender, EventArgs e)
        {
            LoadMaterial();
            ClearMaterialInputs();
        }



        private void btnAddMaterial_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaterialCode.Text))
            {
                MessageBox.Show("請輸入物料編號");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMaterialName.Text))
            {
                MessageBox.Show("請輸入物料名稱");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtUnit.Text))
            {
                MessageBox.Show("請輸入單位");
                return;
            }

            if (!decimal.TryParse(txtSafetyStock.Text, out decimal safetyStock))
            {
                MessageBox.Show("安全庫存必須輸入數字");
                return;
            }

            if (safetyStock < 0)
            {
                MessageBox.Show("安全庫存不可小於 0");
                return;
            }

            if (cmbDefaultWarehouse.SelectedValue == null ||!int.TryParse(cmbDefaultWarehouse.SelectedValue.ToString(),out int warehouseId))
            {
                MessageBox.Show("請選擇預設倉庫。");
                return;
            }

            string materialSql = @"
                INSERT INTO dbo.物料
                (
                    物料編號,物料名稱,單位,安全庫存
                )
                VALUES
                (
                    @物料編號,@物料名稱,@單位,@安全庫存
                );
                SELECT CAST(SCOPE_IDENTITY() AS INT);
                ";

            // 新增存貨的 SQL（
            string inventorySql = @"
                                INSERT INTO dbo.存貨
                                (
                                    倉庫ID,物料ID,數量
                                )
                                VALUES
                                (
                                @倉庫ID,@物料ID,0
                                );";

            using (SqlConnection connection =new SqlConnection(connectionString))
            {
                connection.Open();

                SqlTransaction transaction =
                    connection.BeginTransaction();

                try
                {
                    int newMaterialId;

                    // 1. 建立物料
                    using (SqlCommand materialCommand =
                        new SqlCommand(
                            materialSql,
                            connection,
                            transaction))
                    {
                        materialCommand.Parameters.Add(
                            "@物料編號",
                            SqlDbType.VarChar,
                            30).Value =
                            txtMaterialCode.Text;

                        materialCommand.Parameters.Add(
                            "@物料名稱",
                            SqlDbType.NVarChar,
                            100).Value =
                            txtMaterialName.Text;

                        materialCommand.Parameters.Add(
                            "@單位",
                            SqlDbType.NVarChar,
                            10).Value =
                            txtUnit.Text;

                        SqlParameter safetyParameter =
                            materialCommand.Parameters.Add(
                                "@安全庫存",
                                SqlDbType.Decimal);

                        safetyParameter.Precision = 18;
                        safetyParameter.Scale = 3;
                        safetyParameter.Value = safetyStock;

                        newMaterialId =
                            Convert.ToInt32(
                                materialCommand.ExecuteScalar());
                    }

                    // 2. 建立初始存貨
                    using (SqlCommand inventoryCommand =
                        new SqlCommand(
                            inventorySql,
                            connection,
                            transaction))
                    {
                        inventoryCommand.Parameters.Add(
                            "@倉庫ID",
                            SqlDbType.Int).Value =
                            warehouseId;

                        inventoryCommand.Parameters.Add(
                            "@物料ID",
                            SqlDbType.Int).Value =
                            newMaterialId;

                        inventoryCommand.ExecuteNonQuery();
                    }

                    // 3. 兩邊都成功才保存
                    transaction.Commit();

                    MessageBox.Show(
                        "物料新增成功，並已建立初始庫存。");

                    LoadMaterial();
                    ClearMaterialInputs();
                }
                catch (SqlException ex)
                {
                    transaction.Rollback();

                    if (ex.Number == 2601 ||ex.Number == 2627)
                    {
                        MessageBox.Show(
                            "物料編號已存在，請輸入不同的物料編號。");
                    }
                    else
                    {
                        MessageBox.Show(
                            "新增失敗：\n" +
                            ex.Message);
                    }
                }
            }

        }

        private void btnUpdatedMaterial_Click(object sender, EventArgs e)
        {

            if (selectedMaterialId == 0)
            {
                MessageBox.Show("請先選擇要修改的物料");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMaterialCode.Text))
            {
                MessageBox.Show("請輸入物料編號");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMaterialName.Text))
            {
                MessageBox.Show("請輸入物料名稱");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtUnit.Text))
            {
                MessageBox.Show("請輸入單位");
                return;
            }

            if (!decimal.TryParse(txtSafetyStock.Text, out decimal safetyStock))
            {
                MessageBox.Show("安全庫存需輸入數字");
                return;
            }

            if (safetyStock < 0)
            {
                MessageBox.Show("安全庫存不可小於 0");
                return;
            }

            string sql = @"
                    UPDATE dbo.物料
                    SET
                        物料編號 = @物料編號,
                        物料名稱 = @物料名稱,
                        單位 = @單位,
                        安全庫存 = @安全庫存
                    WHERE 物料ID = @物料ID;
                    ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.Add("@物料編號", SqlDbType.VarChar, 30).Value = txtMaterialCode.Text;

                command.Parameters.Add("@物料名稱", SqlDbType.NVarChar, 100).Value = txtMaterialName.Text;

                command.Parameters.Add("@單位", SqlDbType.NVarChar, 10).Value = txtUnit.Text;

                SqlParameter safetyParameter = command.Parameters.Add("@安全庫存", SqlDbType.Decimal);

                safetyParameter.Precision = 18;
                safetyParameter.Scale = 3;
                safetyParameter.Value = safetyStock;

                command.Parameters.Add("@物料ID", SqlDbType.Int).Value = selectedMaterialId;

                try
                {
                    connection.Open();

                    //回傳受影響的筆數
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("物料修改成功！");

                        LoadMaterial();
                        ClearMaterialInputs();
                    }
                    else
                    {
                        MessageBox.Show("找不到要修改的物料。");
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(
                        "修改失敗：\n" + ex.Message);
                }
            }
        }

        private void LoadWarehouseComboBox()
        {
            string sql = @"
                            SELECT
	                            倉庫ID,
	                            倉庫編號,
	                            倉庫名稱
                                FROM dbo.倉庫
                                ORDER BY 倉庫ID
                        ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);

                DataTable table = new DataTable();

                adapter.Fill(table);

                cmbDefaultWarehouse.DataSource = table;

                cmbDefaultWarehouse.DisplayMember = "倉庫名稱";

                cmbDefaultWarehouse.ValueMember = "倉庫ID";
            }
        }

        private void dgvMaterial_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow row =
                dgvMaterial.Rows[e.RowIndex];

            selectedMaterialId =
                Convert.ToInt32(
                    row.Cells["物料ID"].Value);

            txtMaterialCode.Text =
                row.Cells["物料編號"].Value?.ToString();

            txtMaterialName.Text =
                row.Cells["物料名稱"].Value?.ToString();

            txtUnit.Text =
                row.Cells["單位"].Value?.ToString();

            txtSafetyStock.Text =
                row.Cells["安全庫存"].Value?.ToString();
        }

        private void ClearMaterialInputs()
        {
            txtMaterialCode.Clear();
            txtMaterialName.Clear();
            txtUnit.Clear();
            txtSafetyStock.Clear();

            selectedMaterialId = 0;
        }

    }
}
