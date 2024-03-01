using System.Data;
using System.Data.SqlClient;

namespace 商店购物管理系统
{
    public partial class LogIn : Form
    {
        //连接数据库
        public SqlConnection CN;
        public SqlDataAdapter DA;
        public DataSet DS;

        public SqlCommandBuilder CB;   //用于编辑数据、添加和删除记录，注意相应数据表要定义主键

        private string generatedCode;
        private readonly List<TextBox> textBoxes = new List<TextBox>();
        public LogIn()
        {
            InitializeComponent();
            InitializeTextBoxes();
            generatedCode = GenerateRandomCode();
            UpdateCaptchaImage();
        }

        // ------ 随机生成验证码功能 ------
        private void UpdateCaptchaImage()
        {
            Bitmap captchaImage = GenerateCaptchaImage(generatedCode, 150, 50);
            pictureBox1.Image = captchaImage;
        }

        private string GenerateRandomCode()
        {
            // 生成随机验证码
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 6)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private Bitmap GenerateCaptchaImage(string code, int width, int height)
        {
            // 生成验证码图片
            Bitmap image = new Bitmap(width, height);
            using (Graphics graphics = Graphics.FromImage(image))
            {
                using (Font font = new Font("Arial", 18))
                {
                    graphics.DrawString(code, font, Brushes.Black, new PointF(10, 10));
                }
            }
            return image;
        }
        // ------ 随机生成验证码功能 ------

        // ------ 聚焦TextBox控件时，清空提示内容 ------
        private void InitializeTextBoxes()
        {
            // 将所有 TextBox 控件添加到列表中
            textBoxes.Add(用户名);
            textBoxes.Add(密码);
            textBoxes.Add(验证码);

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

        private void LogIn_Load(object sender, EventArgs e)
        {
            string link = "Server=.;Database=商店购物管理系统数据库;User=sa;Password=tjzj";
            CN = new SqlConnection(link);
            DS = new DataSet();
            DA = new SqlDataAdapter("select * from UserInfo", CN);
            DA.Fill(DS, "SMSD");
            CB = new SqlCommandBuilder(DA);

            //测试是否连通
            //MessageBox.Show(DS.Tables[0].Rows[0]["UserID"].ToString());   //测试用，可删除

        }

        private void button1_Click(object sender, EventArgs e)
        {

            //验证用户名和密码是否正确
            string usrname = 用户名.Text;
            string pwd = 密码.Text;
            // ------------ 测试用例 ------------
            if (用户名.Text == "111" && 密码.Text == "111")
            {
                HomePage HomePage = new HomePage(CN, DA, DS, CB);
                HomePage.Show();
                this.Hide();
            }
            // ------------ 测试用例 ------------
            //验证码
            string enteredCode = 验证码.Text;
            //构建SQL查询语句
            string sql = $"SELECT Pass_word FROM UserInfo WHERE Username = '{usrname}'";
            try
            {
                using (SqlCommand com = new SqlCommand(sql, CN))
                {
                    //打开数据库连接
                    if (CN.State != ConnectionState.Open)
                    {
                        CN.Open();
                    }
                    //执行查询并获取结果
                    using (SqlDataReader reader = com.ExecuteReader())
                    {
                        if (reader.Read()) //账号存在，查看密码是否正确
                        {
                            string pwd_tocheck = reader["Pass_word"].ToString();
                            if (pwd == pwd_tocheck)
                            {
                                //用户名密码输入正确，验证码输入正确
                                if (enteredCode.Equals(generatedCode, StringComparison.OrdinalIgnoreCase))
                                {
                                    reader.Close();
                                    HomePage HomePage = new HomePage(CN, DA, DS, CB);
                                    HomePage.Show();
                                    this.Hide();
                                }
                                else
                                {
                                    MessageBox.Show("验证码错误，请重新输入！");
                                    generatedCode = GenerateRandomCode();
                                    UpdateCaptchaImage();
                                }
                            }
                            else
                            {
                                MessageBox.Show("密码输入错误！");
                            }
                        }
                        else
                        {
                            MessageBox.Show("用户名不存在！");
                        }
                        reader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"发生错误：{ex.Message}");
            }
            finally
            {
                // 在 finally 中确保关闭连接
                if (CN.State == ConnectionState.Open)
                {
                    CN.Close();
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignIn signin = new SignIn(CN, DA, DS, CB);
            signin.Show();
            this.Hide();
        }
    }
}