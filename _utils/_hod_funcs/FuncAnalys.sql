/****** Скрипт для команды SelectTopNRows из среды SSMS  ******/

CREATE FUNCTION FuncAnalys()
RETURNS @result TABLE(ke)
as
begin

	DECLARE @all as INTEGER;

	SELECT @all = count([attAcPl_id])
	FROM [hod].[dbo].[AttachedAcPlans]
	where group_id = 9918

	PRINT @all

	---

	DECLARE @submited as INTEGER;

	SELECT @submited = count([attAcPl_id])
	FROM [hod].[dbo].[AttachedAcPlans]
	where group_id = 9918 and fsh_id is not null

	PRINT @submited

	---
	return
end