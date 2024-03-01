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
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace 商店购物管理系统
{
    public partial class HomePage : Form
    {
        private SqlConnection CN;
        private SqlDataAdapter DA;
        private DataSet DS;
        private SqlCommandBuilder CB;
        private SqlCommand cmd;
        private DataTable dataTable;
        private readonly List<TextBox> textBoxes = new List<TextBox>();
        string insertQuery;
        public HomePage(SqlConnection cn, SqlDataAdapter da, DataSet ds, SqlCommandBuilder cb)
        {
            InitializeComponent();

            this.CN = cn;
            this.DA = da;
            this.DS = ds;
            this.CB = cb;

            LoadCategories(CN); //加载商品类别到ComboBox控件中
            LoadCategories2(CN);
            LoadInventoryData(CN); // 加载库存信息到库存查看的DataGridView2控件中
            LoadSupplierData(CN); // 加载供应商信息到DataGridView3控件中
            LoadOrderData(CN); //加载订单历史记录
            InitializeTextBoxes();
        }

        private void HomePage_Load(object sender, EventArgs e)
        {
            // ------ ------

            // ------ ------


        }

        private void InitializeTextBoxes()
        {
            // 将所有 TextBox 控件添加到列表中
            textBoxes.Add(商品名称);
            textBoxes.Add(商品描述);
            textBoxes.Add(父类别);
            textBoxes.Add(供应商名称);
            textBoxes.Add(商品单价);
            textBoxes.Add(供应商的名称);
            textBoxes.Add(联系人姓名);
            textBoxes.Add(联系邮箱);
            textBoxes.Add(联系电话);
            textBoxes.Add(地址);
            textBoxes.Add(产品目录);
            textBoxes.Add(商品的名称);
            textBoxes.Add(订单ID);
            textBoxes.Add(订单商品列表);
            textBoxes.Add(订单总金额);
            textBoxes.Add(收货地址);
            textBoxes.Add(账单地址);
            textBoxes.Add(支付方式);


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

            textBox.Enter += TextBox_Enter;
            textBox.Leave += TextBox_Leave;
        }
        private void TextBox_Enter(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            // 获取焦点时清空提示文本
            if (textBox.Text.StartsWith("请输入"))
            {
                textBox.Text = "";
                textBox.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void TextBox_Leave(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            // 失去焦点时显示提示文本
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "请输入" + textBox.Name;
                textBox.ForeColor = System.Drawing.Color.Gray;
            }
        }

        private void 新增商品ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 在这里处理菜单项的点击事件
            // 切换到TabControl中的指定TabPage
            tabControl1.SelectedTab = tabPage1;
        }

        private void 商品分类ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }

        private void 库存管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
        }

        private void 订单管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage4;
        }

        private void 供应商管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage5;
        }

        private void 商品查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage6;
        }

        private void 订单历史记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage7;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // 获取用户输入的商品信息
                string categoryName = 商品名称.Text;
                string categoryDescription = 商品描述.Text;
                int parentCategoryID = Convert.ToInt32(父类别.Text);
                int supplierID = Convert.ToInt32(供应商名称.Text);
                decimal productPrice = Convert.ToDecimal(商品单价.Text);


                // 插入商品信息的SQL语句
                string insertQuery = @"INSERT INTO CommodityInfo (CategoryName, CategoryDescription, ParentCategoryID, SupplierID, ProductPrice, CreateTime)
                                    VALUES (@CategoryName, @CategoryDescription, @ParentCategoryID, @SupplierID, @ProductPrice, @CreateTime)";


                // 创建命令对象
                using (cmd = new SqlCommand(insertQuery, CN))
                {
                    if (CN.State != ConnectionState.Open)
                    {
                        CN.Open();
                    }
                    // 添加参数
                    cmd.Parameters.AddWithValue("@CategoryName", categoryName);
                    cmd.Parameters.AddWithValue("@CategoryDescription", categoryDescription);
                    cmd.Parameters.AddWithValue("@ParentCategoryID", parentCategoryID);
                    cmd.Parameters.AddWithValue("@SupplierID", supplierID);
                    cmd.Parameters.AddWithValue("@ProductPrice", productPrice);
                    cmd.Parameters.AddWithValue("@CreateTime", DateTime.Now);

                    // 执行插入操作
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("商品信息添加成功！");
                }
            }
            catch (SqlException ex)
            {
                // SQL Server数据库相关错误
                MessageBox.Show($"数据库错误：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // 其他未知错误
                MessageBox.Show($"发生错误：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        // ------ 加载商品类别到ComboBox控件中 ------
        private void LoadCategories(SqlConnection CN)
        {
            try
            {
                // 查询商品类别
                insertQuery = "SELECT CategoryID, CategoryName FROM CommodityInfo";
                using (cmd = new SqlCommand(insertQuery, CN))
                {
                    if (CN.State != ConnectionState.Open)
                    {
                        CN.Open();
                    }
                    DA = new SqlDataAdapter(cmd);
                    dataTable = new DataTable();

                    DA.Fill(dataTable);

                    // 绑定库存信息到DataGridView
                    //dataGridView1.DataSource = dataTable;


                    // 绑定商品类别到ComboBox1
                    comboBox1.DisplayMember = "CategoryName";
                    comboBox1.ValueMember = "CategoryID";
                    comboBox1.DataSource = dataTable;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"商品类别发生错误：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void LoadCategories2(SqlConnection CN)
        {
            try
            {
                // 查询商品类别
                insertQuery = "SELECT CategoryID, CategoryName FROM CommodityInfo";
                using (cmd = new SqlCommand(insertQuery, CN))
                {
                    if (CN.State != ConnectionState.Open)
                    {
                        CN.Open();
                    }
                    DA = new SqlDataAdapter(cmd);
                    dataTable = new DataTable();

                    DA.Fill(dataTable);

                    // 绑定库存信息到DataGridView
                    //dataGridView1.DataSource = dataTable;


                    // 绑定商品类别到ComboBox2
                    comboBox2.DisplayMember = "CategoryName";
                    comboBox2.ValueMember = "CategoryID";
                    comboBox2.DataSource = dataTable;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"商品类别发生错误：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        // ------ 加载商品类别到ComboBox控件中 ------

        // ------ 切换ComboBox控件中Item选项，DataGripView显示相应商品库存信息 ------
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int selectedCategoryID = Convert.ToInt32(comboBox1.SelectedValue);

                // 查询库存信息
                insertQuery = "SELECT * FROM InventoryInfo WHERE CategoryID = @CategoryID";
                using (cmd = new SqlCommand(insertQuery, CN))
                {
                    if (CN.State != ConnectionState.Open)
                    {
                        CN.Open();
                    }
                    cmd.Parameters.AddWithValue("@CategoryID", selectedCategoryID);

                    DA = new SqlDataAdapter(cmd);
                    dataTable = new DataTable();
                    DA.Fill(dataTable);

                    // 绑定库存信息到DataGridView
                    dataGridView1.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"发生错误：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        // ------ 切换ComboBox控件中Item选项，DataGripView显示相应商品库存信息 ------

        // ------ 加载库存信息到DataGripView2控件中 ------
        private void LoadInventoryData(SqlConnection CN)
        {
            try
            {
                // 查询库存信息
                insertQuery = "SELECT * FROM InventoryInfo";
                using (cmd = new SqlCommand(insertQuery, CN))
                {
                    if (CN.State != ConnectionState.Open)
                    {
                        CN.Open();
                    }
                    DA = new SqlDataAdapter(cmd);
                    dataTable = new DataTable();
                    DA.Fill(dataTable);

                    // 绑定库存信息到DataGridView
                    dataGridView2.DataSource = dataTable;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"发生错误：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        // ------ 订单管理中的 订单提交功能
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedProductID = Convert.ToInt32(comboBox2.SelectedValue);

                // 检查库存是否足够
                if (!IsStockAvailable(selectedProductID, 1))
                {
                    MessageBox.Show("库存不足，无法完成订单。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                CN.Open();

                // 插入订单信息的SQL语句
                string insertQuery = @"INSERT INTO OrderInfo (UserID, OrderItemList, TotalAmount, OrderDate, ShippingAddress, BillingAddress, PaymentMethod, CreatedAt)
                                           VALUES (@UserID, @OrderItemList, @TotalAmount, @OrderDate, @ShippingAddress, @BillingAddress, @PaymentMethod, @CreatedAt)";

                // 创建命令对象
                using (SqlCommand cmd = new SqlCommand(insertQuery, CN))
                {
                    // 添加参数
                    cmd.Parameters.AddWithValue("@UserID", 1); // 替换为实际的用户ID
                    cmd.Parameters.AddWithValue("@OrderItemList", 订单商品列表.Text);
                    cmd.Parameters.AddWithValue("@TotalAmount", 订单总金额.Text);
                    cmd.Parameters.AddWithValue("@OrderDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@ShippingAddress", 收货地址.Text);
                    cmd.Parameters.AddWithValue("@BillingAddress", 账单地址.Text);
                    cmd.Parameters.AddWithValue("@PaymentMethod", 支付方式.Text);
                    cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);

                    // 执行插入操作
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("订单已成功下单！");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"发生错误：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsStockAvailable(int productID, int quantity)
        {
            // 查询库存信息


            string query = "SELECT StockQuantity FROM InventoryInfo WHERE CategoryID = @CategoryID";
            using (SqlCommand cmd = new SqlCommand(query, CN))
            {
                cmd.Parameters.AddWithValue("@CategoryID", productID);

                int stockQuantity = Convert.ToInt32(cmd.ExecuteScalar());

                return stockQuantity >= quantity;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                // 获取用户输入的供应商信息
                string companyName = 供应商的名称.Text;
                string contactPerson = 联系人姓名.Text;
                string contactEmail = 联系邮箱.Text;
                string contactPhone = 联系电话.Text;
                string address = 地址.Text;
                string productCatalog = 产品目录.Text;
                string paymentTerms = "EX";
                string deliveryTerms = "EX";
                string isActive = "EX";
                if (radioButton1.Checked)
                {
                    paymentTerms = radioButton1.Text;
                }
                else if (radioButton2.Checked)
                {
                    paymentTerms = radioButton2.Text;
                }
                else
                {
                    MessageBox.Show("请选择支付条件！");
                }

                if (radioButton3.Checked)
                {
                    deliveryTerms = radioButton3.Text;
                }
                else if (radioButton4.Checked)
                {
                    deliveryTerms = radioButton4.Text;
                }
                else
                {
                    MessageBox.Show("请选择交货条件！");
                }
                if (radioButton5.Checked)
                {
                    isActive = radioButton5.Text;
                }
                else if (radioButton6.Checked)
                {
                    isActive = radioButton6.Text;
                }
                else
                {
                    MessageBox.Show("请选择活跃状态！");
                }


                // 插入供应商信息的SQL语句
                insertQuery = @"INSERT INTO SupplierInfo (SupplierCompanyName, ContactPerson, ContactEmail, ContactPhone, Addr, ProductCatalog,
                                        CreatedAt, PaymentTerms, DeliveryTerms, IsActive)
                                        VALUES (@SupplierCompanyName, @ContactPerson, @ContactEmail, @ContactPhone, @Addr, @ProductCatalog,
                                        @CreatedAt, @PaymentTerms, @DeliveryTerms, @IsActive)";

                // 创建命令对象
                using (cmd = new SqlCommand(insertQuery, CN))
                {
                    if (CN.State != ConnectionState.Open)
                    {
                        CN.Open();
                    }
                    // 添加参数
                    cmd.Parameters.AddWithValue("@SupplierCompanyName", companyName);
                    cmd.Parameters.AddWithValue("@ContactPerson", contactPerson);
                    cmd.Parameters.AddWithValue("@ContactEmail", contactEmail);
                    cmd.Parameters.AddWithValue("@ContactPhone", contactPhone);
                    cmd.Parameters.AddWithValue("@Addr", address);
                    cmd.Parameters.AddWithValue("@ProductCatalog", productCatalog);
                    cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                    cmd.Parameters.AddWithValue("@PaymentTerms", paymentTerms);
                    cmd.Parameters.AddWithValue("@DeliveryTerms", deliveryTerms);
                    cmd.Parameters.AddWithValue("@IsActive", isActive);

                    // 执行插入操作
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("供应商信息已成功添加！");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"发生错误：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void LoadSupplierData(SqlConnection CN)
        {
            try
            {

                // 查询供应商信息
                string query = "SELECT * FROM SupplierInfo";
                using (cmd = new SqlCommand(query, CN))
                {
                    if (CN.State != ConnectionState.Open)
                    {
                        CN.Open();
                    }

                    DA = new SqlDataAdapter(cmd);
                    dataTable = new DataTable();
                    DA.Fill(dataTable);

                    // 绑定供应商信息到DataGridView
                    dataGridView3.DataSource = dataTable;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"发生错误：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void button4_Click(object sender, EventArgs e)
        {
            string productName = 商品的名称.Text.Trim();

            if (!string.IsNullOrEmpty(productName))
            {
                try
                {
                    // 根据商品名称查询商品信息
                    string query = "SELECT * FROM CommodityInfo WHERE CategoryName LIKE @ProductName";
                    using (cmd = new SqlCommand(query, CN))
                    {
                        cmd.Parameters.AddWithValue("@ProductName", $"%{productName}%");
                        if (CN.State != ConnectionState.Open)
                        {
                            CN.Open();
                        }

                        DA.SelectCommand = cmd;
                        dataTable.Clear(); // 清除之前的数据
                        DA.Fill(dataTable);
                        dataGridView4.DataSource = dataTable;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"查询商品信息错误：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (CN.State == ConnectionState.Open)
                    {
                        CN.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("请输入商品名称进行查询！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void LoadOrderData(SqlConnection CN)
        {
            try
            {
                // 查询所有订单信息
                string query = "SELECT * FROM OrderInfo";
                using (cmd = new SqlCommand(query, CN))
                {
                    if (CN.State != ConnectionState.Open)
                    {
                        CN.Open();
                    }
                    DA.SelectCommand = cmd;
                    DA.Fill(dataTable);
                    dataGridView5.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"加载订单信息错误：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (CN.State == ConnectionState.Open)
                {
                    CN.Close();
                }
            }
        }

        private void SearchOrder()
        {
            try
            {
                int orderIdToSearch = int.Parse(订单ID.Text); // 获取输入的订单ID

                // 查询订单信息
                string query = $"SELECT * FROM OrderInfo WHERE OrderID = {orderIdToSearch}";
                using (cmd = new SqlCommand(query, CN))
                {
                    if (CN.State != ConnectionState.Open)
                    {
                        CN.Open();
                    }

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        // 读取订单信息
                        string orderDetails = $"OrderID: {reader["OrderID"]}\n" +
                                              $"UserID: {reader["UserID"]}\n" +
                                              $"TotalAmount: {reader["TotalAmount"]}\n" +
                                              $"OrderDate: {reader["OrderDate"]}\n" +
                                              $"ShipmentStatus: {reader["ShipmentStatus"]}";

                        // 显示订单信息
                        MessageBox.Show(orderDetails, "订单信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("未找到订单信息", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"查询订单信息错误：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (CN.State == ConnectionState.Open)
                {
                    CN.Close();
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SearchOrder(); //查询订单信息
        }


    }
}

