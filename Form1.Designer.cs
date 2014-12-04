namespace MyClient
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
            this.objFileName = new System.Windows.Forms.TextBox();
            this.objLoadFile = new System.Windows.Forms.Button();
            this.myOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // objFileName
            // 
            this.objFileName.Location = new System.Drawing.Point(34, 49);
            this.objFileName.Name = "objFileName";
            this.objFileName.Size = new System.Drawing.Size(327, 20);
            this.objFileName.TabIndex = 1;
            // 
            // objLoadFile
            // 
            this.objLoadFile.Location = new System.Drawing.Point(367, 49);
            this.objLoadFile.Name = "objLoadFile";
            this.objLoadFile.Size = new System.Drawing.Size(75, 23);
            this.objLoadFile.TabIndex = 0;
            this.objLoadFile.Text = "Load file";
            this.objLoadFile.UseVisualStyleBackColor = true;
            this.objLoadFile.Click += new System.EventHandler(this.objLoadFile_Click);
            // 
            // myOpenFileDialog
            // 
            this.myOpenFileDialog.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 376);
            this.Controls.Add(this.objFileName);
            this.Controls.Add(this.objLoadFile);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox objFileName;
        private System.Windows.Forms.Button objLoadFile;
        private System.Windows.Forms.OpenFileDialog myOpenFileDialog;
    }
}

