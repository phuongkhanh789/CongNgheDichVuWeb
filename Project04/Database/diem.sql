CREATE TABLE Lop (
    MaLop NVARCHAR (10) PRIMARY KEY,
    TenLop NVARCHAR(80)   
);

CREATE TABLE SinhVien(
	MaSV NVARCHAR(8) PRIMARY KEY,
	HoTen NVARCHAR(80),
	NgaySinh DATETIME,
	GioiTinh INT,
	DiaChi NVARCHAR(300),
	SoDT VARCHAR(10),
	MaLop NVARCHAR (10)
	constraint FK_SinhVien_MaLop foreign key (MaLop) references Lop(MaLop)
);

CREATE TABLE MonHoc (
    MaMH NVARCHAR(10) PRIMARY KEY,
    TenMH NVARCHAR(50),
    SoTiet INT,
    TenGV NVARCHAR(80),
	HocKy NVARCHAR (8),
	MaLop NVARCHAR (10)
	FOREIGN KEY (MaLop) REFERENCES Lop(MaLop)
);

CREATE TABLE Diem (
	MaSV NVARCHAR(8),
	MaMH NVARCHAR(10),
	Diem Float,
	HocLuc NVARCHAR(8) null,
	PRIMARY KEY (MaSV, MaMH),
	FOREIGN KEY (MaSV) REFERENCES SinhVien(MaSV),
	FOREIGN KEY (MaMH) REFERENCES MonHoc(MaMH)
);

INSERT INTO Lop (MaLop, TenLop) VALUES
    ('22C2B-LTM1', N'Lớp lập trình máy'),
    ('23C1A-QTM1', N'Lớp quản trị mạng'),
	('23C1A-TKW1', N'Lớp thiết kế web'),
    ('23T4A-ANM1', N'Lớp an ninh mạng');

INSERT INTO SinhVien (MaSV, HoTen, NgaySinh, GioiTinh, DiaChi, SoDT, MaLop) VALUES
    ('SV001', N'Nguyễn Văn Anh', '2000-01-15', 1, N'Hà Nội', '0934572637', '22C2B-LTM1'),
    ('SV002', N'Trần Thị Liễu', '2000-03-20', 2, N'Hồ Chí Minh', '0984482967', '23T4A-ANM1'),
    ('SV003', N'Lê Minh Công', '2000-05-10', 1, N'Đà Nẵng', '0384324678', '23C1A-TKW1'),
    ('SV004', N'Nguyễn Anh Cừ', '2004-11-20', 1, N'Hà Nội', '0934238573', '22C2B-LTM1'),
    ('SV005', N'Trần Thị Mộc', '2002-03-18', 2, N'Hồ Chí Minh', '0987654321', '22C2B-LTM1'),
    ('SV006', N'Lê Văn Dũng', '2003-12-22', 1, N'Đà Nẵng', '0384758296', '22C2B-LTM1');


INSERT INTO MonHoc (MaMH, TenMH, SoTiet, TenGV, HocKy, MaLop) VALUES
    ('MH001', N'Lập trình cơ bản', 45, N'Nguyễn Văn Kiệt', N'Học kỳ 1', '22C2B-LTM1'),
    ('MH002', N'Cấu trúc dữ liệu', 60, N'Trần Văn Anh', N'Học kỳ 2', '23C1A-QTM1'),
    ('MH003', N'Quản trị mạng', 60, N'Trần Văn Anh', N'Học kỳ 2', '23C1A-QTM1'),
    ('MH004', N'Cơ sở dữ liệu', 60, N'Lê Minh Hiếu', N'Học kỳ 1', '23C1A-TKW1');


CREATE TRIGGER UpdateHocLuc
ON Diem
AFTER INSERT, UPDATE
AS
BEGIN
    UPDATE D
    SET HocLuc = CASE
        WHEN D.Diem = 10 THEN N'Xuất sắc'
        WHEN D.Diem >= 8 THEN N'Giỏi'
        WHEN D.Diem >= 7 THEN N'Khá'
        WHEN D.Diem >= 5 THEN N'Trung bình'
        WHEN D.Diem >= 4 THEN N'Yếu'
        ELSE N'Kém'
    END
    FROM Diem D
    INNER JOIN INSERTED I ON D.MaSV = I.MaSV AND D.MaMH = I.MaMH;
END;


INSERT INTO Diem (MaSV, MaMH, Diem, HocLuc) VALUES
    ('SV001', 'MH001', 8.5, null),
    ('SV001', 'MH002', 7.0, null),
    ('SV002', 'MH001', 8.0, null),
    ('SV002', 'MH003', 8.0, null),
	('SV003', 'MH001', 9.0, null),
    ('SV003', 'MH002', 9.5, null),
    ('SV003', 'MH003', 7.5, null);

select * from Diem






