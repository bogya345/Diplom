/****** Скрипт для команды SelectTopNRows из среды SSMS  ******/
SELECT TOP (1000) [group_id]
      ,[dir_id]
      ,[group_name]
      ,[YearArrive]
      ,[DateCreate]
      ,[DateExit]
      ,[acPl_id]
  FROM [hod].[Import].[Groups]

  --`UPDATE [hod].[Import].[Groups] SET dir_id = 11016 WHERE group_id = 9678
  --UPDATE [hod].[Import].[Groups] SET dir_id = 11017 WHERE group_id = 9918
  --UPDATE [hod].[Import].[Groups] SET dir_id = 11020 WHERE group_id = 10446