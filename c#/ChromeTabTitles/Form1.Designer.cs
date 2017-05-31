namespace ChromeTabTitles
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
            this.lstTabTitles = new System.Windows.Forms.ListBox();
            this.btnShowTabTitles = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstTabTitles
            // 
            this.lstTabTitles.FormattingEnabled = true;
            this.lstTabTitles.ItemHeight = 25;
            this.lstTabTitles.Location = new System.Drawing.Point(12, 12);
            this.lstTabTitles.Name = "lstTabTitles";
            this.lstTabTitles.Size = new System.Drawing.Size(854, 679);
            this.lstTabTitles.TabIndex = 0;
            // 
            // btnShowTabTitles
            // 
            this.btnShowTabTitles.Location = new System.Drawing.Point(12, 708);
            this.btnShowTabTitles.Name = "btnShowTabTitles";
            this.btnShowTabTitles.Size = new System.Drawing.Size(854, 74);
            this.btnShowTabTitles.TabIndex = 1;
            this.btnShowTabTitles.Text = "Show Tab Titles";
            this.btnShowTabTitles.UseVisualStyleBackColor = true;
            this.btnShowTabTitles.Click += new System.EventHandler(this.btnShowTabTitles_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 794);
            this.Controls.Add(this.btnShowTabTitles);
            this.Controls.Add(this.lstTabTitles);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Chrome Tab Titles";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstTabTitles;
        private System.Windows.Forms.Button btnShowTabTitles;
    }
}

