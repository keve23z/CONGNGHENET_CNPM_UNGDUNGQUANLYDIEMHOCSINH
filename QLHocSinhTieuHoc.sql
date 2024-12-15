CREATE DATABASE QLHocSinhTieuHoc

GO
USE QLHocSinhTieuHoc
GO

CREATE TABLE PhuHuynh
(
	MaPH CHAR(10) NOT NULL,
	HoTenPH NVARCHAR(30),
	SoDienThoai VARCHAR(12),
	DiaChi NVARCHAR(50),
	MoiQuanHe NVARCHAR(20),

	CONSTRAINT PK_PhuHuynh PRIMARY KEY(MaPH)
)

CREATE TABLE MonHoc
(
	MaMonHoc CHAR(10) NOT NULL,
	TenMonHoc NVARCHAR(40),

	CONSTRAINT PK_MonHoc PRIMARY KEY(MaMonHoc)
)


CREATE TABLE NienKhoa
(
	MaNienKhoa CHAR(6) NOT NULL,
	TenNienKhoa NVARCHAR(30),

	CONSTRAINT PK_NienKhoa PRIMARY KEY(MaNienKhoa)
)


CREATE TABLE GiaoVien 
(
    MaGiaoVien CHAR(10),
    HoTen NVARCHAR(100),
    NgaySinh DATE,
    GioiTinh NVARCHAR(7),
    DiaChi NVARCHAR(255),
    SoDienThoai VARCHAR(12),
	ChucVu NVARCHAR(20),
    MaMonHoc CHAR(10),

	CONSTRAINT PK_GiaoVien PRIMARY KEY(MaGiaoVien),
    CONSTRAINT FK_GiaoVien_MonHoc FOREIGN KEY (MaMonHoc) REFERENCES MonHoc(MaMonHoc)
);

CREATE TABLE [Login]
(
	TaiKhoan VARCHAR(100) NOT NULL,
	MatKhau VARCHAR(100),
	sdt nvarchar(10),

	CONSTRAINT PK_Login PRIMARY KEY(TaiKhoan)
)

CREATE TABLE Khoi 
(
    MaKhoi CHAR(3) NOT NULL,
    TenKhoi NVARCHAR(30),

    CONSTRAINT PK_Khoi PRIMARY KEY(MaKhoi)
);


CREATE TABLE Lop
(
	MaLop CHAR(10) NOT NULL,
	TenLop NVARCHAR(50),
	MaKhoi CHAR(3),
	MaGVCN CHAR(10) NULL,
	MaNienKhoa CHAR(6),

	CONSTRAINT PK_Lop PRIMARY KEY(MaLop),
    CONSTRAINT FK_Lop_Khoi FOREIGN KEY (MaKhoi) REFERENCES Khoi(MaKhoi),
    CONSTRAINT FK_Lop_GiaoVien FOREIGN KEY (MaGVCN) REFERENCES GiaoVien(MaGiaoVien),
    CONSTRAINT FK_Lop_NienKhoa FOREIGN KEY (MaNienKhoa) REFERENCES NienKhoa(MaNienKhoa),
)


CREATE TABLE HocSinh
(
	MaHocSinh CHAR(10) NOT NULL,
	HoTen NVARCHAR(30),
	NgaySinh DATE,
	GioiTinh NVARCHAR(7),
	MaLop CHAR(10),
	MaPH CHAR(10),

	CONSTRAINT PK_HocSinh PRIMARY KEY(MaHocSinh),
	CONSTRAINT FK_HocSinh_Lop FOREIGN KEY(MaLop) REFERENCES Lop(MaLop),
	CONSTRAINT FK_HocSinh_PhuHuynh FOREIGN KEY(MaPH) REFERENCES PhuHuynh(MaPH)
)


CREATE TABLE Diem 
(
    MaHocSinh CHAR(10),
    MaMonHoc CHAR(10),
	DiemGiuaKy FLOAT DEFAULT NULL,
	DiemCuoiKy FLOAT DEFAULT NULL,
	DiemTB FLOAT DEFAULT NULL,
    HocKy TINYINT, -- 1 = Học kỳ 1, 2 = Học kỳ 2
    MaNienKhoa CHAR(6),

	CONSTRAINT PK_Diem PRIMARY KEY(MaHocSinh, MaMonHoc, HocKy, MaNienKhoa),
    CONSTRAINT FK_Diem_HocSinh FOREIGN KEY (MaHocSinh) REFERENCES HocSinh(MaHocSinh),
    CONSTRAINT FK_Diem_MonHoc FOREIGN KEY (MaMonHoc) REFERENCES MonHoc(MaMonHoc),
	CONSTRAINT FK_Diem_NienKhoa FOREIGN KEY (MaNienKhoa) REFERENCES NienKhoa(MaNienKhoa)
);


