namespace Redis_Json
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btncompany = new System.Windows.Forms.Button();
            this.btnAddress = new System.Windows.Forms.Button();
            this.btnEmployee = new System.Windows.Forms.Button();
            this.text1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btncompany
            // 
            this.btncompany.Location = new System.Drawing.Point(66, 150);
            this.btncompany.Name = "btncompany";
            this.btncompany.Size = new System.Drawing.Size(125, 33);
            this.btncompany.TabIndex = 0;
            this.btncompany.Text = "取回公司名稱";
            this.btncompany.UseVisualStyleBackColor = true;
            this.btncompany.Click += new System.EventHandler(this.Btncompany_Click);
            // 
            // btnAddress
            // 
            this.btnAddress.Location = new System.Drawing.Point(66, 189);
            this.btnAddress.Name = "btnAddress";
            this.btnAddress.Size = new System.Drawing.Size(125, 32);
            this.btnAddress.TabIndex = 1;
            this.btnAddress.Text = "取回公司地址";
            this.btnAddress.UseVisualStyleBackColor = true;
            this.btnAddress.Click += new System.EventHandler(this.Btncompany_Click);
            // 
            // btnEmployee
            // 
            this.btnEmployee.Location = new System.Drawing.Point(66, 227);
            this.btnEmployee.Name = "btnEmployee";
            this.btnEmployee.Size = new System.Drawing.Size(125, 31);
            this.btnEmployee.TabIndex = 2;
            this.btnEmployee.Text = "取回員工";
            this.btnEmployee.UseVisualStyleBackColor = true;
            this.btnEmployee.Click += new System.EventHandler(this.Btncompany_Click);
            // 
            // text1
            // 
            this.text1.Location = new System.Drawing.Point(41, 3);
            this.text1.Name = "text1";
            this.text1.Size = new System.Drawing.Size(183, 141);
            this.text1.TabIndex = 3;
            this.text1.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.text1);
            this.Controls.Add(this.btnEmployee);
            this.Controls.Add(this.btnAddress);
            this.Controls.Add(this.btncompany);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btncompany;
        private System.Windows.Forms.Button btnAddress;
        private System.Windows.Forms.Button btnEmployee;
        private System.Windows.Forms.RichTextBox text1;
    }
}

