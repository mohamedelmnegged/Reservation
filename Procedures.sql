create procedure addOrEditPaient 
@fullName nvarchar(250),@address nvarchar(250), @phone nvarchar(13), @gender bit, @birthdate date,@country nvarchar(50), @id int
as 
	declare @Msg as nvarchar(50) = ''; 
	declare @NewId as INT = -1; 

	if(@id is not null)
	begin 
		update Paient 
		set FullName = @fullName, Address = @address, Phone = @phone, Geneder = @gender, BirthDate = @birthdate, Country = @country 
		where Id = @id

		set @Msg = 'Updated Successfully' 
		set @NewId = SCOPE_IDENTITY()
	end
	if(@id is null)
	begin 
		insert into Paient values(@fullName, @address, @phone, @gender, @birthdate, @country)

		set @Msg = 'Inserted Successfully' 
		set @NewId = SCOPE_IDENTITY()
	end

	select @Msg as ReturnedMsg, @NewId as Id
go;


Create procedure deletePaient 
@id int
as  
	declare @Msg as nvarchar(50) = ''; 
	declare @NewId as INT = -1;  

	if(@id is not null) 
	begin 
		delete from Paient where Id = @id

		set @Msg = 'Deleted Successfully' 
		set @NewId = SCOPE_IDENTITY()
	end

	select @Msg as ReturnedMsg, @NewId as Id
go; 


create procedure addOrEditAppointment 
@startDate datetime, @endDate datetime,@type tinyint, @status tinyint, @paientId int, @id int
as 

	declare @Msg as nvarchar(50) = ''; 
	declare @NewId as INT = -1; 
	
	if(@id is null)
	begin 
		if(@startDate is not null and @endDate is not null and @endDate >= @startDate) 
		begin 
			declare @countConfilectsWithAdd as int ; 
			select @countConfilectsWithAdd = count(*)  from Appointment where
			(@startDate >= StartDate and @startDate <= EndDate )
			or 
			(@endDate >= StartDate and @endDate <= EndDate);
			
			if(@countConfilectsWithAdd = 0) 
			begin 
				insert into Appointment values(@startDate, @endDate, @type, @status, @paientId, DATEDIFF(hour, @startDate, @endDate) ) 
				set @NewId= SCOPE_IDENTITY()
				set @Msg = 'Inserted Successfully'; 
				--return @Msg
			end
			if(@countConfilectsWithAdd > 0) 
			begin 
				--print 'this Appointment dates is busy'
				set @Msg = 'this Appointment dates is busy'
				
			end
		end
	end
	if(@id is not null)
	begin 
		--validate the dates first 
		declare @countConfilectsWithUpdate as int = 0;
		
		select @countConfilectsWithUpdate = count(*) from Appointment where Id != @id and (
		(@startDate >= StartDate and @startDate <= EndDate )
		or 
		(@endDate >= StartDate and @endDate <= EndDate) );
		
		if(@countConfilectsWithUpdate = 0)
		begin 
			update Appointment set Type = @type, Status = @status, StartDate = @startDate, EndDate = @endDate, Period =  DATEDIFF(hour, @startDate, @endDate)
			where Id = @id

			set @Msg = 'Updated Successfully'
		end
		if(@countConfilectsWithUpdate > 0) 
		begin 
			set @Msg = 'this Appointment dates is busy'
		end
		select @Msg as returnedMsg,
			   @NewId AS ID
	end
go; 


create procedure deleteAppointment
@id int
as 
	declare @Msg as nvarchar(50) = ''; 
	declare @NewId as INT = -1; 

	if(@id is not null) 
	begin 
		delete from Appointment where Id = @id

		set @Msg = 'Deleted Successfully' 
		set @NewId = SCOPE_IDENTITY()
	end

	if(@id is null)
	begin 
		set @Msg = 'Id Shouldnot be null' 
		set @NewId = SCOPE_IDENTITY()
	end

	select @Msg as ReturnedMsg, @NewId as Id
go; 

create procedure getPaients 
as
	select * from Paient
go; 

create procedure getPaientById 
@id int
as 
	select * from Paient where Id = @id 
go; 

create procedure getPaientByName
@name nvarchar(250)
as 
	select * from Paient where FullName like CONCAT('%', @name, '%')
go; 

create procedure getPaientByBirthDate
@birthDate date
as 
	select * from Paient where BirthDate = @birthDate
go; 

create procedure getAppointments 
as 
	select * from Appointment
go; 

create procedure getAppointmentById
@id int
as 
	select * from Appointment where Id = @id
go; 

create procedure getAppointmentByDate
@startDate datetime, @endDate datetime
as 
	select * from Appointment where  (StartDate between @startDate and @endDate )  and (EndDate between @startDate and @endDate)
go; 

Create procedure addOrEditUser 
@name nvarchar(250), @email nvarchar(250), @password text, @id int
as  
	declare @Msg as nvarchar(50) = ''; 
	declare @NewId as INT = -1; 
	
	if(@id is null)
	begin 
		insert into [dbo].[User] values(@name, @email, @password)
		set @Msg = 'Inserted Successfully' 
		set @NewId = SCOPE_IDENTITY()
	end 
	if(@id is not null) 
	begin 
		update [dbo].[User] set Name = @name, Email = @email, Password = @password 
		where Id = @id;

		set @Msg = 'Updated Successfully' 
	end

	select @Msg as ReturnedMsg, @NewId as InsertedId
go; 

create procedure deleteUser
@id int
as
	declare @Msg as nvarchar(50) = ''; 
	declare @NewId as INT = -1;
	delete from [dbo].[User] where Id = @id
	set @Msg = 'Deletd Successfully' 
	set @NewId = SCOPE_IDENTITY()
	select @Msg as ReturnedMsg, @NewId as InsertedId 
go; 

create procedure getUser
@id int 
as	
	select * from [dbo].[User] where Id = @id
go; 


--create procedure addAppointment 
--@startDate date, @endDate date,@type tinyint, @status tinyint, @paientId int 
--as 
--	if(@paientId is not null)
--	begin 
--		insert into Appointment values(@startDate, @endDate, @type, @status, @paientId)
--	end
-- go; 


--create procedure editAppointment 
--@startDate date, @endDate date,@type tinyint, @status tinyint, @paientId int 
--as 
--	if(@paientId is not null and @startDate is not null and @endDate is not null)
--	begin 
--		update Appointment set Type = @type, Status = @status 
--		where StartDate = @startDate and EndDate = @endDate and Paient_Id = @paientId
--	end
-- go; 

