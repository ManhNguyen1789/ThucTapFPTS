-- CÁC TRUY CẤN CƠ BẢN VÀ QUAN TRỌNG---------------------------------------------
----- LẤY RA THÁNG CỦA THỜI GIAN HIỆN TẠ LÀ THÁNG MẤY-----------
--SELECT MONTH(GETDATE());
---- HOẶC
--SELECT MONTH(DATEADD(MONTH, 0, GETDATE()));
----- VD:
--SELECT DATEPART(quarter, '2019/09/28');
--declare @m int =MONTH(DATEADD(MONTH, 0, GETDATE()));
--select Booking.NgayBook from Booking
--declare @n date;
--select  @n = Booking.NgayBook from Booking
--select @n
--select DATEPART(quarter, DATEADD(MONTH, 0, NgayBook)) from Booking
--select DATEPART(quarter,DATEADD(MONTH, -1, GETDATE()))
--select Tour.TenTour, Booking.NgayBook from Tour, Booking where Tour.MaTour = Booking.MaTour and  DATEPART(quarter, DATEADD(MONTH, 0, NgayBook)) = DATEPART(quarter, DATEADD(MONTH, -1, GETDATE()))
---- LẤY RA QUÝ CỦA THỜI GIAN HIỆN TẠI LÀ QUÝ MẤY-------------------
--SELECT DATEPART(quarter, GETDATE()); 
---- HOẶC
--SELECT DATEPART(quarter, DATEADD(MONTH, 0, GETDATE()));

--- LẤY RA QUÝ TRƯỚC CỦA QUÝ HIỆN TẠI:-----------------------------------------------------------
--declare @n date;
--declare @m date;
--select  DATEPART(QUARTER, GETDATE())
--		, YEAR(GETDATE())
--		, (CASE DATEPART(QUARTER, GETDATE()) WHEN 1 THEN 4 WHEN 2 THEN 1 WHEN 3 THEN 2 WHEN 4 THEN 3 END)
--		, (CASE DATEPART(QUARTER, GETDATE()) WHEN 1 THEN YEAR(GETDATE()) - 1 WHEN 2 THEN YEAR(GETDATE()) WHEN 3 THEN YEAR(GETDATE()) WHEN 4 THEN YEAR(GETDATE()) END)

-- LẤY RA NHÂN VIÊN BÁN NHIỀU SẢN PHẨM NHẤT (MÃ NHÂN NHIÊN XUẤT HIỆN NHIỀU NHẤT TRONG MỘT BẢNG (1 CỘT))-----------------------------------------
--select  top 1  NhanVien.TenNV from NhanVien, Booking where NhanVien.MaNV = Booking.MaNV group by Booking.MaNV, NhanVien.TenNV order by COUNT(1)

-- LẤY RA NHÂN VIÊN BÁN NHIỀU SẢN PHẨM NHẤT (MÃ NHÂN NHIÊN XUẤT HIỆN NHIỀU NHẤT TRONG MỘT BẢNG (1 CỘT))-----------------------------------------
--select  top 1  NhanVien.TenNV from NhanVien, Booking where NhanVien.MaNV = Booking.MaNV group by Booking.MaNV, NhanVien.TenNV order by COUNT(1) DESC

---- BOOKING--------------------------------------------------------
---- l?y ra thông tin b?ng booking
--select * from Booking

---- insert 
--insert into Booking(LoaiVe)  values('lv004')

-------------------
---- Update có ?i?u ki?n
--update  Booking set LoaiVe= 'lv001', SLNguoiLon = 12  where MaVe =2

---- update toàn b? b?ng
--update  Booking set LoaiVe= 'lv001', SLNguoiLon = 12
---------------------

---- delete
--delete from Booking where MaVe='7'; 

---- s?p x?p theo giá t?ng d?n
--select * from Booking order by GiaTien

---- s?p x?p theo giá gi?m d?n
--select * from Booking order by GiaTien DESC

----L?CH TRÌNH---------------------------------------------------------
---- l?y ra thông tin b?ng
--select * from LichTrinh

---- insert 
--insert into LichTrinh(MaLT,NgayBD,NgayKT,MaTour,MaPT,Slot)  values('LTR007', '03-11-2021', '03-21-2021', 't002', 'pt002', 30);

-------------------
---- Update có ?i?u ki?n
--update  LichTrinh set Slot=35  where MaLT = 'LTR007'

---- update toàn b? b?ng
--update  LichTrinh set Slot=35
---------------------

---- delete
--delete from LichTrinh where MaLT='LTR006'; 

---- s?p x?p theo giá t?ng d?n
--select * from LichTrinh order by Slot

---- s?p x?p theo giá gi?m d?n
--select * from LichTrinh order by Slot DESC

----KHÁCH HÀNG ---------------------------------------------
---- l?y ra thông tin b?ng
--select * from KhachHang

---- insert 
--insert into KhachHang(MaKH,TenKH,GioiTinh,QuocTich,CMND,DiaChi,SDT,TaiKhoan,Matkhau)  values('kh004', N'Nguy?n V?n Long', 'Nam', N'Vi?t Nam', '1781320002', N'Hà N?i', '0383317677', 'khlong', '0ee4c76f897ecaea3946d1b103fc7baf');

-------------------
---- Update có ?i?u ki?n
--update  KhachHang set DiaChi =N'Hà N?i' where MaKH = 'kh004'

---- update toàn b? b?ng
--update  KhachHang set DiaChi =N'Hà N?i'
---------------------

---- delete
--delete from KhachHang where MaKH='kh004'; 

---- s?p x?p theo giá t?ng d?n
--select * from KhachHang order by MaKH

---- s?p x?p theo giá gi?m d?n
--select * from KhachHang order by MaKH DESC


-- LẤY RA TỔNG DOANH THU TRONG MỘT KHOẢNG THỜI GIAN-----------------
--declare @n date, @m date;
--set @n ='01/01/2020'
--set @m='01/01/2021'
--select SUM(GiaTien) from Booking
--where NgayBook between @n and @m

select * from Booking where NgayBook between '01/01/2020' and '01/01/2021'
select SUM(GiaTien) as 'tổng doanh thu' from Booking where NgayBook between '01/01/2020' and '01/01/2021'
-- LẤY RA TOUR ĐƯỢC ĐẶT NHIỀU NHẤT TRONG MỘT KHOẢNG THỜI GIAN---------------------------
--select top 3 COUNT(1),  Tour.TenTour, Tour.MaTour, tour.MaLoaiTour  from Tour, Booking where Tour.MaTour = Booking.MaTour and NgayBook between '01/01/2020' and '01/01/2021'  group by Booking.MaTour, Tour.TenTour, Tour.MaTour,tour.MaLoaiTour order by COUNT(1) desc

--- TÌM BOOKING THEO TÊN NHÂN VIÊN
--select Booking.MaVe, Booking.MaTour, Booking.MaLT, Booking.MaKH, Booking.MaNV, Booking.NgayBook, Booking.GiaTien, NhanVien.TenNV from Booking, NhanVien where Booking.MaNV = NhanVien.MaNV and NhanVien.TenNV like N'%thủy%' and  NgayBook between '01/01/2020' and '10/10/2021'