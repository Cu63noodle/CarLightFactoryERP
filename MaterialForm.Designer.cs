namespace CarLightFactoryERP
{
    partial class MaterialForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMaterialCode = new System.Windows.Forms.TextBox();
            this.txtMaterialName = new System.Windows.Forms.TextBox();
            this.txtUnit = new System.Windows.Forms.TextBox();
            this.txtSafetyStock = new System.Windows.Forms.TextBox();
            this.btnLoadMaterial = new System.Windows.Forms.Button();
            this.btnAddMaterial = new System.Windows.Forms.Button();
            this.btnUpdateMaterial = new System.Windows.Forms.Button();
            this.dgvMaterial = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbDefaultWarehouse = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaterial)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "物料編號";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "物料名稱";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "單位";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 171);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "安全庫存";
            // 
            // txtMaterialCode
            // 
            this.txtMaterialCode.Location = new System.Drawing.Point(138, 34);
            this.txtMaterialCode.Name = "txtMaterialCode";
            this.txtMaterialCode.Size = new System.Drawing.Size(100, 22);
            this.txtMaterialCode.TabIndex = 4;
            // 
            // txtMaterialName
            // 
            this.txtMaterialName.Location = new System.Drawing.Point(138, 73);
            this.txtMaterialName.Name = "txtMaterialName";
            this.txtMaterialName.Size = new System.Drawing.Size(100, 22);
            this.txtMaterialName.TabIndex = 5;
            // 
            // txtUnit
            // 
            this.txtUnit.Location = new System.Drawing.Point(138, 118);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.Size = new System.Drawing.Size(100, 22);
            this.txtUnit.TabIndex = 6;
            // 
            // txtSafetyStock
            // 
            this.txtSafetyStock.Location = new System.Drawing.Point(138, 161);
            this.txtSafetyStock.Name = "txtSafetyStock";
            this.txtSafetyStock.Size = new System.Drawing.Size(100, 22);
            this.txtSafetyStock.TabIndex = 7;
            // 
            // btnLoadMaterial
            // 
            this.btnLoadMaterial.Location = new System.Drawing.Point(61, 265);
            this.btnLoadMaterial.Name = "btnLoadMaterial";
            this.btnLoadMaterial.Size = new System.Drawing.Size(75, 23);
            this.btnLoadMaterial.TabIndex = 8;
            this.btnLoadMaterial.Text = "載入物料";
            this.btnLoadMaterial.UseVisualStyleBackColor = true;
            this.btnLoadMaterial.Click += new System.EventHandler(this.btnLoadMaterial_Click);
            // 
            // btnAddMaterial
            // 
            this.btnAddMaterial.Location = new System.Drawing.Point(61, 303);
            this.btnAddMaterial.Name = "btnAddMaterial";
            this.btnAddMaterial.Size = new System.Drawing.Size(75, 23);
            this.btnAddMaterial.TabIndex = 9;
            this.btnAddMaterial.Text = "新增物料";
            this.btnAddMaterial.UseVisualStyleBackColor = true;
            this.btnAddMaterial.Click += new System.EventHandler(this.btnAddMaterial_Click);
            // 
            // btnUpdateMaterial
            // 
            this.btnUpdateMaterial.Location = new System.Drawing.Point(61, 344);
            this.btnUpdateMaterial.Name = "btnUpdateMaterial";
            this.btnUpdateMaterial.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateMaterial.TabIndex = 10;
            this.btnUpdateMaterial.Text = "修改物料";
            this.btnUpdateMaterial.UseVisualStyleBackColor = true;
            this.btnUpdateMaterial.Click += new System.EventHandler(this.btnUpdatedMaterial_Click);
            // 
            // dgvMaterial
            // 
            this.dgvMaterial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMaterial.Location = new System.Drawing.Point(257, 34);
            this.dgvMaterial.Name = "dgvMaterial";
            this.dgvMaterial.RowTemplate.Height = 24;
            this.dgvMaterial.Size = new System.Drawing.Size(531, 333);
            this.dgvMaterial.TabIndex = 11;
            this.dgvMaterial.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMaterial_CellClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 210);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "預設倉庫";
            // 
            // cmbDefaultWarehouse
            // 
            this.cmbDefaultWarehouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDefaultWarehouse.FormattingEnabled = true;
            this.cmbDefaultWarehouse.Location = new System.Drawing.Point(130, 202);
            this.cmbDefaultWarehouse.Name = "cmbDefaultWarehouse";
            this.cmbDefaultWarehouse.Size = new System.Drawing.Size(121, 20);
            this.cmbDefaultWarehouse.TabIndex = 13;
            // 
            // MaterialForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cmbDefaultWarehouse);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dgvMaterial);
            this.Controls.Add(this.btnUpdateMaterial);
            this.Controls.Add(this.btnAddMaterial);
            this.Controls.Add(this.btnLoadMaterial);
            this.Controls.Add(this.txtSafetyStock);
            this.Controls.Add(this.txtUnit);
            this.Controls.Add(this.txtMaterialName);
            this.Controls.Add(this.txtMaterialCode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "MaterialForm";
            this.Text = "MaterialForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaterial)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMaterialCode;
        private System.Windows.Forms.TextBox txtMaterialName;
        private System.Windows.Forms.TextBox txtUnit;
        private System.Windows.Forms.TextBox txtSafetyStock;
        private System.Windows.Forms.Button btnLoadMaterial;
        private System.Windows.Forms.Button btnAddMaterial;
        private System.Windows.Forms.Button btnUpdateMaterial;
        private System.Windows.Forms.DataGridView dgvMaterial;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbDefaultWarehouse;
    }
}