namespace 商店购物管理系统
{
    partial class SignIn
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
            用户名 = new TextBox();
            密码 = new TextBox();
            姓名 = new TextBox();
            电子邮箱 = new TextBox();
            地址 = new TextBox();
            电话号码 = new TextBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // 用户名
            // 
            用户名.Location = new Point(288, 60);
            用户名.Name = "用户名";
            用户名.Size = new Size(125, 27);
            用户名.TabIndex = 1;
            用户名.Text = "请输入用户名";
            // 
            // 密码
            // 
            密码.Location = new Point(288, 116);
            密码.Name = "密码";
            密码.Size = new Size(125, 27);
            密码.TabIndex = 2;
            密码.Text = "请输入密码";
            // 
            // 姓名
            // 
            姓名.Location = new Point(288, 169);
            姓名.Name = "姓名";
            姓名.Size = new Size(125, 27);
            姓名.TabIndex = 3;
            姓名.Text = "姓名";
            // 
            // 电子邮箱
            // 
            电子邮箱.Location = new Point(288, 227);
            电子邮箱.Name = "电子邮箱";
            电子邮箱.Size = new Size(125, 27);
            电子邮箱.TabIndex = 4;
            电子邮箱.Text = " 电子邮箱";
            // 
            // 地址
            // 
            地址.Location = new Point(288, 277);
            地址.Name = "地址";
            地址.Size = new Size(125, 27);
            地址.TabIndex = 5;
            地址.Text = "地址";
            // 
            // 电话号码
            // 
            电话号码.Location = new Point(288, 330);
            电话号码.Name = "电话号码";
            电话号码.Size = new Size(125, 27);
            电话号码.TabIndex = 6;
            电话号码.Text = "电话号码";
            // 
            // button1
            // 
            button1.Location = new Point(601, 330);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 7;
            button1.Text = "注册";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // SignIn
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(电话号码);
            Controls.Add(地址);
            Controls.Add(电子邮箱);
            Controls.Add(姓名);
            Controls.Add(密码);
            Controls.Add(用户名);
            Name = "SignIn";
            Text = "用户注册";
            Load += SignIn_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox 用户名;
        private TextBox 密码;
        private TextBox 姓名;
        private TextBox 电子邮箱;
        private TextBox 地址;
        private TextBox 电话号码;
        private Button button1;
    }
}