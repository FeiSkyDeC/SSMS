--
-- ʹ��chatgpt������������
--

USE �̵깺�����ϵͳ���ݿ�;
GO

-- ��Ʒ��Ϣ�����ݣ�20����
INSERT INTO CommodityInfo (CategoryID, CategoryName, CategoryDescription, ParentCategoryID, SupplierID, ProductPrice, CreateTime)
VALUES
(1, '���Ӳ�Ʒ', '�����ֻ������Ե�', NULL, 101, 899.99, '2023-01-01'),
(2, '�ҵ�', '�������䡢ϴ�»���', NULL, 102, 1299.99, '2023-01-02'),
(3, '��װ', '������װ��Ůװ��', NULL, 103, 49.99, '2023-01-03'),
(4, '�ֻ�', '����Ʒ�ƺ��ͺ�', 1, 101, 699.99, '2023-01-04'),
(5, '�ʼǱ�����', '�ᱡ��Я', 1, 102, 1499.99, '2023-01-05'),
(6, '����', '���ֳߴ���ͺ�', 2, 103, 799.99, '2023-01-06'),
(7, 'ϴ�»�', 'ǰ��ʽ������ʽ', 2, 101, 899.99, '2023-01-07'),
(8, '��װ', '���ֿ�ʽ', 3, 102, 29.99, '2023-01-08'),
(9, 'Ůװ', '���ַ��', 3, 103, 39.99, '2023-01-09'),
(10, '����', '���ʽ��ͷ��ʽ', 4, 101, 49.99, '2023-01-10'),
(11, 'ƽ�����', '���ֳߴ�͹���', 4, 102, 399.99, '2023-01-11'),
(12, '�յ�', '����ʽ����ʽ', 2, 103, 999.99, '2023-01-12'),
(13, '����', 'Һ����LED��OLED', 2, 101, 799.99, '2023-01-13'),
(14, '����', '��ů��ʽ', 9, 102, 59.99, '2023-01-14'),
(15, 'ȹ��', '���ֳ��ȺͿ�ʽ', 9, 103, 49.99, '2023-01-15'),
(16, '�˶�Ь', '�ܲ�Ь������Ь', 9, 101, 79.99, '2023-01-16'),
(17, '���', '������΢��', 4, 102, 899.99, '2023-01-17'),
(18, '�ֱ�', '�����ֱ���е�ֱ�', 4, 103, 199.99, '2023-01-18'),
(19, '�Ҿ�', 'ɳ������������', NULL, 101, 499.99, '2023-01-19'),
(20, '���', '��ͯ���', NULL, 102, 19.99, '2023-01-20');