CREATE TABLE PhanCong 
(
    MaPhanCong CHAR(5),
    MaGiaoVien CHAR(10), 
    MaLop CHAR(10),
    MaMonHoc CHAR(10),

	CONSTRAINT PK_PhanCong PRIMARY KEY(MaPhanCong),
    CONSTRAINT FK_PhanCong_GiaoVien FOREIGN KEY (MaGiaoVien) REFERENCES GiaoVien(MaGiaoVien),
    CONSTRAINT FK_PhanCong_Lop FOREIGN KEY (MaLop) REFERENCES Lop(MaLop),
	CONSTRAINT FK_PhanCong_MonHoc FOREIGN KEY (MaMonHoc) REFERENCES MonHoc(MaMonHoc),
)

CREATE TABLE HocLuc
(
    MaHocLuc CHAR(5),
    TenHocLuc NVARCHAR(20), -- 'Giỏi', 'Khá', 'Trung Bình', 'Yếu'

	CONSTRAINT PK_HocLuc PRIMARY KEY(MaHocLuc),
);


CREATE TABLE DanhGiaHocLuc
(
    MaHocSinh CHAR(10),
    MaHocLuc CHAR(5),
    HocKy TINYINT,
    MaNienKhoa CHAR(6),

	CONSTRAINT PK_DanhGiaHocLuc PRIMARY KEY(MaHocSinh, HocKy, MaNienKhoa),
    CONSTRAINT FK_DanhGiaHocLuc_HocSinh FOREIGN KEY (MaHocSinh) REFERENCES HocSinh(MaHocSinh),
    CONSTRAINT FK_DanhGiaHocLuc_HocLuc FOREIGN KEY (MaHocLuc) REFERENCES HocLuc(MaHocLuc),
	CONSTRAINT FK_DanhGiaHocLuc_NienKhoa FOREIGN KEY (MaNienKhoa) REFERENCES NienKhoa(MaNienKhoa)
);


CREATE TABLE HanhKiem
(
    MaHanhKiem CHAR(5),
    LoaiHanhKiem NVARCHAR(20),

	CONSTRAINT PK_HanhKiem PRIMARY KEY(MaHanhKiem),
);


CREATE TABLE DanhGiaHanhKiem
(
    MaHocSinh CHAR(10),
    MaHanhKiem CHAR(5),
    HocKy TINYINT,
    MaNienKhoa CHAR(6),

	CONSTRAINT PK_DanhGiaHanhKiem PRIMARY KEY(MaHocSinh, HocKy, MaNienKhoa),
    CONSTRAINT FK_DanhGiaHanhKiem_HocSinh FOREIGN KEY (MaHocSinh) REFERENCES HocSinh(MaHocSinh),
    CONSTRAINT FK_DanhGiaHanhKiem_HanhKiem FOREIGN KEY (MaHanhKiem) REFERENCES HanhKiem(MaHanhKiem),
	CONSTRAINT FK_DanhGiaHanhKiem_NienKhoa FOREIGN KEY (MaNienKhoa) REFERENCES NienKhoa(MaNienKhoa)
);


ALTER TABLE HocSinh
ADD CONSTRAINT CK_HocSinh_GioiTinh CHECK (GioiTinh IN (N'Nam', N'Nữ'))

ALTER TABLE HocSinh
ADD CONSTRAINT CK_HocSinh_NgaySinh CHECK (NgaySinh <= GETDATE())


ALTER TABLE PhuHuynh
ADD CONSTRAINT CK_PhuHuynh_SoDienThoai CHECK (SoDienThoai LIKE '[0-9]%')	


ALTER TABLE GiaoVien
ADD CONSTRAINT CK_GiaoVien_SoDienThoai CHECK (SoDienThoai LIKE '[0-9]%')	


ALTER TABLE Diem
ADD CONSTRAINT CK_Diem_DiemGiuaKy CHECK (DiemGiuaKy >= 0 AND DiemGiuaKy <= 10)

ALTER TABLE Diem
ADD CONSTRAINT CK_Diem_DiemCuoiKy CHECK (DiemCuoiKy >= 0 AND DiemCuoiKy <= 10)

