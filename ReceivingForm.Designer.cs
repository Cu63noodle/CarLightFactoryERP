namespace CarLightFactoryERP
{
    partial class ReceivingForm
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
            this.cmbPendingPurchaseOrder = new System.Windows.Forms.ComboBox();
            this.dgvReceivingDetail = new System.Windows.Forms.DataGridView();
            this.btnReceivePurchaseOrder = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceivingDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "待入庫採購單";
            // 
            // cmbPendingPurchaseOrder
            // 
            this.cmbPendingPurchaseOrder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPendingPurchaseOrder.FormattingEnabled = true;
            this.cmbPendingPurchaseOrder.Location = new System.Drawing.Point(105, 34);
            this.cmbPendingPurchaseOrder.Name = "cmbPendingPurchaseOrder";
            this.cmbPendingPurchaseOrder.Size = new System.Drawing.Size(121, 20);
            this.cmbPendingPurchaseOrder.TabIndex = 1;
            this.cmbPendingPurchaseOrder.SelectedIndexChanged += new System.EventHandler(this.cmbPendingPurchaseOrder_SelectedIndexChanged);
            // 
            // dgvReceivingDetail
            // 
            this.dgvReceivingDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReceivingDetail.Location = new System.Drawing.Point(257, 34);
            this.dgvReceivingDetail.Name = "dgvReceivingDetail";
            this.dgvReceivingDetail.RowTemplate.Height = 24;
            this.dgvReceivingDetail.Size = new System.Drawing.Size(531, 333);
            this.dgvReceivingDetail.TabIndex = 2;
            // 
            // btnReceivePurchaseOrder
            // 
            this.btnReceivePurchaseOrder.Location = new System.Drawing.Point(63, 91);
            this.btnReceivePurchaseOrder.Name = "btnReceivePurchaseOrder";
            this.btnReceivePurchaseOrder.Size = new System.Drawing.Size(75, 23);
            this.btnReceivePurchaseOrder.TabIndex = 3;
            this.btnReceivePurchaseOrder.Text = "確認入庫";
            this.btnReceivePurchaseOrder.UseVisualStyleBackColor = true;
            this.btnReceivePurchaseOrder.Click += new System.EventHandler(this.btnReceivePurchaseOrder_Click);
            // 
            // ReceivingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnReceivePurchaseOrder);
            this.Controls.Add(this.dgvReceivingDetail);
            this.Controls.Add(this.cmbPendingPurchaseOrder);
            this.Controls.Add(this.label1);
            this.Name = "ReceivingForm";
            this.Text = "ReceivingForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceivingDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbPendingPurchaseOrder;
        private System.Windows.Forms.DataGridView dgvReceivingDetail;
        private System.Windows.Forms.Button btnReceivePurchaseOrder;
    }
}