-- ��������Ϣ
INSERT INTO InventoryInfo (InventoryProductID, CategoryID, StorageLocation, StockQuantity, StockStatus, CreatedAt, ExpiryDate, Descr)
VALUES
(1, 1, '�ֿ�A', 100, '����', '2023-01-01', '2023-12-31', '���Ӳ�Ʒ�洢'),
(2, 2, '�ֿ�B', 50, '����', '2023-01-02', '2023-12-31', '�ҵ�洢'),
(3, 3, '�ֿ�C', 200, '����', '2023-01-03', '2023-12-31', '��װ�洢'),
(4, 4, '�ֿ�D', 80, '��������', '2023-01-04', '2023-06-30', '�ֻ��洢'),
(5, 5, '�ֿ�E', 30, '����', '2023-01-05', '2023-12-31', '�ʼǱ����Դ洢'),
(6, 6, '�ֿ�F', 40, '�ѹ���', '2023-01-06', '2022-12-31', '����洢'),
(7, 7, '�ֿ�G', 60, '����', '2023-01-07', '2023-12-31', 'ϴ�»��洢'),
(8, 8, '�ֿ�H', 150, '����', '2023-01-08', '2023-12-31', '��װ�洢'),
(9, 9, '�ֿ�I', 120, '��������', '2023-01-09', '2023-06-30', 'Ůװ�洢'),
(10, 10, '�ֿ�J', 90, '����', '2023-01-10', '2023-12-31', '�����洢'),
(11, 11, '�ֿ�K', 20, '����', '2023-01-11', '2023-12-31', 'ƽ����Դ洢'),
(12, 12, '�ֿ�L', 70, '��������', '2023-01-12', '2023-06-30', '�յ��洢'),
(13, 13, '�ֿ�M', 110, '����', '2023-01-13', '2023-12-31', '���Ӵ洢'),
(14, 14, '�ֿ�N', 25, '����', '2023-01-14', '2023-12-31', '���״洢'),
(15, 15, '�ֿ�O', 35, '����', '2023-01-15', '2023-12-31', 'ȹ�Ӵ洢'),
(16, 16, '�ֿ�P', 50, '����', '2023-01-16', '2023-12-31', '�˶�Ь�洢'),
(17, 17, '�ֿ�Q', 15, '����', '2023-01-17', '2023-12-31', '����洢'),
(18, 18, '�ֿ�R', 30, '��������', '2023-01-18', '2023-06-30', '�ֱ�洢'),
(19, 19, '�ֿ�S', 85, '����', '2023-01-19', '2023-12-31', '�Ҿߴ洢'),
(20, 20, '�ֿ�T', 40, '����', '2023-01-20', '2023-12-31', '��ߴ洢');

-- �����û���Ϣ
-- �����û���Ϣ
INSERT INTO UserInfo (Username, Pass_word, FullName, Email, Addr, PhoneNumber)
VALUES
('user1', 'password1', 'John D', 'john.doe@example.com', '123 Main St', '555-1234'),
('user2', 'password2', 'Jane S', 'jane.smith@example.com', '456 Oak Ave', '555-5678'),
('user3', 'password3', 'Bob J', 'bob.johnson@example.com', '789 Elm St', '555-9876'),
('user4', 'password4', 'Alice B', 'alice.brown@example.com', '101 Pine St', '555-4321'),
('user5', 'password5', 'Charlie W', 'charlie.white@example.com', '202 Maple Dr', '555-8765'),
('user6', 'password6', 'Emily D', 'emily.davis@example.com', '303 Cedar Ln', '555-2109'),
('user7', 'password7', 'David L', 'david.lee@example.com', '404 Birch Rd', '555-6543'),
('user8', 'password8', 'Grace C', 'grace.clark@example.com', '505 Oak St', '555-1098'),
('user9', 'password9', 'Henry T', 'henry.turner@example.com', '606 Elm Ave', '555-5432'),
('user10', 'password10', 'Olivia A', 'olivia.adams@example.com', '707 Pine Pl', '555-2109'),
('user11', 'password11', 'Mia W', 'mia.walker@example.com', '808 Maple Ct', '555-9876'),
('user12', 'password12', 'Jack M', 'jack.martinez@example.com', '909 Cedar Dr', '555-6543'),
('user13', 'password13', 'Ava H', 'ava.harris@example.com', '1010 Birch St', '555-1234'),
('user14', 'password14', 'Logan H', 'logan.hill@example.com', '1111 Oak Ave', '555-8765'),
('user15', 'password15', 'Ella S', 'ella.smith@example.com', '1212 Elm Rd', '555-4321'),
('user16', 'password16', 'Noah W', 'noah.white@example.com', '1313 Pine Ln', '555-1098'),
('user17', 'password17', 'Sophia D', 'sophia.davis@example.com', '1414 Maple Pl', '555-6543'),
('user18', 'password18', 'Liam L', 'liam.lee@example.com', '1515 Cedar Ct', '555-9876'),
('user19', 'password19', 'Emma C', 'emma.clark@example.com', '1616 Birch Dr', '555-1234'),
('user20', 'password20', 'Jackson T', 'jackson.turner@example.com', '1717 Oak St', '555-8765');

