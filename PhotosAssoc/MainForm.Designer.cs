namespace PhotosAssoc
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
            if (disposing && (components != null)) {
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOutputPhotosDir = new System.Windows.Forms.TextBox();
            this.cmdPhotosPathBrowse = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPhotosPath = new System.Windows.Forms.TextBox();
            this.cmdMakeArchive = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmdUpdateXML = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cmdXmlBrowse = new System.Windows.Forms.Button();
            this.txtXmlPath = new System.Windows.Forms.TextBox();
            this.photosDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.xmlDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtOutputPhotosDir);
            this.groupBox1.Controls.Add(this.cmdPhotosPathBrowse);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtPhotosPath);
            this.groupBox1.Controls.Add(this.cmdMakeArchive);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(597, 77);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Архивация фотографий";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Сложить в папку:";
            // 
            // txtOutputPhotosDir
            // 
            this.txtOutputPhotosDir.Location = new System.Drawing.Point(129, 43);
            this.txtOutputPhotosDir.Name = "txtOutputPhotosDir";
            this.txtOutputPhotosDir.Size = new System.Drawing.Size(375, 20);
            this.txtOutputPhotosDir.TabIndex = 4;
            // 
            // cmdPhotosPathBrowse
            // 
            this.cmdPhotosPathBrowse.Location = new System.Drawing.Point(510, 15);
            this.cmdPhotosPathBrowse.Name = "cmdPhotosPathBrowse";
            this.cmdPhotosPathBrowse.Size = new System.Drawing.Size(75, 23);
            this.cmdPhotosPathBrowse.TabIndex = 3;
            this.cmdPhotosPathBrowse.Text = "Обзор...";
            this.cmdPhotosPathBrowse.UseVisualStyleBackColor = true;
            this.cmdPhotosPathBrowse.Click += new System.EventHandler(this.cmdPhotosPathBrowse_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Путь к фотографиям:";
            // 
            // txtPhotosPath
            // 
            this.txtPhotosPath.Location = new System.Drawing.Point(129, 17);
            this.txtPhotosPath.Name = "txtPhotosPath";
            this.txtPhotosPath.Size = new System.Drawing.Size(375, 20);
            this.txtPhotosPath.TabIndex = 1;
            // 
            // cmdMakeArchive
            // 
            this.cmdMakeArchive.Location = new System.Drawing.Point(510, 41);
            this.cmdMakeArchive.Name = "cmdMakeArchive";
            this.cmdMakeArchive.Size = new System.Drawing.Size(75, 23);
            this.cmdMakeArchive.TabIndex = 0;
            this.cmdMakeArchive.Text = "Обработать";
            this.cmdMakeArchive.UseVisualStyleBackColor = true;
            this.cmdMakeArchive.Click += new System.EventHandler(this.cmdMakeArchive_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmdUpdateXML);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cmdXmlBrowse);
            this.groupBox2.Controls.Add(this.txtXmlPath);
            this.groupBox2.Location = new System.Drawing.Point(12, 95);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(597, 83);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Обновление XML";
            // 
            // cmdUpdateXML
            // 
            this.cmdUpdateXML.Location = new System.Drawing.Point(510, 46);
            this.cmdUpdateXML.Name = "cmdUpdateXML";
            this.cmdUpdateXML.Size = new System.Drawing.Size(75, 23);
            this.cmdUpdateXML.TabIndex = 3;
            this.cmdUpdateXML.Text = "Обновить XML";
            this.cmdUpdateXML.UseVisualStyleBackColor = true;
            this.cmdUpdateXML.Click += new System.EventHandler(this.cmdUpdateXML_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Путь к XML:";
            // 
            // cmdXmlBrowse
            // 
            this.cmdXmlBrowse.Location = new System.Drawing.Point(510, 17);
            this.cmdXmlBrowse.Name = "cmdXmlBrowse";
            this.cmdXmlBrowse.Size = new System.Drawing.Size(75, 23);
            this.cmdXmlBrowse.TabIndex = 1;
            this.cmdXmlBrowse.Text = "Обзор...";
            this.cmdXmlBrowse.UseVisualStyleBackColor = true;
            this.cmdXmlBrowse.Click += new System.EventHandler(this.cmdXmlBrowse_Click);
            // 
            // txtXmlPath
            // 
            this.txtXmlPath.Location = new System.Drawing.Point(129, 19);
            this.txtXmlPath.Name = "txtXmlPath";
            this.txtXmlPath.Size = new System.Drawing.Size(375, 20);
            this.txtXmlPath.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 186);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.Text = "Фотографии";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOutputPhotosDir;
        private System.Windows.Forms.Button cmdPhotosPathBrowse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPhotosPath;
        private System.Windows.Forms.Button cmdMakeArchive;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.FolderBrowserDialog photosDialog;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cmdXmlBrowse;
        private System.Windows.Forms.TextBox txtXmlPath;
        private System.Windows.Forms.FolderBrowserDialog xmlDialog;
        private System.Windows.Forms.Button cmdUpdateXML;
    }
}

