
namespace WindowsFormsCodeSamples
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ReadCustomersDataTableOnlyButton = new System.Windows.Forms.Button();
            this.CustomersDataGridView = new System.Windows.Forms.DataGridView();
            this.CustomerIdentifierColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompanyNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CountryNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReadCustomersWithTupleButton = new System.Windows.Forms.Button();
            this.ChunkWithTuplesButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.CustomersDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // ReadCustomersDataTableOnlyButton
            // 
            this.ReadCustomersDataTableOnlyButton.Location = new System.Drawing.Point(21, 12);
            this.ReadCustomersDataTableOnlyButton.Name = "ReadCustomersDataTableOnlyButton";
            this.ReadCustomersDataTableOnlyButton.Size = new System.Drawing.Size(382, 23);
            this.ReadCustomersDataTableOnlyButton.TabIndex = 0;
            this.ReadCustomersDataTableOnlyButton.Text = "Read customers with DataTable";
            this.ReadCustomersDataTableOnlyButton.UseVisualStyleBackColor = true;
            this.ReadCustomersDataTableOnlyButton.Click += new System.EventHandler(this.ReadCustomersDataTableOnlyButton_Click);
            // 
            // CustomersDataGridView
            // 
            this.CustomersDataGridView.AllowUserToAddRows = false;
            this.CustomersDataGridView.AllowUserToDeleteRows = false;
            this.CustomersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CustomersDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CustomerIdentifierColumn,
            this.CompanyNameColumn,
            this.CountryNameColumn});
            this.CustomersDataGridView.Location = new System.Drawing.Point(21, 75);
            this.CustomersDataGridView.Name = "CustomersDataGridView";
            this.CustomersDataGridView.ReadOnly = true;
            this.CustomersDataGridView.RowTemplate.Height = 25;
            this.CustomersDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.CustomersDataGridView.Size = new System.Drawing.Size(382, 149);
            this.CustomersDataGridView.TabIndex = 1;
            // 
            // CustomerIdentifierColumn
            // 
            this.CustomerIdentifierColumn.DataPropertyName = "CustomerIdentifier";
            this.CustomerIdentifierColumn.HeaderText = "Id";
            this.CustomerIdentifierColumn.Name = "CustomerIdentifierColumn";
            this.CustomerIdentifierColumn.ReadOnly = true;
            // 
            // CompanyNameColumn
            // 
            this.CompanyNameColumn.DataPropertyName = "CompanyName";
            this.CompanyNameColumn.HeaderText = "Company";
            this.CompanyNameColumn.Name = "CompanyNameColumn";
            this.CompanyNameColumn.ReadOnly = true;
            // 
            // CountryNameColumn
            // 
            this.CountryNameColumn.DataPropertyName = "CountryName";
            this.CountryNameColumn.HeaderText = "Country";
            this.CountryNameColumn.Name = "CountryNameColumn";
            this.CountryNameColumn.ReadOnly = true;
            // 
            // ReadCustomersWithTupleButton
            // 
            this.ReadCustomersWithTupleButton.Location = new System.Drawing.Point(21, 41);
            this.ReadCustomersWithTupleButton.Name = "ReadCustomersWithTupleButton";
            this.ReadCustomersWithTupleButton.Size = new System.Drawing.Size(382, 23);
            this.ReadCustomersWithTupleButton.TabIndex = 2;
            this.ReadCustomersWithTupleButton.Text = "Read customers with DataTable";
            this.ReadCustomersWithTupleButton.UseVisualStyleBackColor = true;
            this.ReadCustomersWithTupleButton.Click += new System.EventHandler(this.ReadCustomersWithTupleButton_Click);
            // 
            // ChunkWithTuplesButton
            // 
            this.ChunkWithTuplesButton.Location = new System.Drawing.Point(21, 239);
            this.ChunkWithTuplesButton.Name = "ChunkWithTuplesButton";
            this.ChunkWithTuplesButton.Size = new System.Drawing.Size(382, 23);
            this.ChunkWithTuplesButton.TabIndex = 3;
            this.ChunkWithTuplesButton.Text = "Chunk person with tuple";
            this.ChunkWithTuplesButton.UseVisualStyleBackColor = true;
            this.ChunkWithTuplesButton.Click += new System.EventHandler(this.ChunkWithTuplesButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ChunkWithTuplesButton);
            this.Controls.Add(this.ReadCustomersWithTupleButton);
            this.Controls.Add(this.CustomersDataGridView);
            this.Controls.Add(this.ReadCustomersDataTableOnlyButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Code samples";
            ((System.ComponentModel.ISupportInitialize)(this.CustomersDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ReadCustomersDataTableOnlyButton;
        private System.Windows.Forms.DataGridView CustomersDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerIdentifierColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CountryNameColumn;
        private System.Windows.Forms.Button ReadCustomersWithTupleButton;
        private System.Windows.Forms.Button ChunkWithTuplesButton;
    }
}