ALTER TABLE Diem
ADD CONSTRAINT CK_Diem_HocKy CHECK (HocKy > 0)


GO
CREATE TRIGGER tr_UpdateDiemTB
ON Diem
AFTER INSERT, UPDATE
AS
BEGIN
    UPDATE Diem
    SET DiemTB = 
        CASE 
            WHEN d.DiemGiuaKy IS NOT NULL AND d.DiemCuoiKy IS NOT NULL THEN
                (d.DiemGiuaKy + d.DiemCuoiKy) / 2
        END
    FROM Diem d
    INNER JOIN inserted i ON  d.MaHocSinh = i.MaHocSinh 
                          AND d.MaMonHoc = i.MaMonHoc 
                          AND d.HocKy = i.HocKy 
                          AND d.MaNienKhoa = i.MaNienKhoa
END
GO


INSERT INTO [Login] (TaiKhoan, MatKhau, sdt) VALUES 
('GV','123', '0961386491');


INSERT INTO PhuHuynh (MaPH, HoTenPH, SoDienThoai, DiaChi, MoiQuanHe) VALUES 
('PH001', N'Trần Văn Hùng', '01234567890', N'Hà Nội', N'Cha'),
('PH002', N'Nguyễn Thị Mai', '09876543210', N'Hải Phòng', N'Mẹ'),
('PH003', N'Phạm Văn Minh', '09123456789', N'Đà Nẵng', N'Cha'),
('PH004', N'Hoàng Thị Lan', '09087654321', N'TPHCM', N'Mẹ'),
('PH005', N'Lê Văn Long', '09345678901', N'Hà Nội', N'Cha'),
('PH006', N'Phạm Thị Hồng', '09456789012', N'Hải Phòng', N'Mẹ'),
('PH007', N'Trần Văn Quý', '09234567891', N'Đà Nẵng', N'Cha'),
('PH008', N'Nguyễn Thị Xuân', '09887654321', N'TPHCM', N'Mẹ'),
('PH009', N'Vũ Văn Phúc', '09765432109', N'Hà Nội', N'Cha'),
('PH010', N'Đặng Thị Thảo', '09654321098', N'Hải Phòng', N'Mẹ'),
('PH011', N'Trần Văn Dũng', '09543210987', N'Đà Nẵng', N'Cha'),
('PH012', N'Nguyễn Thị Bích', '09432109876', N'TPHCM', N'Mẹ'),
('PH013', N'Lê Văn Khánh', '09321098765', N'Hà Nội', N'Cha'),
('PH014', N'Phạm Thị Hà', '09210987654', N'Hải Phòng', N'Mẹ'),
('PH015', N'Trần Văn Tâm', '09109876543', N'Đà Nẵng', N'Cha'),
('PH016', N'Nguyễn Thị Thanh', '09098765432', N'TPHCM', N'Mẹ'),
('PH017', N'Vũ Văn Hoàng', '09387654321', N'Hà Nội', N'Cha'),
('PH018', N'Hoàng Thị Nga', '09276543210', N'Hải Phòng', N'Mẹ'),
('PH019', N'Trần Văn Nghĩa', '09165432109', N'Đà Nẵng', N'Cha'),
('PH020', N'Nguyễn Thị Hạnh', '09054321098', N'TPHCM', N'Mẹ'),
('PH021', N'Phạm Văn Bình', '09123456765', N'Hà Nội', N'Cha'),
('PH022', N'Lê Thị Lan', '09387654322', N'Hải Phòng', N'Mẹ'),
('PH023', N'Trần Minh Quang', '09432109877', N'Đà Nẵng', N'Cha'),
('PH024', N'Nguyễn Thị Kim', '09543210987', N'TPHCM', N'Mẹ'),
('PH025', N'Phạm Minh Sơn', '09654321099', N'Hà Nội', N'Cha'),
('PH026', N'Vũ Thị Lý', '09765432110', N'Hải Phòng', N'Mẹ'),
('PH027', N'Lê Văn Quang', '09876543212', N'Đà Nẵng', N'Cha'),
('PH028', N'Trần Minh Vũ', '09987654321', N'TPHCM', N'Mẹ'),
('PH029', N'Nguyễn Thị Tâm', '09098765433', N'Hà Nội', N'Mẹ'),
('PH030', N'Phạm Văn Bảo', '09123456791', N'Hải Phòng', N'Cha'),
('PH031', N'Lê Thị Minh', '09234567893', N'Đà Nẵng', N'Mẹ'),
('PH032', N'Vũ Thị Hương', '09345678904', N'TPHCM', N'Mẹ'),
('PH033', N'Trần Văn Duy', '09456789015', N'Hà Nội', N'Cha'),
('PH034', N'Nguyễn Thị Hoa', '09567890124', N'Hải Phòng', N'Mẹ'),
('PH035', N'Phạm Minh Thanh', '09678901235', N'Đà Nẵng', N'Cha'),
('PH036', N'Lê Văn Dũng', '09789012346', N'TPHCM', N'Cha'),
('PH037', N'Trần Thị Quỳnh', '09890123457', N'Hà Nội', N'Mẹ'),
('PH038', N'Nguyễn Thị Liên', '09901234568', N'Hải Phòng', N'Mẹ'),
('PH039', N'Phạm Văn Khang', '09012345679', N'Đà Nẵng', N'Cha');


