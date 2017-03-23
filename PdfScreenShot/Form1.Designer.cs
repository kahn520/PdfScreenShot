namespace PdfScreenShot
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.radFile = new System.Windows.Forms.RadioButton();
            this.radFolder = new System.Windows.Forms.RadioButton();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnPath = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.listMsg = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // radFile
            // 
            this.radFile.AutoSize = true;
            this.radFile.Checked = true;
            this.radFile.Location = new System.Drawing.Point(27, 25);
            this.radFile.Name = "radFile";
            this.radFile.Size = new System.Drawing.Size(69, 22);
            this.radFile.TabIndex = 0;
            this.radFile.TabStop = true;
            this.radFile.Text = "文件";
            this.radFile.UseVisualStyleBackColor = true;
            // 
            // radFolder
            // 
            this.radFolder.AutoSize = true;
            this.radFolder.Location = new System.Drawing.Point(139, 25);
            this.radFolder.Name = "radFolder";
            this.radFolder.Size = new System.Drawing.Size(87, 22);
            this.radFolder.TabIndex = 0;
            this.radFolder.Text = "文件夹";
            this.radFolder.UseVisualStyleBackColor = true;
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(12, 64);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(380, 28);
            this.txtPath.TabIndex = 1;
            // 
            // btnPath
            // 
            this.btnPath.Location = new System.Drawing.Point(398, 58);
            this.btnPath.Name = "btnPath";
            this.btnPath.Size = new System.Drawing.Size(75, 37);
            this.btnPath.TabIndex = 2;
            this.btnPath.Text = "选择";
            this.btnPath.UseVisualStyleBackColor = true;
            this.btnPath.Click += new System.EventHandler(this.btnPath_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(12, 114);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(116, 39);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "开始";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // listMsg
            // 
            this.listMsg.FormattingEnabled = true;
            this.listMsg.ItemHeight = 18;
            this.listMsg.Location = new System.Drawing.Point(12, 170);
            this.listMsg.Name = "listMsg";
            this.listMsg.Size = new System.Drawing.Size(476, 310);
            this.listMsg.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 492);
            this.Controls.Add(this.listMsg);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnPath);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.radFolder);
            this.Controls.Add(this.radFile);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pdf截图";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radFile;
        private System.Windows.Forms.RadioButton radFolder;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnPath;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ListBox listMsg;
    }
}

