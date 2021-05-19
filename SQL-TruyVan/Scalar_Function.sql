--select * from KHACHHANG------------------------

-- CÂU LỆNH LẤY MAX---------------------------------------------
-- REPLACE(MAKH,'KH','') LÀ CÂU LỆNH CHUYỂN ĐỔI (THAY THẾ) Ở ĐÂY LÀ ĐỔI KÝ TỰ KH THÀNH '' TRONG makh
--select MAX(CONVERT(INT, (REPLACE(makh,'KH', '')))) + 1 from KHACHHANG

-- hàm tạo function mã tự tăng mã khách hàng------------------------
--CREATE FUNCTION dbo.mangmakh()
--RETURNS NVARCHAR(50)
--AS
--BEGIN
--	DECLARE @m NVARCHAR(50)
--	DECLARE @index INT
--	IF (SELECT COUNT(MaKH) FROM KHACHHANG) = 0
--		SET @m ='0'
--	ELSE
	
--		SELECT @m = MAX(REPLACE(makh,'KH', '')) from KHACHHANG
--		SET @index = CONVERT(INT, @m);

--		IF(@index < 10)
--			SELECT @m =  'KH00' + CONVERT(NVARCHAR(50),CONVERT(INT,@m)+1)
--		IF(@index >= 10)
--			SELECT @m =  'KH0' + CONVERT(NVARCHAR(50),CONVERT(INT,@m)+1)
--		IF(@index >= 100)
--			SELECT @m = 'KH' + CONVERT(NVARCHAR(50),CONVERT(INT,@m)+1)
--RETURN @m
--END
----CHỈNH SỬA LẠI SCALAR FUNCTION VỚI ALTER-------------------------
--ALTER FUNCTION dbo.mangmakh()
--RETURNS NVARCHAR(50)
--AS
--BEGIN
--	DECLARE @m NVARCHAR(50)
--	DECLARE @index INT
--	IF (SELECT COUNT(MaKH) FROM KHACHHANG) = 0
--		SET @m ='0'
--	ELSE
	
--		SELECT @m = MAX(REPLACE(makh,'KH', '')) from KHACHHANG
--		SET @index = CONVERT(INT, @m);

--		IF(@index < 10)
--			SELECT @m =  'KH00' + CONVERT(NVARCHAR(50),CONVERT(INT,@m)+1)
--		ELSE IF(@index >= 10)
--			SELECT @m =  'KH0' + CONVERT(NVARCHAR(50),CONVERT(INT,@m)+1)
--		ELSE IF(@index >= 100)
--			SELECT @m = 'KH' + CONVERT(NVARCHAR(50),CONVERT(INT,@m)+1)
--RETURN @m
--END

----TẠO  SCALAR FUNCTION AUTO TĂNG MÃ LỊCH TRÌNH VỚI ------------------------
--CREATE FUNCTION dbo.automaltrinh()
--RETURNS NVARCHAR(50)
--AS
--BEGIN
--	DECLARE @m NVARCHAR(50)
--	DECLARE @index INT
--	IF (SELECT COUNT(MaLT) FROM LICHTRINH) = 0
--		SET @m ='0'
--	ELSE
	
--		SELECT @m = MAX(REPLACE(MaLT,'LTR', '')) from LICHTRINH
--		SET @index = CONVERT(INT, @m);

--		IF(@index < 10)
--			SELECT @m =  'LTR00' + CONVERT(NVARCHAR(50),CONVERT(INT,@m)+1)
--		ELSE IF(@index >= 10)
--			SELECT @m =  'LTR0' + CONVERT(NVARCHAR(50),CONVERT(INT,@m)+1)
--		ELSE IF(@index >= 100)
--			SELECT @m = 'LTR' + CONVERT(NVARCHAR(50),CONVERT(INT,@m)+1)
--RETURN @m
--END


--LỆNH THỰC THI SCALAR FUNCTION--------------------------
--SELECT dbo.mangmakh()

--LỆNH XÓA BỎ MỘT FUNCTION--------------------------------
--DROP FUNCTION dbo.mangmakh();

