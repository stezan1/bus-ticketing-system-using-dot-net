-- ================================================
-- Template generated from Template Explorer using:
-- Create Trigger (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[trg_del1]
   ON  [dbo].[employee]
   AFTER DELETE
AS 
BEGIN
	declare @employee_id int;
	declare @employee_name nvarchar(50);
	declare @age_sex nvarchar(50);
	declare @employee_addr nvarchar(50);
	declare @employee_contact nvarchar(50);

	


	select @employee_id=employee.employee_id from deleted employee;
	select @employee_name=employee.employee_name from deleted employee;
	select @age_sex=employee.age_sex from deleted employee;
	select @employee_addr=employee.employee_addr from deleted employee;
	select @employee_contact=employee.employee_contact from deleted employee;


	insert into deleted_data(id,name,age,address,phone_no)
	values(@employee_id,@employee_name,@age_sex,@employee_addr,@employee_contact);

END
GO