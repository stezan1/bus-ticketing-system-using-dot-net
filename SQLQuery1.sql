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
CREATE TRIGGER [dbo].[trg1_ticket]
   ON  [dbo].[ticket]
   AFTER DELETE
AS 
BEGIN
	declare @ticket_id int;
	declare @ticket_no nvarchar(50);
	declare @p_name nvarchar(50);
	declare @p_addr nvarchar(50);
	declare @p_contact int;
	declare @age_sex nvarchar(50);
	declare @no_of_tickets int;

	select @ticket_id=tickets.ticket_id from deleted tickets;
	select @ticket_no=tickets.ticket_no from deleted tickets;
	select @p_name=tickets.p_name from deleted tickets;
	select @p_addr=tickets.p_addr from deleted tickets;
	select @p_contact=tickets.p_contact from deleted tickets;
	select @age_sex=tickets.age_sex from deleted tickets;
	select @no_of_tickets=tickets.no_of_tickets from deleted tickets;

	insert into deleted_tickets(ticket_id,ticket_no,p_name,p_addr,p_contact,age_sex,no_of_tickets)
	values(@ticket_id,@ticket_no,@p_name,@p_addr,@p_contact,@age_sex,@no_of_tickets)

END
GO