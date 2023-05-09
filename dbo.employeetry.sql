CREATE TABLE [dbo].[employeetry] (
    [employee_id]          INT           IDENTITY (1, 1) NOT NULL,
    [employee_name]        NVARCHAR (50) NOT NULL,
    [employee_addr]        NVARCHAR (50) NOT NULL,
    [employee_contact]     NVARCHAR (50) NOT NULL,
    [email]                NVARCHAR (50) NOT NULL,
    [citizenhsip_no]       NVARCHAR (50) NOT NULL,
    [father_name]          NVARCHAR (50) NOT NULL,
    [age_sex]              NVARCHAR (50) NOT NULL,
    [realationship_status] NVARCHAR (50) NOT NULL,
    [username]             NVARCHAR (50) NOT NULL,
    [password]             NVARCHAR (50) NOT NULL,
    [type]                 NVARCHAR (50) NOT NULL,
    [dob]                  DATETIME      NULL
);

