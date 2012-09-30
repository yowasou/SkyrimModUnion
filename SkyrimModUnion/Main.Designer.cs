namespace SkyrimModUnion
{
    partial class Main
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnOutSelect = new System.Windows.Forms.Button();
            this.txtOutPath = new System.Windows.Forms.TextBox();
            this.btnOutput = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lstFiles = new System.Windows.Forms.ListBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.bW = new System.ComponentModel.BackgroundWorker();
            this.pBar = new System.Windows.Forms.ProgressBar();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pBar);
            this.panel1.Controls.Add(this.btnOutSelect);
            this.panel1.Controls.Add(this.txtOutPath);
            this.panel1.Controls.Add(this.btnOutput);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 431);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(753, 65);
            this.panel1.TabIndex = 0;
            // 
            // btnOutSelect
            // 
            this.btnOutSelect.Location = new System.Drawing.Point(537, 6);
            this.btnOutSelect.Name = "btnOutSelect";
            this.btnOutSelect.Size = new System.Drawing.Size(99, 38);
            this.btnOutSelect.TabIndex = 3;
            this.btnOutSelect.Text = "出力先選択(&E)";
            this.btnOutSelect.UseVisualStyleBackColor = true;
            this.btnOutSelect.Click += new System.EventHandler(this.btnOutSelect_Click);
            // 
            // txtOutPath
            // 
            this.txtOutPath.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtOutPath.Location = new System.Drawing.Point(12, 6);
            this.txtOutPath.Name = "txtOutPath";
            this.txtOutPath.Size = new System.Drawing.Size(488, 23);
            this.txtOutPath.TabIndex = 2;
            // 
            // btnOutput
            // 
            this.btnOutput.Location = new System.Drawing.Point(642, 6);
            this.btnOutput.Name = "btnOutput";
            this.btnOutput.Size = new System.Drawing.Size(99, 38);
            this.btnOutput.TabIndex = 1;
            this.btnOutput.Text = "出力開始(&O)";
            this.btnOutput.UseVisualStyleBackColor = true;
            this.btnOutput.Click += new System.EventHandler(this.btnOutput_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lstFiles);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(10);
            this.panel2.Size = new System.Drawing.Size(636, 431);
            this.panel2.TabIndex = 2;
            // 
            // lstFiles
            // 
            this.lstFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstFiles.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lstFiles.FormattingEnabled = true;
            this.lstFiles.ItemHeight = 16;
            this.lstFiles.Location = new System.Drawing.Point(10, 10);
            this.lstFiles.Name = "lstFiles";
            this.lstFiles.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstFiles.Size = new System.Drawing.Size(616, 411);
            this.lstFiles.TabIndex = 2;
            this.lstFiles.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstFiles_KeyDown);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnDelete);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(636, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(117, 431);
            this.panel3.TabIndex = 3;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(6, 56);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(99, 38);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "ファイル選択解除(&D)";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 38);
            this.button1.TabIndex = 0;
            this.button1.Text = "ファイル選択(&S)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // bW
            // 
            this.bW.WorkerReportsProgress = true;
            this.bW.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bW_DoWork);
            this.bW.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bW_ProgressChanged);
            this.bW.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bW_RunWorkerCompleted);
            // 
            // pBar
            // 
            this.pBar.Location = new System.Drawing.Point(12, 35);
            this.pBar.Name = "pBar";
            this.pBar.Size = new System.Drawing.Size(488, 23);
            this.pBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pBar.TabIndex = 2;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 496);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "Main";
            this.Text = "SkyrimMODUniton";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListBox lstFiles;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnOutput;
        private System.Windows.Forms.TextBox txtOutPath;
        private System.Windows.Forms.Button btnOutSelect;
        private System.Windows.Forms.Button btnDelete;
        private System.ComponentModel.BackgroundWorker bW;
        private System.Windows.Forms.ProgressBar pBar;
    }
}

