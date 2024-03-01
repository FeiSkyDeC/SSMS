-- �ж����ݿ��Ƿ����
IF EXISTS (SELECT * FROM sys.databases WHERE name = '�̵깺�����ϵͳ���ݿ�')
BEGIN
    -- �Ͽ�����
    ALTER DATABASE �̵깺�����ϵͳ���ݿ� SET SINGLE_USER WITH ROLLBACK IMMEDIATE;

    -- ɾ�����ݿ�
    DROP DATABASE �̵깺�����ϵͳ���ݿ�;
END

-- �������ݿ⣺�̵깺�����ϵͳ
CREATE DATABASE �̵깺�����ϵͳ���ݿ�
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

USE �̵깺�����ϵͳ���ݿ�;
GO

-- ��ʼ����
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

-- ��������������ɾ��
-- ������ڿ����Ϣ������Լ������ɾ��
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS WHERE CONSTRAINT_NAME = 'FK_Inv_Com')
BEGIN
    ALTER TABLE InventoryInfo
    DROP CONSTRAINT FK_Inv_Com;
END

-- ������ڶ�����Ϣ������Լ������ɾ��
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS WHERE CONSTRAINT_NAME = 'FK_Ord_Usr')
BEGIN
    ALTER TABLE OrderInfo
    DROP CONSTRAINT FK_Ord_Usr;
END


-- ������Ʒ��Ϣ��
CREATE TABLE CommodityInfo (
    CategoryID INT PRIMARY KEY,	-- ��Ʒ���ID
    CategoryName NVARCHAR(10) NOT NULL,
    CategoryDescription TEXT,
    ParentCategoryID INT,	-- ����Ʒ���ID
    SupplierID INT,			-- ��Ӧ��ID
    ProductPrice DECIMAL(10, 2) NOT NULL,
	CreateTime DATETIME,
	UpgradeTime DATETIME DEFAULT CURRENT_TIMESTAMP
);

-- ���������Ϣ��
CREATE TABLE InventoryInfo (
    InventoryProductID INT PRIMARY KEY,		-- �����ƷID
    CategoryID INT NOT NULL,				-- ��Ʒ���ID
    StorageLocation NVARCHAR(30),
    StockQuantity INT,
    StockStatus NVARCHAR(4) CHECK (StockStatus IN ('����', '��������', '�ѹ���')),
    CreatedAt DATETIME,
    UpdatedAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    ExpiryDate DATETIME,	--����ʱ��
    Descr TEXT			-- ����
);

-- �����û���Ϣ��
CREATE TABLE UserInfo (
    UserID INT IDENTITY(1,1) PRIMARY KEY,	-- �û�ID
    Username NVARCHAR(10) NOT NULL,	-- �û���
    Pass_word VARCHAR(30) NOT NULL,
    FullName NVARCHAR(10),	-- ����
    Email VARCHAR(30),
    Addr VARCHAR(30),
    PhoneNumber VARCHAR(20)	-- �绰����
);

-- ������Ӧ����Ϣ��
CREATE TABLE SupplierInfo (
    SupplierID INT PRIMARY KEY,	-- ��Ӧ��ID
    SupplierCompanyName VARCHAR(50) NOT NULL,
    ContactPerson NVARCHAR(10),
    ContactEmail VARCHAR(30),
    ContactPhone VARCHAR(20),	-- �绰����
    Addr VARCHAR(30),
    ProductCatalog Text,	-- ��ƷĿ¼
    CreatedAt DATETIME,
    UpdatedAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    PaymentTerms VARCHAR(50) CHECK(PaymentTerms IN ('AdvancePay', 'NetCash')),	-- ֧��������Ԥ������ֽ�
    DeliveryTerms VARCHAR(50) CHECK(DeliveryTerms IN ('EXW', 'CIP')),	-- ����������EXW (Ex Works)�� CIP (Carriage and Insurance Paid)��
    IsActive VARCHAR(10) CHECK(IsActive IN ('Active', 'Inactive'))		-- ��Ծ״̬
);

-- ����������Ϣ��
CREATE TABLE OrderInfo (
    OrderID INT PRIMARY KEY,	-- ����ID
    UserID INT,		-- �û�ID
    OrderItemList TEXT, -- ������Ʒ�б�
    TotalAmount DECIMAL(10, 2) NOT NULL,
    OrderDate DATETIME,	-- ��������
    ShipmentDate DATETIME,	-- ��������
    PaymentStatus VARCHAR(20),	-- ֧��״̬
    ShipmentStatus VARCHAR(20), -- ����״̬
    ShippingAddress VARCHAR(30),	-- �ջ��ַ
    BillingAddress VARCHAR(30),	-- �˵���ַ
    PaymentMethod VARCHAR(30), -- ֧����ʽ
    CreatedAt DATETIME,
    UpdatedAt DATETIME DEFAULT CURRENT_TIMESTAMP
);

-- �������Լ��
-- �����Ϣ��-��Ʒ��Ϣ��
ALTER TABLE InventoryInfo
ADD CONSTRAINT FK_Inv_Com
FOREIGN KEY (CategoryID)
REFERENCES CommodityInfo(CategoryID);

-- ������Ϣ��-�û���Ϣ��
ALTER TABLE OrderInfo
ADD CONSTRAINT FK_Ord_Usr
FOREIGN KEY (UserID)
REFERENCES UserInfo(UserID);

SELECT CategoryID, CategoryName FROM CommodityInfo