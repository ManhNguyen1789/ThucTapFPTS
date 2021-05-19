﻿
--SELECT * from KHACHHANG
--SELECT * from BOOKING
--SELECT * from LICHTRINH
--SELECT * from TOUR

---------INSERT 100 KHÁCH HÀNG KHÁC DATA-----------
--DECLARE 
--	@x int, @y int,
--	@makh NVARCHAR(50),
--	@tenkh NVARCHAR(50),
--	@gioitinh NVARCHAR(50),
--	@quoctich NVARCHAR(50),
--	@cmnd NVARCHAR(50),
--	@diachi NVARCHAR(50),
--	@SDT NVARCHAR(50)

--SELECT @x = 8, @y = 30,
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


---------INSERT LỊCH TRÌNH KHÁC DATA---------------------
--select * from PHUONGTIEN
--select * from LICHTRINH
--DECLARE 
--	@x int, @y int,
--	@maltrinh NVARCHAR(50),
--	@ngaybd date,
--	@ngaykt date,
--	@chiphi NVARCHAR(50),
--	@matour NVARCHAR(50),
--	@maptien NVARCHAR(50)

--SELECT @x = 1, @y = 20,
--	@maltrinh = 'LTR',
--	@ngaybd = GETDATE(),
--	@ngaykt = GETDATE(),
--	@chiphi = '1000',
--	@matour = 'T001',
--	@maptien = 'PT004'

--WHILE @x <= @y
--	BEGIN
--		INSERT INTO dbo.LICHTRINH
--		(MaLT,NgayBD,NgayKT,ChiPhi,MaTour,MaPT)
--		SELECT  
--				@maltrinh +  RIGHT(('00' + CONVERT(nvarchar,@x)),3),
--				@ngaybd,
--				@ngaykt,
--				@chiphi + CONVERT(nvarchar,@x),
--				@matour,
--				@maptien
				
--		SET @x = @x	+ 1
--	END
---- HÀM RANDOM TRONG SQL RANDOM NGẪN NHIÊN SỐ TỪ O ĐẾN 1O-----------------------
--DECLARE @x int =0, @y int =10
--while @x <= @y
--	begin
--		--SELECT FLOOR(RAND()*(10-5+1)+5);
--		select FLOOR(RAND()*(60-10+1)+10)
--		SET @x = @x	+ 1
--	end

---- INSERT 50 BOOKING---------
---------INSERT BOOKING KHÁC DATA---------------------
--select * from BOOKING
--select * from LICHTRINH
--select * from NHANVIEN
--SELECT * from KHACHHANG
--SELECT * from TOUR
--DECLARE 
--	@x int, @y int,
--	@mave NVARCHAR(50),
--	@matour NVARCHAR(50),
--	@slnl int,
--	@slte int,
--	@malt NVARCHAR(50),
--	@makh NVARCHAR(50),
--	@madddl NVARCHAR(50),
--	@manv NVARCHAR(50),
--	@trangthai NVARCHAR(50),
--	@giatien BIGINT

--SELECT @x = 79, @y = 80,
--	@mave ='V0',
--	@matour = 'T001',
--	@slnl = FLOOR(RAND()*(10-5+1)+5),
--	@slte = FLOOR(RAND()*(10-5+1)+5),
--	@malt = 'LTR001',
--	@makh = 'KH022',
--	@madddl = 'DDDL001',
--	@manv = 'NV017',
--	@trangthai =N'Chờ Duyệt',
--	@giatien ='30000'

--WHILE @x <= @y
--	BEGIN
--		INSERT INTO dbo.BOOKING	
--		(MaVe,MaTour,SLNguoiLon,SLTreEm,MaLT,MaKH,MaDDDL,MaNV,TrangThai,GiaTien)
--		SELECT  
--				@mave + CONVERT(nvarchar,@x),
--				@matour,
--				@slnl,
--				@slte,
--				@malt,
--				@makh,
--				@madddl,
--				@manv,
--				@trangthai,
--				@giatien + CONVERT(nvarchar,@x)
					
--		SET @x = @x	+ 1
--	END
--LẤY RA 20 KHÁCH HÀNG TRONG BOOKING TRONG DÓ CÓ 5 KHÁCH HÀNG BOOK 5 TOUR
--select TOP 20 COUNT(1), MaKH from booking group by MaKH order by COUNT(1) desc
----TẠO  SCALAR FUNCTION LẤY RA KHÁCH HÀNG ĐẶT NHIỀU TOUR NHẤT ------------------------
--ALTER FUNCTION dbo.getkhmaxtour()
--RETURNS NVARCHAR(50)
--AS
--BEGIN
--	DECLARE @m NVARCHAR(50), @n NVARCHAR(50)
--	select top 1 @m = KHACHHANG.TenKH from KHACHHANG, BOOKING where KHACHHANG.MaKH = BOOKING.MaKH group by KHACHHANG.TenKH, BOOKING.MaKH order by COUNT(1) desc 
--RETURN @m
--END

--select dbo.getkhmaxtour();
--GO
--DECLARE @l varchar(10) ='k00', @k varchar(10) ='1', @v varchar(10),@t int = 2, @e int =50
--while @t<@e
--	begin
--		select  @l + + CONVERT(nvarchar,@t)
--		set @t = @t +1
--	end

