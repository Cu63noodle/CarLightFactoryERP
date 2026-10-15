namespace CarLightFactoryERP
{
    partial class MainForm
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
            this.btnMaterial = new System.Windows.Forms.Button();
            this.btnSupplier = new System.Windows.Forms.Button();
            this.btnPurchase = new System.Windows.Forms.Button();
            this.btnReceiving = new System.Windows.Forms.Button();
            this.btnInventory = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "車燈工廠ERP";
            // 
            // btnMaterial
            // 
            this.btnMaterial.Location = new System.Drawing.Point(27, 57);
            this.btnMaterial.Name = "btnMaterial";
            this.btnMaterial.Size = new System.Drawing.Size(75, 23);
            this.btnMaterial.TabIndex = 1;
            this.btnMaterial.Text = "物料管理";
            this.btnMaterial.UseVisualStyleBackColor = true;
            this.btnMaterial.Click += new System.EventHandler(this.btnMaterial_Click);
            // 
            // btnSupplier
            // 
            this.btnSupplier.Location = new System.Drawing.Point(27, 103);
            this.btnSupplier.Name = "btnSupplier";
            this.btnSupplier.Size = new System.Drawing.Size(75, 23);
            this.btnSupplier.TabIndex = 2;
            this.btnSupplier.Text = "供應商管理";
            this.btnSupplier.UseVisualStyleBackColor = true;
            this.btnSupplier.Click += new System.EventHandler(this.btnSupplier_Click);
            // 
            // btnPurchase
            // 
            this.btnPurchase.Location = new System.Drawing.Point(27, 150);
            this.btnPurchase.Name = "btnPurchase";
            this.btnPurchase.Size = new System.Drawing.Size(75, 23);
            this.btnPurchase.TabIndex = 3;
            this.btnPurchase.Text = "採購管理";
            this.btnPurchase.UseVisualStyleBackColor = true;
            this.btnPurchase.Click += new System.EventHandler(this.btnPurchase_Click);
            // 
            // btnReceiving
            // 
            this.btnReceiving.Location = new System.Drawing.Point(27, 199);
            this.btnReceiving.Name = "btnReceiving";
            this.btnReceiving.Size = new System.Drawing.Size(75, 23);
            this.btnReceiving.TabIndex = 4;
            this.btnReceiving.Text = "入庫管理";
            this.btnReceiving.UseVisualStyleBackColor = true;
            this.btnReceiving.Click += new System.EventHandler(this.btnReceiving_Click);
            // 
            // btnInventory
            // 
            this.btnInventory.Location = new System.Drawing.Point(27, 249);
            this.btnInventory.Name = "btnInventory";
            this.btnInventory.Size = new System.Drawing.Size(75, 23);
            this.btnInventory.TabIndex = 5;
            this.btnInventory.Text = "庫存查詢";
            this.btnInventory.UseVisualStyleBackColor = true;
            this.btnInventory.Click += new System.EventHandler(this.btnInventory_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnInventory);
            this.Controls.Add(this.btnReceiving);
            this.Controls.Add(this.btnPurchase);
            this.Controls.Add(this.btnSupplier);
            this.Controls.Add(this.btnMaterial);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnMaterial;
        private System.Windows.Forms.Button btnSupplier;
        private System.Windows.Forms.Button btnPurchase;
        private System.Windows.Forms.Button btnReceiving;
        private System.Windows.Forms.Button btnInventory;
    }
}