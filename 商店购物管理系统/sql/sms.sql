-- 判断数据库是否存在
IF EXISTS (SELECT * FROM sys.databases WHERE name = '商店购物管理系统数据库')
BEGIN
    -- 断开连接
    ALTER DATABASE 商店购物管理系统数据库 SET SINGLE_USER WITH ROLLBACK IMMEDIATE;

    -- 删除数据库
    DROP DATABASE 商店购物管理系统数据库;
END

-- 创建数据库：商店购物管理系统
CREATE DATABASE 商店购物管理系统数据库
ON
(
    NAME = 'shopping_management_system_data',
    FILENAME = 'K:\SSMS\sql\sms.mdf',
    SIZE = 10MB,
    MAXSIZE = 100MB,
    FILEGROWTH = 10%
)
LOG ON
(
    NAME = 'shopping_management_system_log',
    FILENAME = 'K:\SSMS\sql\sms.ldf',
    SIZE = 1MB,
    MAXSIZE = 20MB,
    FILEGROWTH = 10%
);
GO

USE 商店购物管理系统数据库;
GO

-- 初始化表
IF OBJECT_ID('dbo.CommodityInfo', 'U') IS NOT NULL
    DROP TABLE dbo.CommodityInfo;

IF OBJECT_ID('CommodityInfo', 'U') IS NOT NULL
    DROP TABLE CommodityInfo;

IF OBJECT_ID('InventoryInfo', 'U') IS NOT NULL
    DROP TABLE InventoryInfo;

IF OBJECT_ID('UserInfo', 'U') IS NOT NULL
    DROP TABLE UserInfo;

IF OBJECT_ID('SupplierInfo', 'U') IS NOT NULL
    DROP TABLE SupplierInfo;

IF OBJECT_ID('OrderInfo', 'U') IS NOT NULL
    DROP TABLE OrderInfo;

-- 如果存在外键，则删掉
-- 如果存在库存信息表的外键约束，则删除
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS WHERE CONSTRAINT_NAME = 'FK_Inv_Com')
BEGIN
    ALTER TABLE InventoryInfo
    DROP CONSTRAINT FK_Inv_Com;
END

-- 如果存在订单信息表的外键约束，则删除
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS WHERE CONSTRAINT_NAME = 'FK_Ord_Usr')
BEGIN
    ALTER TABLE OrderInfo
    DROP CONSTRAINT FK_Ord_Usr;
END


-- 创建商品信息表
CREATE TABLE CommodityInfo (
    CategoryID INT PRIMARY KEY,	-- 商品类别ID
    CategoryName NVARCHAR(10) NOT NULL,
    CategoryDescription TEXT,
    ParentCategoryID INT,	-- 父商品类别ID
    SupplierID INT,			-- 供应商ID
    ProductPrice DECIMAL(10, 2) NOT NULL,
	CreateTime DATETIME,
	UpgradeTime DATETIME DEFAULT CURRENT_TIMESTAMP
);

-- 创建库存信息表
CREATE TABLE InventoryInfo (
    InventoryProductID INT PRIMARY KEY,		-- 库存商品ID
    CategoryID INT NOT NULL,				-- 商品类别ID
    StorageLocation NVARCHAR(30),
    StockQuantity INT,
    StockStatus NVARCHAR(4) CHECK (StockStatus IN ('正常', '即将过期', '已过期')),
    CreatedAt DATETIME,
    UpdatedAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    ExpiryDate DATETIME,	--过期时间
    Descr TEXT			-- 描述
);

-- 创建用户信息表
CREATE TABLE UserInfo (
    UserID INT IDENTITY(1,1) PRIMARY KEY,	-- 用户ID
    Username NVARCHAR(10) NOT NULL,	-- 用户名
    Pass_word VARCHAR(30) NOT NULL,
    FullName NVARCHAR(10),	-- 姓名
    Email VARCHAR(30),
    Addr VARCHAR(30),
    PhoneNumber VARCHAR(20)	-- 电话号码
);

-- 创建供应商信息表
CREATE TABLE SupplierInfo (
    SupplierID INT PRIMARY KEY,	-- 供应商ID
    SupplierCompanyName VARCHAR(50) NOT NULL,
    ContactPerson NVARCHAR(10),
    ContactEmail VARCHAR(30),
    ContactPhone VARCHAR(20),	-- 电话号码
    Addr VARCHAR(30),
    ProductCatalog Text,	-- 产品目录
    CreatedAt DATETIME,
    UpdatedAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    PaymentTerms VARCHAR(50) CHECK(PaymentTerms IN ('AdvancePay', 'NetCash')),	-- 支付条件（预付款，净现金）
    DeliveryTerms VARCHAR(50) CHECK(DeliveryTerms IN ('EXW', 'CIP')),	-- 交货条件（EXW (Ex Works)， CIP (Carriage and Insurance Paid)）
    IsActive VARCHAR(10) CHECK(IsActive IN ('Active', 'Inactive'))		-- 活跃状态
);

-- 创建订单信息表
CREATE TABLE OrderInfo (
    OrderID INT PRIMARY KEY,	-- 订单ID
    UserID INT,		-- 用户ID
    OrderItemList TEXT, -- 订单商品列表
    TotalAmount DECIMAL(10, 2) NOT NULL,
    OrderDate DATETIME,	-- 订单日期
    ShipmentDate DATETIME,	-- 发货日期
    PaymentStatus VARCHAR(20),	-- 支付状态
    ShipmentStatus VARCHAR(20), -- 发货状态
    ShippingAddress VARCHAR(30),	-- 收获地址
    BillingAddress VARCHAR(30),	-- 账单地址
    PaymentMethod VARCHAR(30), -- 支付方式
    CreatedAt DATETIME,
    UpdatedAt DATETIME DEFAULT CURRENT_TIMESTAMP
);

-- 创建外键约束
-- 库存信息表-商品信息表
ALTER TABLE InventoryInfo
ADD CONSTRAINT FK_Inv_Com
FOREIGN KEY (CategoryID)
REFERENCES CommodityInfo(CategoryID);

-- 订单信息表-用户信息表
ALTER TABLE OrderInfo
ADD CONSTRAINT FK_Ord_Usr
FOREIGN KEY (UserID)
REFERENCES UserInfo(UserID);

SELECT CategoryID, CategoryName FROM CommodityInfo