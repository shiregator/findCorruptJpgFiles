namespace CorruptedFileFixer
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.selectFolderButton = new System.Windows.Forms.Button();
            this.folderNameLabel = new System.Windows.Forms.Label();
            this.startButton = new System.Windows.Forms.Button();
            this.log = new System.Windows.Forms.TextBox();
            this.statusLabel = new System.Windows.Forms.Label();
            this.mainProgress = new System.Windows.Forms.ProgressBar();
            this.simulateCB = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // selectFolderButton
            // 
            this.selectFolderButton.Location = new System.Drawing.Point(12, 12);
            this.selectFolderButton.Name = "selectFolderButton";
            this.selectFolderButton.Size = new System.Drawing.Size(75, 23);
            this.selectFolderButton.TabIndex = 0;
            this.selectFolderButton.Text = "Select folder";
            this.selectFolderButton.UseVisualStyleBackColor = true;
            this.selectFolderButton.Click += new System.EventHandler(this.selectFolderButton_Click);
            // 
            // folderNameLabel
            // 
            this.folderNameLabel.AutoSize = true;
            this.folderNameLabel.Location = new System.Drawing.Point(93, 17);
            this.folderNameLabel.Name = "folderNameLabel";
            this.folderNameLabel.Size = new System.Drawing.Size(0, 13);
            this.folderNameLabel.TabIndex = 1;
            // 
            // startButton
            // 
            this.startButton.Enabled = false;
            this.startButton.Location = new System.Drawing.Point(12, 41);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 2;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // log
            // 
            this.log.Location = new System.Drawing.Point(12, 112);
            this.log.Multiline = true;
            this.log.Name = "log";
            this.log.ReadOnly = true;
            this.log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.log.Size = new System.Drawing.Size(530, 257);
            this.log.TabIndex = 3;
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(12, 96);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(35, 13);
            this.statusLabel.TabIndex = 4;
            this.statusLabel.Text = "label2";
            // 
            // mainProgress
            // 
            this.mainProgress.Location = new System.Drawing.Point(12, 70);
            this.mainProgress.Name = "mainProgress";
            this.mainProgress.Size = new System.Drawing.Size(530, 23);
            this.mainProgress.TabIndex = 5;
            // 
            // simulateCB
            // 
            this.simulateCB.AutoSize = true;
            this.simulateCB.Location = new System.Drawing.Point(106, 45);
            this.simulateCB.Name = "simulateCB";
            this.simulateCB.Size = new System.Drawing.Size(88, 17);
            this.simulateCB.TabIndex = 6;
            this.simulateCB.Text = "Only find files";
			this.simulateCB.Checked = true;
            this.simulateCB.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 381);
            this.Controls.Add(this.simulateCB);
            this.Controls.Add(this.mainProgress);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.log);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.folderNameLabel);
            this.Controls.Add(this.selectFolderButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Corrupted files fixer";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button selectFolderButton;
        private System.Windows.Forms.Label folderNameLabel;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.TextBox log;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.ProgressBar mainProgress;
        private System.Windows.Forms.CheckBox simulateCB;
    }
}