-- ���빩Ӧ����Ϣ
INSERT INTO SupplierInfo (SupplierID, SupplierCompanyName, ContactPerson, ContactEmail, ContactPhone, Addr, ProductCatalog, CreatedAt, UpdatedAt, PaymentTerms, DeliveryTerms, IsActive)
VALUES
(1, 'Supplier1 Co.', 'Tom', 'tom.supplier@example.com', '555-1111', '789 Elm St', 'Electronics, Appliances', '2023-01-01', CURRENT_TIMESTAMP, 'AdvancePay', 'EXW', 'Active'),
(2, 'Supplier2 Co.', 'Alice', 'alice.supplier@example.com', '555-2222', '101 Pine St', 'Appliances, Clothing', '2023-01-02', CURRENT_TIMESTAMP, 'NetCash', 'CIP', 'Active'),
(3, 'Supplier3 Co.', 'Bob', 'bob.supplier@example.com', '555-3333', '202 Oak Ave', 'Clothing, Accessories', '2023-01-03', CURRENT_TIMESTAMP, 'AdvancePay', 'EXW', 'Inactive'),
(4, 'Supplier4 Co.', 'Emma', 'emma.supplier@example.com', '555-4444', '303 Cedar Dr', 'Toys, Games', '2023-01-04', CURRENT_TIMESTAMP, 'NetCash', 'CIP', 'Active'),
(5, 'Supplier5 Co.', 'Jack', 'jack.supplier@example.com', '555-5555', '404 Pine St', 'Furniture, Home Decor', '2023-01-05', CURRENT_TIMESTAMP, 'AdvancePay', 'EXW', 'Active'),
(6, 'Supplier6 Co.', 'Sophia', 'sophia.supplier@example.com', '555-6666', '505 Elm Rd', 'Electronics, Appliances', '2023-01-06', CURRENT_TIMESTAMP, 'NetCash', 'CIP', 'Inactive'),
(7, 'Supplier7 Co.', 'Noah', 'noah.supplier@example.com', '555-7777', '606 Maple Dr', 'Clothing, Accessories', '2023-01-07', CURRENT_TIMESTAMP, 'AdvancePay', 'EXW', 'Active'),
(8, 'Supplier8 Co.', 'Ava', 'ava.supplier@example.com', '555-8888', '707 Oak St', 'Toys, Games', '2023-01-08', CURRENT_TIMESTAMP, 'NetCash', 'CIP', 'Active'),
(9, 'Supplier9 Co.', 'Liam', 'liam.supplier@example.com', '555-9999', '808 Pine Ave', 'Furniture, Home Decor', '2023-01-09', CURRENT_TIMESTAMP, 'AdvancePay', 'EXW', 'Active'),
(10, 'Supplier10 Co.', 'Olivia', 'olivia.supplier@example.com', '555-0000', '909 Elm St', 'Electronics, Appliances', '2023-01-10', CURRENT_TIMESTAMP, 'NetCash', 'CIP', 'Active'),
(11, 'Supplier11 Co.', 'Lucas', 'lucas.supplier@example.com', '555-1111', '101 Pine Pl', 'Clothing, Accessories', '2023-01-11', CURRENT_TIMESTAMP, 'AdvancePay', 'EXW', 'Active'),
(12, 'Supplier12 Co.', 'Ella', 'ella.supplier@example.com', '555-2222', '202 Cedar Ln', 'Toys, Games', '2023-01-12', CURRENT_TIMESTAMP, 'NetCash', 'CIP', 'Inactive'),
(13, 'Supplier13 Co.', 'Mia', 'mia.supplier@example.com', '555-3333', '303 Birch Rd', 'Furniture, Home Decor', '2023-01-13', CURRENT_TIMESTAMP, 'AdvancePay', 'EXW', 'Active'),
(14, 'Supplier14 Co.', 'Liam', 'liam.supplier@example.com', '555-4444', '404 Oak Ave', 'Electronics, Appliances', '2023-01-14', CURRENT_TIMESTAMP, 'NetCash', 'CIP', 'Active'),
(15, 'Supplier15 Co.', 'Aria', 'aria.supplier@example.com', '555-5555', '505 Maple Dr', 'Clothing, Accessories', '2023-01-15', CURRENT_TIMESTAMP, 'AdvancePay', 'EXW', 'Active'),
(16, 'Supplier16 Co.', 'Jackson', 'jackson.supplier@example.com', '555-6666', '606 Cedar Dr', 'Toys, Games', '2023-01-16', CURRENT_TIMESTAMP, 'NetCash', 'CIP', 'Inactive'),
(17, 'Supplier17 Co.', 'Ava', 'ava.supplier@example.com', '555-7777', '707 Birch Rd', 'Furniture, Home Decor', '2023-01-17', CURRENT_TIMESTAMP, 'AdvancePay', 'EXW', 'Active'),
(18, 'Supplier18 Co.', 'Ethan', 'ethan.supplier@example.com', '555-8888', '808 Oak St', 'Electronics, Appliances', '2023-01-18', CURRENT_TIMESTAMP, 'NetCash', 'CIP', 'Active'),
(19, 'Supplier19 Co.', 'Madison', 'madison.supplier@example.com', '555-9999', '909 Pine Ave', 'Clothing, Accessories', '2023-01-19', CURRENT_TIMESTAMP, 'AdvancePay', 'EXW', 'Active'),
(20, 'Supplier20 Co.', 'Mason', 'mason.supplier@example.com', '555-0000', '101 Elm St', 'Toys, Games', '2023-01-20', CURRENT_TIMESTAMP, 'NetCash', 'CIP', 'Active');

