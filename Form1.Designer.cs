namespace SampleFileUploader
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
            tbxHostIp01 = new TextBox();
            tbxHostIp02 = new TextBox();
            tbxHostIp03 = new TextBox();
            tbxHostIp04 = new TextBox();
            btnClientConnect = new Button();
            btnChooseFile = new Button();
            btnStartUpload = new Button();
            label1 = new Label();
            label2 = new Label();
            tbxHostPort = new TextBox();
            lblFilePath = new Label();
            SuspendLayout();
            // 
            // tbxHostIp01
            // 
            tbxHostIp01.Location = new Point(56, 42);
            tbxHostIp01.Name = "tbxHostIp01";
            tbxHostIp01.Size = new Size(26, 23);
            tbxHostIp01.TabIndex = 0;
            // 
            // tbxHostIp02
            // 
            tbxHostIp02.Location = new Point(88, 42);
            tbxHostIp02.Name = "tbxHostIp02";
            tbxHostIp02.Size = new Size(26, 23);
            tbxHostIp02.TabIndex = 0;
            // 
            // tbxHostIp03
            // 
            tbxHostIp03.Location = new Point(120, 42);
            tbxHostIp03.Name = "tbxHostIp03";
            tbxHostIp03.Size = new Size(26, 23);
            tbxHostIp03.TabIndex = 0;
            // 
            // tbxHostIp04
            // 
            tbxHostIp04.Location = new Point(152, 42);
            tbxHostIp04.Name = "tbxHostIp04";
            tbxHostIp04.Size = new Size(26, 23);
            tbxHostIp04.TabIndex = 0;
            // 
            // btnClientConnect
            // 
            btnClientConnect.Location = new Point(189, 43);
            btnClientConnect.Name = "btnClientConnect";
            btnClientConnect.Size = new Size(75, 23);
            btnClientConnect.TabIndex = 1;
            btnClientConnect.Text = "Connect";
            btnClientConnect.UseVisualStyleBackColor = true;
            btnClientConnect.Click += btnClientConnect_Click;
            // 
            // btnChooseFile
            // 
            btnChooseFile.Location = new Point(56, 129);
            btnChooseFile.Name = "btnChooseFile";
            btnChooseFile.Size = new Size(40, 23);
            btnChooseFile.TabIndex = 2;
            btnChooseFile.Text = "...";
            btnChooseFile.UseVisualStyleBackColor = true;
            btnChooseFile.Click += btnChooseFile_Click;
            // 
            // btnStartUpload
            // 
            btnStartUpload.Enabled = false;
            btnStartUpload.Location = new Point(56, 194);
            btnStartUpload.Name = "btnStartUpload";
            btnStartUpload.Size = new Size(40, 23);
            btnStartUpload.TabIndex = 4;
            btnStartUpload.Text = "Start";
            btnStartUpload.UseVisualStyleBackColor = true;
            btnStartUpload.Click += btnStartUpload_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(-1, 45);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 5;
            label1.Text = "Host IP :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 74);
            label2.Name = "label2";
            label2.Size = new Size(35, 15);
            label2.TabIndex = 5;
            label2.Text = "Port :";
            // 
            // tbxHostPort
            // 
            tbxHostPort.Location = new Point(56, 71);
            tbxHostPort.Name = "tbxHostPort";
            tbxHostPort.Size = new Size(58, 23);
            tbxHostPort.TabIndex = 6;
            // 
            // lblFilePath
            // 
            lblFilePath.AutoEllipsis = true;
            lblFilePath.AutoSize = true;
            lblFilePath.Location = new Point(113, 133);
            lblFilePath.MaximumSize = new Size(200, 0);
            lblFilePath.Name = "lblFilePath";
            lblFilePath.Size = new Size(91, 15);
            lblFilePath.TabIndex = 3;
            lblFilePath.Text = "No File Selected";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(331, 460);
            Controls.Add(tbxHostPort);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnStartUpload);
            Controls.Add(lblFilePath);
            Controls.Add(btnChooseFile);
            Controls.Add(btnClientConnect);
            Controls.Add(tbxHostIp04);
            Controls.Add(tbxHostIp03);
            Controls.Add(tbxHostIp02);
            Controls.Add(tbxHostIp01);
            Name = "Form1";
            Text = "Form1";
            FormClosing += Form1_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbxHostIp01;
        private TextBox tbxHostIp02;
        private TextBox tbxHostIp03;
        private TextBox tbxHostIp04;
        private Button btnClientConnect;
        private Button btnChooseFile;
        private Button btnStartUpload;
        private Label label1;
        private Label label2;
        private TextBox tbxHostPort;
        private Label lblFilePath;
    }
}
