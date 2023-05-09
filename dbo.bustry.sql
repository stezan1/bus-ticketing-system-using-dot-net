CREATE TABLE [dbo].[bustry] (
    [bus_id]         INT           IDENTITY (1, 1) NOT NULL,
    [bus_no]         NVARCHAR (50) NOT NULL,
    [bus_name]       NVARCHAR (50) NOT NULL,
    [bus_type]       NVARCHAR (50) NOT NULL,
    [no_of_seats]    NVARCHAR (50) NOT NULL,
    [bus_time]       DATETIME      NOT NULL,
    [bus_model]      NVARCHAR (50) NOT NULL,
    [driver_name]    NVARCHAR (50) NOT NULL,
    [conductor_name] NVARCHAR (50) NOT NULL,
    [route_from]     NVARCHAR (50) NOT NULL,
    [route_to]       NVARCHAR (50) NOT NULL,
    [route_price]    INT           NOT NULL, 
    [driver_contact] NVARCHAR(50) NOT NULL, 
    [conductor_contact] NVARCHAR(50) NOT NULL
);

