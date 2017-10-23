namespace SimpleCase
{
	partial class CA_Form
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
			this.button_CertFile = new System.Windows.Forms.Button();
			this.textBox_CertFile = new System.Windows.Forms.TextBox();
			this.button_cancel = new System.Windows.Forms.Button();
			this.button_ok = new System.Windows.Forms.Button();
			this.textBox_CertPassword = new System.Windows.Forms.TextBox();
			this.label_password = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// button_CertFile
			// 
			this.button_CertFile.Location = new System.Drawing.Point(12, 16);
			this.button_CertFile.Name = "button_CertFile";
			this.button_CertFile.Size = new System.Drawing.Size(70, 23);
			this.button_CertFile.TabIndex = 5;
			this.button_CertFile.Text = "選擇檔案";
			this.button_CertFile.UseVisualStyleBackColor = true;
			this.button_CertFile.Click += new System.EventHandler(this.button_CertFile_Click);
			// 
			// textBox_CertFile
			// 
			this.textBox_CertFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.textBox_CertFile.Location = new System.Drawing.Point(99, 18);
			this.textBox_CertFile.Name = "textBox_CertFile";
			this.textBox_CertFile.ReadOnly = true;
			this.textBox_CertFile.Size = new System.Drawing.Size(198, 22);
			this.textBox_CertFile.TabIndex = 6;
			// 
			// button_cancel
			// 
			this.button_cancel.Location = new System.Drawing.Point(224, 96);
			this.button_cancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.button_cancel.Name = "button_cancel";
			this.button_cancel.Size = new System.Drawing.Size(70, 29);
			this.button_cancel.TabIndex = 13;
			this.button_cancel.Text = "取消";
			this.button_cancel.UseVisualStyleBackColor = true;
			this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
			// 
			// button_ok
			// 
			this.button_ok.Location = new System.Drawing.Point(144, 96);
			this.button_ok.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.button_ok.Name = "button_ok";
			this.button_ok.Size = new System.Drawing.Size(70, 29);
			this.button_ok.TabIndex = 12;
			this.button_ok.Text = "確定";
			this.button_ok.UseVisualStyleBackColor = true;
			this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
			// 
			// textBox_CertPassword
			// 
			this.textBox_CertPassword.HideSelection = false;
			this.textBox_CertPassword.Location = new System.Drawing.Point(99, 56);
			this.textBox_CertPassword.Name = "textBox_CertPassword";
			this.textBox_CertPassword.PasswordChar = '*';
			this.textBox_CertPassword.Size = new System.Drawing.Size(198, 22);
			this.textBox_CertPassword.TabIndex = 28;
			// 
			// label_password
			// 
			this.label_password.AutoSize = true;
			this.label_password.BackColor = System.Drawing.Color.Transparent;
			this.label_password.Location = new System.Drawing.Point(25, 62);
			this.label_password.Name = "label_password";
			this.label_password.Size = new System.Drawing.Size(53, 12);
			this.label_password.TabIndex = 27;
			this.label_password.Text = "密        碼";
			// 
			// CA_Form
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(310, 138);
			this.Controls.Add(this.textBox_CertPassword);
			this.Controls.Add(this.label_password);
			this.Controls.Add(this.button_cancel);
			this.Controls.Add(this.button_ok);
			this.Controls.Add(this.textBox_CertFile);
			this.Controls.Add(this.button_CertFile);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "CA_Form";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "CA";
			this.Load += new System.EventHandler(this.CA_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		public System.Windows.Forms.Button button_CertFile;
		public System.Windows.Forms.TextBox textBox_CertFile;
		private System.Windows.Forms.Button button_cancel;
		private System.Windows.Forms.Button button_ok;
		public System.Windows.Forms.TextBox textBox_CertPassword;
		private System.Windows.Forms.Label label_password;
	}
}