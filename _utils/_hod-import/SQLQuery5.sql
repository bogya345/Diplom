/****** Скрипт для команды SelectTopNRows из среды SSMS  ******/
SELECT TOP (1000) [workType_name], HASHBYTES('SHA1', [workType_name]) as result
  FROM [hod].[Import].[WorkTypes]
  ORDER BY [workType_name]

SELECT TOP (1000) TypeWorkName, HASHBYTES('SHA1', TypeWorkName)  as result
  FROM UGTU.Import.KafTeachers
  GROUP BY TypeWorkName
  ORDER BY TypeWorkName

--ALTER TABLE [hod].[Import].[WorkTypes] ALTER COLUMN [workType_name] nvarchar(50)