-- ���붩����Ϣ
INSERT INTO OrderInfo (OrderID, UserID, OrderItemList, TotalAmount, OrderDate, ShipmentDate, PaymentStatus, ShipmentStatus, ShippingAddress, BillingAddress, PaymentMethod, CreatedAt, UpdatedAt)
VALUES
(1, 1, 'Product1, Product2', 150.00, '2023-01-01 10:00:00', '2023-01-02 12:00:00', 'Paid', 'Shipped', '123 Main St', '123 Main St', 'Credit Card', '2023-01-01 08:00:00', CURRENT_TIMESTAMP),
(2, 2, 'Product3, Product4', 200.50, '2023-01-02 09:30:00', '2023-01-03 11:30:00', 'Pending', 'Processing', '456 Oak Ave', '456 Oak Ave', 'PayPal', '2023-01-02 07:45:00', CURRENT_TIMESTAMP),
(3, 3, 'Product5, Product6', 75.25, '2023-01-03 14:15:00', NULL, 'Paid', 'Not Shipped', '789 Pine St', '789 Pine St', 'Cash on Delivery', '2023-01-03 12:30:00', CURRENT_TIMESTAMP),
(4, 4, 'Product7, Product8', 120.75, '2023-01-04 11:45:00', '2023-01-05 13:45:00', 'Paid', 'Shipped', '101 Elm Rd', '101 Elm Rd', 'Credit Card', '2023-01-04 10:00:00', CURRENT_TIMESTAMP),
(5, 5, 'Product9, Product10', 90.00, '2023-01-05 10:30:00', '2023-01-06 12:30:00', 'Pending', 'Processing', '202 Maple Dr', '202 Maple Dr', 'PayPal', '2023-01-05 09:15:00', CURRENT_TIMESTAMP),
(6, 6, 'Product11, Product12', 180.50, '2023-01-06 13:45:00', '2023-01-07 15:30:00', 'Paid', 'Shipped', '303 Birch Rd', '303 Birch Rd', 'Cash on Delivery', '2023-01-06 12:00:00', CURRENT_TIMESTAMP),
(7, 7, 'Product13, Product14', 220.25, '2023-01-07 16:00:00', NULL, 'Pending', 'Not Shipped', '404 Pine Ave', '404 Pine Ave', 'Credit Card', '2023-01-07 14:30:00', CURRENT_TIMESTAMP),
(8, 8, 'Product15, Product16', 130.75, '2023-01-08 09:45:00', '2023-01-09 11:45:00', 'Paid', 'Shipped', '505 Cedar Dr', '505 Cedar Dr', 'PayPal', '2023-01-08 08:00:00', CURRENT_TIMESTAMP),
(9, 9, 'Product17, Product18', 95.00, '2023-01-09 14:30:00', '2023-01-10 16:30:00', 'Pending', 'Processing', '606 Oak St', '606 Oak St', 'Cash on Delivery', '2023-01-09 13:15:00', CURRENT_TIMESTAMP),
(10, 10, 'Product19, Product20', 75.25, '2023-01-10 11:15:00', '2023-01-11 13:15:00', 'Paid', 'Shipped', '707 Elm St', '707 Elm St', 'Credit Card', '2023-01-10 10:00:00', CURRENT_TIMESTAMP),
(11, 11, 'Product21, Product22', 140.50, '2023-01-11 14:45:00', NULL, 'Paid', 'Not Shipped', '808 Pine Ave', '808 Pine Ave', 'PayPal', '2023-01-11 13:00:00', CURRENT_TIMESTAMP),
(12, 12, 'Product23, Product24', 110.25, '2023-01-12 10:30:00', '2023-01-13 12:30:00', 'Pending', 'Processing', '909 Maple Dr', '909 Maple Dr', 'Cash on Delivery', '2023-01-12 09:15:00', CURRENT_TIMESTAMP),
(13, 13, 'Product25, Product26', 160.75, '2023-01-13 15:45:00', '2023-01-14 17:45:00', 'Paid', 'Shipped', '101 Pine St', '101 Pine St', 'Credit Card', '2023-01-13 14:00:00', CURRENT_TIMESTAMP),
(14, 14, 'Product27, Product28', 200.00, '2023-01-14 11:30:00', '2023-01-15 13:30:00', 'Pending', 'Processing', '202 Oak Ave', '202 Oak Ave', 'PayPal', '2023-01-14 10:15:00', CURRENT_TIMESTAMP),
(15, 15, 'Product29, Product30', 90.50, '2023-01-15 14:00:00', '2023-01-16 16:00:00', 'Paid', 'Shipped', '303 Elm Rd', '303 Elm Rd', 'Cash on Delivery', '2023-01-15 12:15:00', CURRENT_TIMESTAMP),
(16, 16, 'Product31, Product32', 120.25, '2023-01-16 09:45:00', NULL, 'Paid', 'Not Shipped', '404 Cedar Dr', '404 Cedar Dr', 'Credit Card', '2023-01-16 08:00:00', CURRENT_TIMESTAMP),
(17, 17, 'Product33, Product34', 180.75, '2023-01-17 14:30:00', '2023-01-18 16:30:00', 'Pending', 'Processing', '505 Maple Dr', '505 Maple Dr', 'PayPal', '2023-01-17 13:15:00', CURRENT_TIMESTAMP),
(18, 18, 'Product35, Product36', 95.00, '2023-01-18 11:15:00', '2023-01-19 13:15:00', 'Paid', 'Shipped', '606 Cedar Dr', '606 Cedar Dr', 'Cash on Delivery', '2023-01-18 10:00:00', CURRENT_TIMESTAMP),
(19, 19, 'Product37, Product38', 130.50, '2023-01-19 15:45:00', '2023-01-20 17:45:00', 'Pending', 'Not Shipped', '707 Pine Ave', '707 Pine Ave', 'Credit Card', '2023-01-19 14:00:00', CURRENT_TIMESTAMP),
(20, 20, 'Product39, Product40', 110.25, '2023-01-20 10:30:00', '2023-01-21 12:30:00', 'Paid', 'Shipped', '808 Elm St', '808 Elm St', 'PayPal', '2023-01-20 09:15:00', CURRENT_TIMESTAMP);