--select  dbo.mangmakh()

-- LẤY RA PHẦN TỬ XUẤT HIỆN NHIỀU NHẤT TRONG BẢNG (TRONG TRƯỜNG DỮ LIỆU)-------------------
--select COUNT(1) as N'Số lượng', MaTour from booking group by MaTour
--select TOP 1 COUNT(1), MaTour from booking group by MaTour order by COUNT(1) desc

--BÀI TẬP LÀM-------------------------------------------------------------------------------------------------------------
-- dùng while insert 100 khách hàng - (đa dạng data)
--DECLARE 
--	@x int, @y int,
--	@makh NVARCHAR(50),
--	@tenkh NVARCHAR(50),
--	@gioitinh NVARCHAR(50),
--	@quoctich NVARCHAR(50),
--	@cmnd NVARCHAR(50),
--	@diachi NVARCHAR(50),
--	@SDT NVARCHAR(50)

--SELECT @x = 31, @y = 100,
--	@makh = 'KH',
--	@tenkh = 'MANH ',
--	@gioitinh = 'Nam ',
--	@quoctich = N'Viêt Nam ',
--	@cmnd = '123',
--	@diachi = N'Băc Giang ',
--	@SDT = '123'

--WHILE @x <= @y
--	BEGIN
--		INSERT INTO dbo.KHACHHANG
--		(MaKH,TenKH,GioiTinh,QuocTich,CMND,DiaChi,SDT)
--		SELECT  @makh +  RIGHT(('00' + CONVERT(nvarchar,@x)),3),
--				@tenkh + CONVERT(nvarchar,@x),
--				@gioitinh + CONVERT(nvarchar,@x),
--				@quoctich + CONVERT(nvarchar,@x),
--				@cmnd  + CONVERT(nvarchar,@x),
--				@diachi  + CONVERT(nvarchar,@x),
--				@SDT  + CONVERT(nvarchar,@x)
--		SET @x = @x	+ 1
--	END
-- select * from booking
--select * from Tour
--select * from KHACHHANG
----------------------------------------------------------------------------------------------------------------------
-- 20 khách hàng book tour trong đó 5 khách hàng book 5 tour => viet function thong ke danh sach khach hang dat nhieu tour
--ALTER FUNCTION dbo.getkhmaxtour()
--RETURNS NVARCHAR(50)
--AS
--BEGIN
--	DECLARE @m NVARCHAR(50)
--	select top 1 @m = KHACHHANG.TenKH from KHACHHANG, BOOKING where KHACHHANG.MaKH = BOOKING.MaKH group by KHACHHANG.TenKH, BOOKING.MaKH order by COUNT(1) desc 
--RETURN @m
----select top 1 count(1) as 'số lượng tour đã đặt', KHACHHANG.TenKH, TOUR.MaTour, TOUR.TenTour from TOUR, KHACHHANG, BOOKING where KHACHHANG.MaKH = BOOKING.MaKH group by TOUR.MaTour, TOUR.TenTour, KHACHHANG.TenKH, BOOKING.MaKH order by COUNT(1) desc 
--END
----select distinct TOUR.TenTour, tour.MaLoaiTour, tour.G/iaTien, tour.Minuser, tour.Maxuser, TOUR.MieuTaNgan, TOUR.MaTour, KHACHHANG.TenKH from TOUR, BOOKING, KHACHHANG where KHACHHANG.MaKH = BOOKING.MaKH and  KHACHHANG.MaKH ='KH005'
----select * from BOOKING, TOUR where BOOKING.MaTour = T/OUR.MaTour and BOOKING.MaKH = 'KH005'
--select dbo.getkhmaxtour();
--GO
---------------------------------------------------------------------------------------------------------------
 --dùng con trỏ (cursor) lọc khách hàng nào quoc tich VN giới tính là nữ thì update CMND là xxxx-xxxx-xxxx
-- select * from KHACHHANG where GioiTinh = N'Nữ' and QuocTich = N'Việt Nam'
--DECLARE ChangeKHcmndCursor CURSOR FOR SELECT KHACHHANG.GioiTinh, KHACHHANG.QuocTich from dbo.KHACHHANG

