
namespace BlogPostsFormsProject
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
            this.BlogSingleButton = new System.Windows.Forms.Button();
            this.BlogsListButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BlogSingleButton
            // 
            this.BlogSingleButton.Location = new System.Drawing.Point(25, 23);
            this.BlogSingleButton.Name = "BlogSingleButton";
            this.BlogSingleButton.Size = new System.Drawing.Size(75, 23);
            this.BlogSingleButton.TabIndex = 0;
            this.BlogSingleButton.Text = "Single";
            this.BlogSingleButton.UseVisualStyleBackColor = true;
            this.BlogSingleButton.Click += new System.EventHandler(this.BlogSingleButton_Click);
            // 
            // BlogsListButton
            // 
            this.BlogsListButton.Location = new System.Drawing.Point(25, 52);
            this.BlogsListButton.Name = "BlogsListButton";
            this.BlogsListButton.Size = new System.Drawing.Size(75, 23);
            this.BlogsListButton.TabIndex = 1;
            this.BlogsListButton.Text = "List";
            this.BlogsListButton.UseVisualStyleBackColor = true;
            this.BlogsListButton.Click += new System.EventHandler(this.BlogsListButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BlogsListButton);
            this.Controls.Add(this.BlogSingleButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BlogSingleButton;
        private System.Windows.Forms.Button BlogsListButton;
    }
}

