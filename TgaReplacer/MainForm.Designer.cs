namespace TgaReplacer
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonStart = new System.Windows.Forms.Button();
            this.labelTgaFile = new System.Windows.Forms.Label();
            this.labelBinaryFile = new System.Windows.Forms.Label();
            this.buttonSelectTgaFile = new System.Windows.Forms.Button();
            this.buttonSelectBinaryFile = new System.Windows.Forms.Button();
            this.textBoxTgaFile = new System.Windows.Forms.TextBox();
            this.textBoxBinaryFile = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.openFileDialogTargetBinary = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialogTga = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStart.Location = new System.Drawing.Point(155, 56);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(278, 40);
            this.buttonStart.TabIndex = 11;
            this.buttonStart.Text = "変換開始";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // labelTgaFile
            // 
            this.labelTgaFile.AutoSize = true;
            this.labelTgaFile.Location = new System.Drawing.Point(12, 34);
            this.labelTgaFile.Name = "labelTgaFile";
            this.labelTgaFile.Size = new System.Drawing.Size(72, 12);
            this.labelTgaFile.TabIndex = 9;
            this.labelTgaFile.Text = "使用する画像";
            // 
            // labelBinaryFile
            // 
            this.labelBinaryFile.AutoSize = true;
            this.labelBinaryFile.Location = new System.Drawing.Point(12, 9);
            this.labelBinaryFile.Name = "labelBinaryFile";
            this.labelBinaryFile.Size = new System.Drawing.Size(76, 12);
            this.labelBinaryFile.TabIndex = 7;
            this.labelBinaryFile.Text = "書き換えるDLL";
            // 
            // buttonSelectTgaFile
            // 
            this.buttonSelectTgaFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSelectTgaFile.Location = new System.Drawing.Point(518, 29);
            this.buttonSelectTgaFile.Name = "buttonSelectTgaFile";
            this.buttonSelectTgaFile.Size = new System.Drawing.Size(54, 23);
            this.buttonSelectTgaFile.TabIndex = 10;
            this.buttonSelectTgaFile.Text = "参照...";
            this.buttonSelectTgaFile.UseVisualStyleBackColor = true;
            this.buttonSelectTgaFile.Click += new System.EventHandler(this.buttonSelectTgaFile_Click);
            // 
            // buttonSelectBinaryFile
            // 
            this.buttonSelectBinaryFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSelectBinaryFile.Location = new System.Drawing.Point(518, 4);
            this.buttonSelectBinaryFile.Name = "buttonSelectBinaryFile";
            this.buttonSelectBinaryFile.Size = new System.Drawing.Size(54, 23);
            this.buttonSelectBinaryFile.TabIndex = 6;
            this.buttonSelectBinaryFile.Text = "参照...";
            this.buttonSelectBinaryFile.UseVisualStyleBackColor = true;
            this.buttonSelectBinaryFile.Click += new System.EventHandler(this.buttonSelectBinaryFile_Click);
            // 
            // textBoxTgaFile
            // 
            this.textBoxTgaFile.AllowDrop = true;
            this.textBoxTgaFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTgaFile.Location = new System.Drawing.Point(90, 31);
            this.textBoxTgaFile.Name = "textBoxTgaFile";
            this.textBoxTgaFile.Size = new System.Drawing.Size(421, 19);
            this.textBoxTgaFile.TabIndex = 8;
            this.textBoxTgaFile.Text = "healthAndSafety.tga";
            this.textBoxTgaFile.DragDrop += new System.Windows.Forms.DragEventHandler(this.fileNameBox_DragDrop);
            this.textBoxTgaFile.DragEnter += new System.Windows.Forms.DragEventHandler(this.fileNameBox_DragEnter);
            // 
            // textBoxBinaryFile
            // 
            this.textBoxBinaryFile.AllowDrop = true;
            this.textBoxBinaryFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxBinaryFile.Location = new System.Drawing.Point(90, 6);
            this.textBoxBinaryFile.Name = "textBoxBinaryFile";
            this.textBoxBinaryFile.Size = new System.Drawing.Size(422, 19);
            this.textBoxBinaryFile.TabIndex = 5;
            this.textBoxBinaryFile.DragDrop += new System.Windows.Forms.DragEventHandler(this.fileNameBox_DragDrop);
            this.textBoxBinaryFile.DragEnter += new System.Windows.Forms.DragEventHandler(this.fileNameBox_DragEnter);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 107);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(584, 22);
            this.statusStrip1.TabIndex = 12;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(122, 17);
            this.toolStripStatusLabel.Text = "ファイルを指定して下さい";
            this.toolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // openFileDialogTargetBinary
            // 
            this.openFileDialogTargetBinary.DefaultExt = "dll";
            this.openFileDialogTargetBinary.Filter = "DLL|*.dll|All files|*.*";
            // 
            // openFileDialogTga
            // 
            this.openFileDialogTga.DefaultExt = "tga";
            this.openFileDialogTga.Filter = "TGA image|*.tga|All files|*.*";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 129);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.labelTgaFile);
            this.Controls.Add(this.labelBinaryFile);
            this.Controls.Add(this.buttonSelectTgaFile);
            this.Controls.Add(this.buttonSelectBinaryFile);
            this.Controls.Add(this.textBoxTgaFile);
            this.Controls.Add(this.textBoxBinaryFile);
            this.Name = "MainForm";
            this.Text = "指定ファイル中の1024×512TGA画像を置換するソフト";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Label labelTgaFile;
        private System.Windows.Forms.Label labelBinaryFile;
        private System.Windows.Forms.Button buttonSelectTgaFile;
        private System.Windows.Forms.Button buttonSelectBinaryFile;
        private System.Windows.Forms.TextBox textBoxTgaFile;
        private System.Windows.Forms.TextBox textBoxBinaryFile;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.OpenFileDialog openFileDialogTargetBinary;
        private System.Windows.Forms.OpenFileDialog openFileDialogTga;

    }
}

