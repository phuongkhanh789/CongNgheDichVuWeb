create table orders(
	order_code char(8) PRIMARY KEY,
	cust_code char(6),
	emp_code char(7),
	order_request datetime,
	order_promise datetime,
	cust_address nvarchar(200)
)
insert into orders(order_code,cust_code,emp_code,order_request,order_promise,cust_address) values
('UR.54117','AD.001','CS.0456','2023-07-12','2023-07-14',N'85/13 Âu Cơ, F.Tân Sợ Nhì, Q.Tân Phú'),
('UR.54118','AD.002','CS.0489','2023-07-13','2023-07-15',N'256A CMT8, F.10, Q.3'),
('UR.54119','AD.003','CS.0656','2023-07-14','2023-07-16',N'223B Nguyễn Trọng Tuyển, F.8, Q.Phú Nhuận'),
('FR.55111','NI.877','OE.987','2023-07-15','2023-07-17',N'135B Trần Hưng Đạo, Q.1'),
('FR.55112','NI.878','OE.986','2023-07-16','2023-07-18',N'123 Lạc Long Quân,F.3, Q.11'),
('FR.55113','NI.879','OE.985','2023-07-17','2023-07-19',N'21/5 Lý Chính Thắng, F.8, Q.3'),
('FR.55114','NI.880','CS.023','2023-07-18','2023-07-20',N'289 Nguyễn Đình Chiểu, Q.3'),
('KH.56111','UA.523','CS.024','2023-07-19','2023-07-21',N'A75 KP2, F.Phú Nhuận, Q.7');
select * from orders