INSERT INTO MonHoc (MaMonHoc, TenMonHoc) VALUES 
('MH001', N'Toán học'),
('MH002', N'Tiếng Việt'),
('MH003', N'Giáo dục thể chất'),
('MH004', N'Ngữ văn'),
('MH005', N'Đạo đức');


INSERT INTO NienKhoa (MaNienKhoa, TenNienKhoa) VALUES 
('NH2020', N'Năm học 2020-2021'),
('NH2021', N'Năm học 2021-2022'),
('NH2022', N'Năm học 2022-2023'),
('NH2023', N'Năm học 2023-2024'),
('NH2024', N'Năm học 2024-2025');


INSERT INTO GiaoVien (MaGiaoVien, HoTen, NgaySinh, GioiTinh, DiaChi, SoDienThoai, MaMonHoc) VALUES 
('GV001', N'Nguyễn Văn Minh', '1980-01-15', N'Nam', N'Hà Nội', '0123456789', 'MH001'),
('GV002', N'Trần Thị Linh', '1985-05-20', N'Nữ', N'Hải Phòng', '0987654321', 'MH002'),
('GV003', N'Trần Công Mạnh', '1990-03-12', N'Nam', N'Đà Nẵng', '0912345678', 'MH003'),
('GV004', N'Đỗ Thuỳ Trang', '1988-07-30', N'Nữ', N'TPHCM', '0945678901', 'MH004'),
('GV005', N'Trần Văn Quân', '1980-11-22', N'Nam', N'Nam Định', '0976543210', 'MH005'),
('GV006', N'Trần Văn Phúc', '1985-06-10', N'Nam', N'TPHCM', '0912345678', 'MH001'),
('GV007', N'Nguyễn Thị Hoa', '1990-12-22', N'Nữ', N'Đà Nẵng', '0934567890', 'MH002'),
('GV008', N'Nguyễn Văn Hải', '1988-02-15', N'Nam', N'Hà Nội', '0945678901', 'MH003'),
('GV009', N'Trần Thị Kim', '1995-03-30', N'Nữ', N'Hải Phòng', '0956789012', 'MH004'),
('GV010', N'Trần Văn Thành', '1982-07-25', N'Nam', N'Nam Định', '0967890123', 'MH005');


INSERT INTO Khoi (MaKhoi, TenKhoi) VALUES 
('K01', N'Khối 1'),
('K02', N'Khối 2'),
('K03', N'Khối 3'),
('K04', N'Khối 4'),
('K05', N'Khối 5');


INSERT INTO Lop (MaLop, TenLop, MaKhoi, MaGVCN, MaNienKhoa) VALUES 
('L0001', N'Lớp 1A', 'K01', 'GV001', 'NH2023'),
('L0002', N'Lớp 1B', 'K01', 'GV002', 'NH2023'),
('L0003', N'Lớp 2A', 'K02', 'GV003', 'NH2023'),
('L0004', N'Lớp 2B', 'K02', 'GV004', 'NH2023'),
('L0005', N'Lớp 3A', 'K03', 'GV005', 'NH2023'),
('L0006', N'Lớp 3B', 'K03', 'GV006', 'NH2024'),
('L0007', N'Lớp 4A', 'K04', 'GV007', 'NH2024'),
('L0008', N'Lớp 4B', 'K04', 'GV008', 'NH2024'),
('L0009', N'Lớp 5A', 'K05', 'GV009', 'NH2024'),
('L0010', N'Lớp 5B', 'K05', 'GV010', 'NH2024');


