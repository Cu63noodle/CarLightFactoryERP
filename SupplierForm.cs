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
    public partial class SupplierForm : Form
    {
        private string connectionString =
                "Data Source = (local);" + "Initial Catalog = 車燈工廠;" +
                "Integrated Security = True;" + "TrustServerCertificate = True;";

        private int selectedSupplierId = 0;

        public SupplierForm()
        {
            InitializeComponent();

            dgvSupplier.ReadOnly = true;
            dgvSupplier.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSupplier.MultiSelect = false;
            dgvSupplier.AllowUserToAddRows = false;
        }

        private void LoadSupplier()
        {

            string sql = @"
                         SELECT
                            供應商ID,
                            供應商編號,
                            供應商名稱,
                            聯絡人,
                            電話,
                            電子郵件,
                            是否啟用,
                            建立時間 FROM dbo.供應商   
                            ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);

                DataTable table = new DataTable();

                adapter.Fill(table);

                dgvSupplier.DataSource = table;
            }
        }

        private void btnLoadSupplier_Click(object sender, EventArgs e)
        {
            LoadSupplier();
            ClearSupplierInputs();
        }

        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSupplierCode.Text))
            {
                MessageBox.Show("請輸入供應商編號。");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtSupplierName.Text))
            {
                MessageBox.Show("請輸入供應商名稱。");
                return;
            }

            string sql =
                @"
                  INSERT INTO dbo.供應商
                  (
                    供應商編號,
                    供應商名稱,
                    聯絡人,
                    電話
                  )
                  VALUES
                  (
                    @供應商編號,
                    @供應商名稱,
                    @聯絡人,
                    @電話
                  );
                ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.Add("@供應商編號", SqlDbType.VarChar, 20).Value = txtSupplierCode.Text;

                command.Parameters.Add("@供應商名稱", SqlDbType.NVarChar, 100).Value = txtSupplierName.Text;

                command.Parameters.Add("@聯絡人", SqlDbType.NVarChar, 50).Value = txtContactPerson.Text;

                command.Parameters.Add("@電話", SqlDbType.VarChar, 30).Value = txtPhone.Text;

                try
                {
                    connection.Open();

                    command.ExecuteNonQuery();

                    MessageBox.Show("供應商新增成功");

                    LoadSupplier();
                    ClearSupplierInputs();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("新增失敗: \n" + ex.Message);
                }
            }
        }

        private void btnUpdateSupplier_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSupplierCode.Text))
            {
                MessageBox.Show("請輸入供應商編號。");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtSupplierName.Text))
            {
                MessageBox.Show("請輸入供應商名稱。");
                return;
            }

            if (selectedSupplierId == 0)
            {
                MessageBox.Show("請先選擇要修改的供應商。");
                return;
            }

            string sql = @"
                            UPDATE dbo.供應商
                            SET
                                供應商編號 = @供應商編號,
                                供應商名稱 = @供應商名稱,
                                聯絡人 = @聯絡人,
                                電話 = @電話
                            WHERE 供應商ID = @供應商ID;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.Add(
                    "@供應商編號",
                    SqlDbType.VarChar,
                    20).Value = txtSupplierCode.Text;

                command.Parameters.Add(
                    "@供應商名稱",
                    SqlDbType.NVarChar,
                    100).Value = txtSupplierName.Text;

                command.Parameters.Add(
                    "@聯絡人",
                    SqlDbType.NVarChar,
                    50).Value = txtContactPerson.Text;

                command.Parameters.Add(
                    "@電話",
                    SqlDbType.VarChar,
                    30).Value = txtPhone.Text;

                command.Parameters.Add(
                    "@供應商ID",
                    SqlDbType.Int).Value = selectedSupplierId;

                try
                {
                    connection.Open();

                    int rowsAffected =
                        command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("供應商修改成功！");

                        LoadSupplier();
                        ClearSupplierInputs();
                    }
                    else
                    {
                        MessageBox.Show("找不到要修改的供應商。");
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(
                        "修改失敗：\n" + ex.Message);
                }
            }
        }

        private void dgvSupplier_CellClick(object sender,DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow row =
                dgvSupplier.Rows[e.RowIndex];

            selectedSupplierId =
                Convert.ToInt32(
                    row.Cells["供應商ID"].Value);

            txtSupplierCode.Text =
                row.Cells["供應商編號"].Value?.ToString();

            txtSupplierName.Text =
                row.Cells["供應商名稱"].Value?.ToString();

            txtContactPerson.Text =
                row.Cells["聯絡人"].Value?.ToString();

            txtPhone.Text =
                row.Cells["電話"].Value?.ToString();
        }

        private void ClearSupplierInputs()
        {
            txtSupplierCode.Clear();
            txtSupplierName.Clear();
            txtContactPerson.Clear();
            txtPhone.Clear();

            selectedSupplierId = 0;
        }
    }
}
