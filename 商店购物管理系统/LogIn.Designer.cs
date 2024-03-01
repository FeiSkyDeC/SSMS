namespace 商店购物管理系统
{
    partial class LogIn
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
            button1 = new Button();
            用户名 = new TextBox();
            密码 = new TextBox();
            验证码 = new TextBox();
            linkLabel1 = new LinkLabel();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = SystemColors.Control;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Location = new Point(58, 291);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 0;
            button1.Text = "登录";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // 用户名
            // 
            用户名.Location = new Point(58, 51);
            用户名.Name = "用户名";
            用户名.Size = new Size(235, 27);
            用户名.TabIndex = 1;
            用户名.Text = "请输入用户名";
            // 
            // 密码
            // 
            密码.Location = new Point(58, 115);
            密码.Name = "密码";
            密码.Size = new Size(235, 27);
            密码.TabIndex = 2;
            密码.Text = "请输入密码";
            // 
            // 验证码
            // 
            验证码.Location = new Point(58, 178);
            验证码.Name = "验证码";
            验证码.Size = new Size(235, 27);
            验证码.TabIndex = 3;
            验证码.Text = "验证码";
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(58, 364);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(39, 20);
            linkLabel1.TabIndex = 4;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "注册";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(396, 166);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(176, 49);
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(396, 51);
            label1.Name = "label1";
            label1.Size = new Size(126, 60);
            label1.TabIndex = 6;
            label1.Text = "测试用户名：111\r\n密码：111\r\n\r\n";
            // 
            // LogIn
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Controls.Add(linkLabel1);
            Controls.Add(验证码);
            Controls.Add(密码);
            Controls.Add(用户名);
            Controls.Add(button1);
            Name = "LogIn";
            Text = "商店用户管理系统";
            Load += LogIn_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox 用户名;
        private TextBox 密码;
        private TextBox 验证码;
        private LinkLabel linkLabel1;
        private PictureBox pictureBox1;
        private Label label1;
    }
}