INSERT INTO HocSinh (MaHocSinh, HoTen, NgaySinh, GioiTinh, MaLop, MaPH) VALUES 
('HS001', N'Trần Văn Tú', '2017-01-10', N'Nam', 'L0001', 'PH001'),
('HS002', N'Nguyễn Thị Hồng', '2017-02-15', N'Nữ', 'L0001', 'PH002'),
('HS003', N'Trần Công Mạnh', '2017-03-20', N'Nam', 'L0001', 'PH003'),
('HS004', N'Nguyễn Văn An', '2017-04-25', N'Nam', 'L0001', 'PH004'),

('HS005', N'Trần Thị Mai', '2017-05-10', N'Nữ', 'L0002', 'PH005'),
('HS006', N'Trần Minh Tuấn', '2017-06-15', N'Nam', 'L0002', 'PH006'),
('HS007', N'Nguyễn Thị Bích', '2017-07-20', N'Nữ', 'L0002', 'PH007'),
('HS008', N'Trần Văn Kiên', '2017-08-25', N'Nam', 'L0002', 'PH008'),

('HS009', N'Nguyễn Văn Bình', '2016-09-05', N'Nam', 'L0003', 'PH009'),
('HS010', N'Nguyễn Thị Thanh', '2016-10-10', N'Nữ', 'L0003', 'PH010'),
('HS011', N'Trần Quốc Cường', '2016-11-15', N'Nam', 'L0003', 'PH011'),
('HS012', N'Nguyễn Thị Ngọc', '2016-12-20', N'Nữ', 'L0003', 'PH012'),

('HS013', N'Trần Văn Hải', '2016-01-01', N'Nam', 'L0004', 'PH013'),
('HS014', N'Nguyễn Văn Duy', '2016-02-02', N'Nam', 'L0004', 'PH014'),
('HS015', N'Trần Thị Nhi', '2016-03-03', N'Nữ', 'L0004', 'PH015'),
('HS016', N'Nguyễn Thị Thảo', '2016-04-04', N'Nữ', 'L0004', 'PH016'),

('HS017', N'Trần Quốc Việt', '2015-05-05', N'Nam', 'L0005', 'PH017'),
('HS018', N'Nguyễn Văn Hưng', '2015-06-06', N'Nam', 'L0005', 'PH018'),
('HS019', N'Trần Thị Hương', '2015-07-07', N'Nữ', 'L0005', 'PH019'),
('HS020', N'Nguyễn Thị Hạnh', '2015-08-08', N'Nữ', 'L0005', 'PH020'),

('HS021', N'Trần Văn Dũng', '2015-09-09', N'Nam', 'L0006', 'PH021'),
('HS022', N'Nguyễn Thị Như', '2015-10-10', N'Nữ', 'L0006', 'PH022'),
('HS023', N'Trần Minh Đức', '2015-11-11', N'Nam', 'L0006', 'PH023'),
('HS024', N'Nguyễn Thị Bảo', '2015-12-12', N'Nữ', 'L0006', 'PH024'),

('HS025', N'Trần Quốc Toàn', '2014-01-13', N'Nam', 'L0007', 'PH025'),
('HS026', N'Nguyễn Văn Phúc', '2014-02-14', N'Nam', 'L0007', 'PH026'),
('HS027', N'Trần Thị Ly', '2014-03-15', N'Nữ', 'L0007', 'PH027'),
('HS028', N'Nguyễn Thị Lộc', '2014-04-16', N'Nữ', 'L0007', 'PH028'),

('HS029', N'Trần Văn Sơn', '2014-05-17', N'Nam', 'L0008', 'PH029'),
('HS030', N'Nguyễn Thị Hà', '2014-06-18', N'Nữ', 'L0008', 'PH030'),
('HS031', N'Trần Minh Hoàng', '2014-07-19', N'Nam', 'L0008', 'PH031'),
('HS032', N'Nguyễn Thị Vân', '2014-08-20', N'Nữ', 'L0008', 'PH032'),

('HS033', N'Trần Quốc Bảo', '2013-09-21', N'Nam', 'L0009', 'PH033'),
('HS034', N'Nguyễn Thị Liên', '2013-10-22', N'Nữ', 'L0009', 'PH034'),
('HS035', N'Trần Văn Hòa', '2013-11-23', N'Nam', 'L0009', 'PH035'),
('HS036', N'Nguyễn Thị Nga', '2013-12-24', N'Nữ', 'L0009', 'PH036'),

