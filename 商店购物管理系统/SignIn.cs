using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 商店购物管理系统
{
    public partial class SignIn : Form
    {
        private SqlConnection CN;
        private SqlDataAdapter DA;
        private DataSet DS;
        private SqlCommandBuilder CB;

        private readonly List<TextBox> textBoxes = new List<TextBox>();

        public SignIn(SqlConnection cn, SqlDataAdapter da, DataSet ds, SqlCommandBuilder cb)
        {
            InitializeComponent();
            InitializeTextBoxes();
            this.CN = cn;
            this.DA = da;
            this.DS = ds;
            this.CB = cb;
        }

        // ------ 聚焦TextBox控件时，清空提示内容 ------
        private void InitializeTextBoxes()
        {
            // 将所有 TextBox 控件添加到列表中
            textBoxes.Add(用户名);
            textBoxes.Add(密码);
            textBoxes.Add(姓名);
            textBoxes.Add(电子邮箱);
            textBoxes.Add(地址);
            textBoxes.Add(电话号码);


            // 初始化每个 TextBox
            foreach (var textBox in textBoxes)
            {
                InitializeTextBoxHint(textBox);
            }
        }

        private void InitializeTextBoxHint(TextBox textBox)
        {
            // 设置提示文本
            textBox.Text = "请输入" + textBox.Name;
            textBox.ForeColor = System.Drawing.Color.Gray;

            // 添加事件处理
            textBox.GotFocus += TextBox_GotFocus;
            textBox.LostFocus += TextBox_LostFocus;
        }

        private void TextBox_GotFocus(object sender, EventArgs e)
        {
            var textBox = (TextBox)sender;

            // 获取焦点时清空提示文本
            if (textBox.Text.StartsWith("请输入"))
            {
                textBox.Text = "";
                textBox.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void TextBox_LostFocus(object sender, EventArgs e)
        {
            var textBox = (TextBox)sender;

            // 失去焦点时显示提示文本
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "请输入" + textBox.Name;
                textBox.ForeColor = System.Drawing.Color.Gray;
            }
        }
        // ------ 聚焦TextBox控件时，清空提示内容 ------

        private void SignIn_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            // 用户信息
            string username = 用户名.Text;
            string password = 密码.Text;
            string fullName = 姓名.Text;
            string email = 电子邮箱.Text;
            string address = 地址.Text;
            string phoneNumber = 电话号码.Text;

            // 插入用户信息
            string insertSql = "INSERT INTO UserInfo (Username, Pass_word, FullName, Email, Addr, PhoneNumber) " +
                                "VALUES (@Username, @Password, @FullName, @Email, @Address, @PhoneNumber)";

            try
            {
                using (SqlCommand com = new SqlCommand(insertSql, CN))
                {
                    // 添加参数
                    com.Parameters.AddWithValue("@Username", username);
                    com.Parameters.AddWithValue("@Password", password);
                    com.Parameters.AddWithValue("@FullName", fullName);
                    com.Parameters.AddWithValue("@Email", email);
                    com.Parameters.AddWithValue("@Address", address);
                    com.Parameters.AddWithValue("@PhoneNumber", phoneNumber);

                    // 执行插入
                    int rowsAffected = com.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("用户注册成功！");
                    }
                    else
                    {
                        MessageBox.Show("用户注册失败！");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"发生错误：{ex.Message}");
            }

        }
    }
}
