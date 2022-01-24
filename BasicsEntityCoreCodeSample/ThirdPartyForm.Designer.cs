
namespace DeconstructCodeSamples
{
    partial class ThirdPartyForm
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
            this.CustomerListBox = new System.Windows.Forms.ListBox();
            this.SelectedCustomerButton = new System.Windows.Forms.Button();
            this.DeconstructButton = new System.Windows.Forms.Button();
            this.partialDeconstructButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CustomerListBox
            // 
            this.CustomerListBox.FormattingEnabled = true;
            this.CustomerListBox.ItemHeight = 15;
            this.CustomerListBox.Location = new System.Drawing.Point(11, 8);
            this.CustomerListBox.Name = "CustomerListBox";
            this.CustomerListBox.Size = new System.Drawing.Size(237, 199);
            this.CustomerListBox.TabIndex = 0;
            // 
            // SelectedCustomerButton
            // 
            this.SelectedCustomerButton.Location = new System.Drawing.Point(254, 12);
            this.SelectedCustomerButton.Name = "SelectedCustomerButton";
            this.SelectedCustomerButton.Size = new System.Drawing.Size(263, 23);
            this.SelectedCustomerButton.TabIndex = 1;
            this.SelectedCustomerButton.Text = "Get customer";
            this.SelectedCustomerButton.UseVisualStyleBackColor = true;
            this.SelectedCustomerButton.Click += new System.EventHandler(this.SelectedCustomerButton_Click);
            // 
            // DeconstructButton
            // 
            this.DeconstructButton.Location = new System.Drawing.Point(254, 41);
            this.DeconstructButton.Name = "DeconstructButton";
            this.DeconstructButton.Size = new System.Drawing.Size(263, 23);
            this.DeconstructButton.TabIndex = 2;
            this.DeconstructButton.Text = "Deconstruct customer";
            this.DeconstructButton.UseVisualStyleBackColor = true;
            this.DeconstructButton.Click += new System.EventHandler(this.DeconstructButton_Click);
            // 
            // partialDeconstructButton
            // 
            this.partialDeconstructButton.Location = new System.Drawing.Point(254, 70);
            this.partialDeconstructButton.Name = "partialDeconstructButton";
            this.partialDeconstructButton.Size = new System.Drawing.Size(263, 23);
            this.partialDeconstructButton.TabIndex = 3;
            this.partialDeconstructButton.Text = "Deconstruct partial customer";
            this.partialDeconstructButton.UseVisualStyleBackColor = true;
            this.partialDeconstructButton.Click += new System.EventHandler(this.partialDeconstructButton_Click);
            // 
            // ThirdPartyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 226);
            this.Controls.Add(this.partialDeconstructButton);
            this.Controls.Add(this.DeconstructButton);
            this.Controls.Add(this.SelectedCustomerButton);
            this.Controls.Add(this.CustomerListBox);
            this.Name = "ThirdPartyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Third Party code sample";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox CustomerListBox;
        private System.Windows.Forms.Button SelectedCustomerButton;
        private System.Windows.Forms.Button DeconstructButton;
        private System.Windows.Forms.Button partialDeconstructButton;
    }
}