namespace CarRental_desktop
{
    partial class Form1
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
            this.DeleteButton = new System.Windows.Forms.Button();
            this.CarGrid = new System.Windows.Forms.DataGridView();
            this.lincense_plate_number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Brand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Model = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Daily_cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.CarGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(31, 8);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(88, 35);
            this.DeleteButton.TabIndex = 0;
            this.DeleteButton.Text = "Törlés";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // CarGrid
            // 
            this.CarGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CarGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.lincense_plate_number,
            this.Brand,
            this.Model,
            this.Daily_cost});
            this.CarGrid.Location = new System.Drawing.Point(32, 48);
            this.CarGrid.MultiSelect = false;
            this.CarGrid.Name = "CarGrid";
            this.CarGrid.RowHeadersWidth = 51;
            this.CarGrid.RowTemplate.Height = 24;
            this.CarGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.CarGrid.Size = new System.Drawing.Size(960, 475);
            this.CarGrid.TabIndex = 1;
            // 
            // lincense_plate_number
            // 
            this.lincense_plate_number.DataPropertyName = "License_plate_number";
            this.lincense_plate_number.HeaderText = "Rendszám";
            this.lincense_plate_number.MinimumWidth = 6;
            this.lincense_plate_number.Name = "lincense_plate_number";
            this.lincense_plate_number.Width = 125;
            // 
            // Brand
            // 
            this.Brand.DataPropertyName = "Brand";
            this.Brand.HeaderText = "Márka";
            this.Brand.MinimumWidth = 6;
            this.Brand.Name = "Brand";
            this.Brand.Width = 125;
            // 
            // Model
            // 
            this.Model.DataPropertyName = "Model";
            this.Model.HeaderText = "Model";
            this.Model.MinimumWidth = 6;
            this.Model.Name = "Model";
            this.Model.Width = 125;
            // 
            // Daily_cost
            // 
            this.Daily_cost.DataPropertyName = "Daily_cost";
            this.Daily_cost.HeaderText = "Napidíj (Ft)";
            this.Daily_cost.MinimumWidth = 6;
            this.Daily_cost.Name = "Daily_cost";
            this.Daily_cost.Width = 125;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 523);
            this.Controls.Add(this.CarGrid);
            this.Controls.Add(this.DeleteButton);
            this.Name = "Form1";
            this.Text = "Petrik autókölcsönző";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CarGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.DataGridView CarGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn lincense_plate_number;
        private System.Windows.Forms.DataGridViewTextBoxColumn Brand;
        private System.Windows.Forms.DataGridViewTextBoxColumn Model;
        private System.Windows.Forms.DataGridViewTextBoxColumn Daily_cost;
    }
}