--OPEN ChangeKHcmndCursor
--DECLARE @GioiTinh NVARCHAR(50)
--DECLARE @QuocTich NVARCHAR(50)
--DECLARE @CMND NVARCHAR(14)

--FETCH NEXT FROM ChangeKHcmndCursor INTO @GioiTinh, @QuocTich

--While @@FETCH_STATUS = 0
--BEGIN
--	IF @GioiTinh = N'Nữ' and @QuocTich =N'Việt Nam'
--		BEGIN
--			UPDATE dbo.KHACHHANG SET CMND = '1234-1234-1234' where @GioiTinh = GioiTinh and @QuocTich = QuocTich
--		END

--	FETCH NEXT FROM ChangeKHcmndCursor INTO @GioiTinh, @QuocTich
--END

--close ChangeKHcmndCursor
--DEALLOCATE ChangeKHcmndCursor
----------------------------------------------------------------------------------------------------------------------------
---- Tìm kiếm từ ngày đến, ngày ra, thứ tự danh sách tour diễn ra theo thứ tự ngày từ bé đến lớn
--select Tour.TenTour, LICHTRINH.NgayBD, LICHTRINH.NgayKT, DATEDIFF(DAY, NgayBD, NgayKT) as 'số ngày' from LichTrinh, TOUR 
--where LICHTRINH.MaTour = TOUR.MaTour
--and NgayBD >= '01/01/2020' and NgayKT <= '02/02/2021' --and NgayBD <= NgayKT
--order by DATEDIFF(DAY, NgayBD, NgayKT) 
-- câu 1:
--CREATE FUNCTION dbo.insertkh()
--RETURNS NVARCHAR(50)
--AS

--BEGIN
--DECLARE @m NVARCHAR(50)
--Declare @i NVARCHAR(50)
--Declare @tam int;
--Declare @ten NVARCHAR(50);
--Declare @mkh NVARCHAR(50) = dbo.mangmakh();
--SET @tam = CONVERT(INT, @i);
--	While(@i <=100)
--	begin
--		SET @ten = CONVERT(NVARCHAR(50), @i);
--		KHACHHANG(@makh, @ten);
--		@i=@i+1;

	
--	RETURN @m
--	end
--END
--câu 2
--select * from BOOKING
--select TOP 1 COUNT(1), MaKH from booking group by MaKH order by COUNT(1) desc
--DECLARE @makh NVARCHAR(20)
--	SELECT @makh = MaKH from booking group by MaKH order by COUNT(1) desc 
--select BOOKING.MaKH from BOOKING
--order by

--select * from KHACHHANG
--select * from Booking
--select TOP 1  MaTour from booking group by MaTour order by COUNT(1) desc


--CREATE FUNCTION dbo.sumdoanhthutime()
--RETURNS NVARCHAR(50)
--AS

--BEGIN
--	DECLARE @a NVARCHAR(50)
--	SELECT @a = Sum(GiaTien) from Booking where Booking.NgayBook between '01/01/2020' and '10/10/2021'
--RETURN @a;
--END
--convert(NVARCHAR(12),NhanVien.NgaySinh, 103)

--select dbo.sumdoanhthutime()
--go


CREATE proc dbo.childtk(@timkiem NVARCHAR(50))
AS

BEGIN
	select Booking.MaVe, Booking.MaTour, Booking.MaLT, Booking.MaKH, Booking.MaNV, Booking.NgayBook, Booking.GiaTien, NhanVien.TenNV as TenNV, NhanVien.MaNV as MaNV, NhanVien.NghiepVu as NghiepVu, NhanVien.GioiTinh as GioiTinh, NhanVien.DiaChi as DiaChi, NhanVien.SDT as SDT, convert(NVARCHAR(12),NhanVien.NgaySinh, 103) as NgaySinh from Booking, NhanVien where Booking.MaNV = NhanVien.MaNV and NhanVien.TenNV like N'%'+@timkiem+'%'
END

exec dbo.childtk N'tú'
go
