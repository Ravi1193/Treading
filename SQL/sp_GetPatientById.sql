USE [Treading]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetPatientById]    Script Date: 4/22/2021 6:51:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROC [dbo].[sp_GetPatientById]
(
@id int
)
as begin
 select * from patients where id=@id
end