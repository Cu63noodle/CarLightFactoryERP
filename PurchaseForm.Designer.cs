namespace CarLightFactoryERP
{
    partial class PurchaseForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtPurchaseOrderNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbSupplier = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpOrderDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbMaterial = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPurchaseQty = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtUnitPrice = new System.Windows.Forms.TextBox();
            this.btnAddPurchaseDetail = new System.Windows.Forms.Button();
            this.dgvPurchaseDetail = new System.Windows.Forms.DataGridView();
            this.btnCreatePurchaseOrder = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchaseDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "採購訂單編號";
            // 
            // txtPurchaseOrderNo
            // 
            this.txtPurchaseOrderNo.Location = new System.Drawing.Point(122, 20);
            this.txtPurchaseOrderNo.Name = "txtPurchaseOrderNo";
            this.txtPurchaseOrderNo.Size = new System.Drawing.Size(100, 22);
            this.txtPurchaseOrderNo.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "供應商";
            // 
            // cmbSupplier
            // 
            this.cmbSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSupplier.FormattingEnabled = true;
            this.cmbSupplier.Location = new System.Drawing.Point(122, 63);
            this.cmbSupplier.Name = "cmbSupplier";
            this.cmbSupplier.Size = new System.Drawing.Size(121, 20);
            this.cmbSupplier.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "訂單日期";
            // 
            // dtpOrderDate
            // 
            this.dtpOrderDate.Location = new System.Drawing.Point(122, 100);
            this.dtpOrderDate.Name = "dtpOrderDate";
            this.dtpOrderDate.Size = new System.Drawing.Size(200, 22);
            this.dtpOrderDate.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "物料";
            // 
            // cmbMaterial
            // 
            this.cmbMaterial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMaterial.FormattingEnabled = true;
            this.cmbMaterial.Location = new System.Drawing.Point(122, 141);
            this.cmbMaterial.Name = "cmbMaterial";
            this.cmbMaterial.Size = new System.Drawing.Size(121, 20);
            this.cmbMaterial.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 186);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "數量";
            // 
            // txtPurchaseQty
            // 
            this.txtPurchaseQty.Location = new System.Drawing.Point(122, 176);
            this.txtPurchaseQty.Name = "txtPurchaseQty";
            this.txtPurchaseQty.Size = new System.Drawing.Size(100, 22);
            this.txtPurchaseQty.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 228);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "單價";
            // 
            // txtUnitPrice
            // 
            this.txtUnitPrice.Location = new System.Drawing.Point(122, 218);
            this.txtUnitPrice.Name = "txtUnitPrice";
            this.txtUnitPrice.Size = new System.Drawing.Size(100, 22);
            this.txtUnitPrice.TabIndex = 11;
            // 
            // btnAddPurchaseDetail
            // 
            this.btnAddPurchaseDetail.Location = new System.Drawing.Point(49, 273);
            this.btnAddPurchaseDetail.Name = "btnAddPurchaseDetail";
            this.btnAddPurchaseDetail.Size = new System.Drawing.Size(75, 23);
            this.btnAddPurchaseDetail.TabIndex = 12;
            this.btnAddPurchaseDetail.Text = "加入明細";
            this.btnAddPurchaseDetail.UseVisualStyleBackColor = true;
            this.btnAddPurchaseDetail.Click += new System.EventHandler(this.btnAddPurchaseDetail_Click);
            // 
            // dgvPurchaseDetail
            // 
            this.dgvPurchaseDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPurchaseDetail.Location = new System.Drawing.Point(341, 20);
            this.dgvPurchaseDetail.Name = "dgvPurchaseDetail";
            this.dgvPurchaseDetail.RowTemplate.Height = 24;
            this.dgvPurchaseDetail.Size = new System.Drawing.Size(531, 333);
            this.dgvPurchaseDetail.TabIndex = 13;
            // 
            // btnCreatePurchaseOrder
            // 
            this.btnCreatePurchaseOrder.Location = new System.Drawing.Point(49, 318);
            this.btnCreatePurchaseOrder.Name = "btnCreatePurchaseOrder";
            this.btnCreatePurchaseOrder.Size = new System.Drawing.Size(90, 23);
            this.btnCreatePurchaseOrder.TabIndex = 14;
            this.btnCreatePurchaseOrder.Text = "建立採購訂單";
            this.btnCreatePurchaseOrder.UseVisualStyleBackColor = true;
            this.btnCreatePurchaseOrder.Click += new System.EventHandler(this.btnCreatePurchaseOrder_Click);
            // 
            // PurchaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 450);
            this.Controls.Add(this.btnCreatePurchaseOrder);
            this.Controls.Add(this.dgvPurchaseDetail);
            this.Controls.Add(this.btnAddPurchaseDetail);
            this.Controls.Add(this.txtUnitPrice);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtPurchaseQty);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbMaterial);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpOrderDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbSupplier);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPurchaseOrderNo);
            this.Controls.Add(this.label1);
            this.Name = "PurchaseForm";
            this.Text = "PurchaseForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchaseDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPurchaseOrderNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbSupplier;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpOrderDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbMaterial;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPurchaseQty;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtUnitPrice;
        private System.Windows.Forms.Button btnAddPurchaseDetail;
        private System.Windows.Forms.DataGridView dgvPurchaseDetail;
        private System.Windows.Forms.Button btnCreatePurchaseOrder;
    }
}