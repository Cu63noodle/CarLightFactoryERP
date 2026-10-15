namespace CarLightFactoryERP
{
    partial class InventoryForm
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
            this.btnCurrentInventory = new System.Windows.Forms.Button();
            this.btnLowStock = new System.Windows.Forms.Button();
            this.btnStockTransaction = new System.Windows.Forms.Button();
            this.dgvInventory = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCurrentInventory
            // 
            this.btnCurrentInventory.Location = new System.Drawing.Point(37, 32);
            this.btnCurrentInventory.Name = "btnCurrentInventory";
            this.btnCurrentInventory.Size = new System.Drawing.Size(75, 23);
            this.btnCurrentInventory.TabIndex = 0;
            this.btnCurrentInventory.Text = "現有庫存";
            this.btnCurrentInventory.UseVisualStyleBackColor = true;
            this.btnCurrentInventory.Click += new System.EventHandler(this.btnCurrentInventory_Click);
            // 
            // btnLowStock
            // 
            this.btnLowStock.Location = new System.Drawing.Point(151, 32);
            this.btnLowStock.Name = "btnLowStock";
            this.btnLowStock.Size = new System.Drawing.Size(75, 23);
            this.btnLowStock.TabIndex = 1;
            this.btnLowStock.Text = "低庫存";
            this.btnLowStock.UseVisualStyleBackColor = true;
            this.btnLowStock.Click += new System.EventHandler(this.btnLowStock_Click);
            // 
            // btnStockTransaction
            // 
            this.btnStockTransaction.Location = new System.Drawing.Point(270, 32);
            this.btnStockTransaction.Name = "btnStockTransaction";
            this.btnStockTransaction.Size = new System.Drawing.Size(75, 23);
            this.btnStockTransaction.TabIndex = 2;
            this.btnStockTransaction.Text = "庫存異動";
            this.btnStockTransaction.UseVisualStyleBackColor = true;
            this.btnStockTransaction.Click += new System.EventHandler(this.btnStockTransaction_Click);
            // 
            // dgvInventory
            // 
            this.dgvInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventory.Location = new System.Drawing.Point(12, 105);
            this.dgvInventory.Name = "dgvInventory";
            this.dgvInventory.RowTemplate.Height = 24;
            this.dgvInventory.Size = new System.Drawing.Size(776, 333);
            this.dgvInventory.TabIndex = 3;
            // 
            // InventoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvInventory);
            this.Controls.Add(this.btnStockTransaction);
            this.Controls.Add(this.btnLowStock);
            this.Controls.Add(this.btnCurrentInventory);
            this.Name = "InventoryForm";
            this.Text = "InventoryForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCurrentInventory;
        private System.Windows.Forms.Button btnLowStock;
        private System.Windows.Forms.Button btnStockTransaction;
        private System.Windows.Forms.DataGridView dgvInventory;
    }
}