('HS037', N'Trần Văn Tâm', '2013-01-25', N'Nam', 'L0010', 'PH037'),
('HS038', N'Nguyễn Thị Quyên', '2013-02-26', N'Nữ', 'L0010', 'PH038'),
('HS039', N'Trần Minh Tâm', '2013-03-27', N'Nam', 'L0010', 'PH039');


INSERT INTO Diem (MaHocSinh, MaMonHoc, DiemGiuaKy, DiemCuoiKy, DiemTB, HocKy, MaNienKhoa) VALUES 
('HS001', 'MH001', 8.5, 9.0, NULL, 1, 'NH2023'),
('HS002', 'MH001', 7.5, 7.0, NULL, 2, 'NH2023'),
('HS002', 'MH003', 8.5, 6.0, NULL, 2, 'NH2023'),
('HS003', 'MH004', 6.0, 5.5, NULL, 1, 'NH2023'),
('HS004', 'MH005', 8.0, 8.5, NULL, 2, 'NH2023'),
('HS005', 'MH001', 9.5, 6.5, NULL, 1, 'NH2024'),
('HS006', 'MH002', 7.0, 6.0, NULL, 2, 'NH2024'),
('HS007', 'MH003', 4.0, 6.5, NULL, 1, 'NH2024'),
('HS008', 'MH004', 5.5, 8.5, NULL, 2, 'NH2024'),
('HS009', 'MH001', 7.0, 4.5, NULL, 1, 'NH2024'),
('HS009', 'MH005', 6.0, 4.8, NULL, 1, 'NH2024'),
('HS010', 'MH001', 7.5, 7.8, NULL, 1, 'NH2024');


INSERT INTO PhanCong (MaPhanCong, MaGiaoVien, MaLop, MaMonHoc) VALUES 
('PC001', 'GV001', 'L0001', 'MH001'),
('PC002', 'GV002', 'L0002', 'MH002'),
('PC003', 'GV003', 'L0003', 'MH003'),
('PC004', 'GV004', 'L0004', 'MH004'),
('PC005', 'GV005', 'L0005', 'MH005'),
('PC006', 'GV006', 'L0006', 'MH001'),
('PC007', 'GV007', 'L0007', 'MH002'),
('PC008', 'GV008', 'L0008', 'MH003'),
('PC009', 'GV009', 'L0009', 'MH004'),
('PC010', 'GV010', 'L0010', 'MH005');


INSERT INTO HocLuc (MaHocLuc, TenHocLuc) VALUES 
('HL001', N'Giỏi'),
('HL002', N'Khá'),
('HL003', N'Trung Bình'),
('HL004', N'Yếu'),
('HL005', N'Kém');


INSERT INTO DanhGiaHocLuc (MaHocSinh, MaHocLuc, HocKy, MaNienKhoa) VALUES 
('HS001', 'HL001', 1, 'NH2023'),
('HS002', 'HL002', 1, 'NH2023'),
('HS003', 'HL003', 2, 'NH2023'),
('HS004', 'HL004', 2, 'NH2023'),
('HS005', 'HL005', 1, 'NH2023'),
('HS006', 'HL001', 1, 'NH2024'),
('HS007', 'HL002', 1, 'NH2024'),
('HS008', 'HL003', 2, 'NH2024'),
('HS009', 'HL004', 2, 'NH2024'),
('HS010', 'HL005', 1, 'NH2024');


INSERT INTO HanhKiem (MaHanhKiem, LoaiHanhKiem) VALUES 
('HK001', N'Tốt'),
('HK002', N'Khá'),
('HK003', N'Trung Bình'),
('HK004', N'Yếu');


INSERT INTO DanhGiaHanhKiem (MaHocSinh, MaHanhKiem, HocKy, MaNienKhoa) VALUES 
('HS001', 'HK001', 1, 'NH2023'),
('HS002', 'HK002', 1, 'NH2023'),
('HS003', 'HK003', 2, 'NH2023'),
('HS004', 'HK004', 2, 'NH2023'),
('HS005', 'HK002', 1, 'NH2023'),
('HS006', 'HK001', 1, 'NH2024'),
('HS007', 'HK002', 1, 'NH2024'),
('HS008', 'HK003', 2, 'NH2024'),
('HS009', 'HK004', 2, 'NH2024'),
('HS010', 'HK002', 1, 'NH2024');