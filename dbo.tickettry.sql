CREATE TABLE [dbo].[tickettry] (
    [ticket_id]     INT           IDENTITY (1, 1) NOT NULL,
    [ticket_no]     NVARCHAR (50) NOT NULL,
    [p_name]        NVARCHAR (50) NOT NULL,
    [p_addr]        NVARCHAR (50) NOT NULL,
    [p_contact]     BIGINT        NOT NULL,
    [age_sex]       NVARCHAR (50) NOT NULL,
    [no_of_tickets] INT           NOT NULL,
    [t_from]        NVARCHAR (50) NOT NULL,
    [t_to]          NVARCHAR (50) NOT NULL,
    [bus_no]        NVARCHAR (50) NOT NULL,
    [bus_type]      NVARCHAR (50) NOT NULL,
    [price]         FLOAT (53)    NOT NULL,
    [seat]          NVARCHAR (50) NULL,
    [date]          DATETIME      NULL,
    [time]          NVARCHAR (50) NULL
);

