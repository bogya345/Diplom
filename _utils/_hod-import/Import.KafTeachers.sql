
SELECT TOP (1000)
	[idEmployee]
	--,EmployeeGUID -- for my project need only id
	,[PostGUID]
	,[DepartmentGUID]
	,teachs.[DateBegin]
	,[DateEnd]
	,teachs.[StaffCount]
	,teachs.[HourCount]
	,[Login]
	,[PPSStuff]
	,[HourlyLoad]
	,idFactStaffHistory

	--[TypeWorkName]	-- are it usefull?
	--,[EmployeeGUID] -- cause we have id employee
	--,[FirstName]	-- cause we have id employee
	--,[LastName]	-- cause we have id employee
	--,[Otch]	-- cause we have id employee
	--,[idFactStaffHistory]
	--,[isPPS]	- idk exaclty what for that flag
	--,[DegreeScienceName] -- idk yet how to get it

FROM UGTU.Import.KafTeachers as teachs
	--inner join hod.Import.Departments as deps on deps.dep_guid = teachs.DepartmentGUID
	--inner join hod.Import.WorkTypes as workTypes on RTRIM(LTRIM(workTypes.workType_name)) = RTRIM(LTRIM(teachs.TypeWorkName)) collate Cyrillic_General_CI_AS
	--inner join hod.Import.WorkTypes as workTypes on HASHBYTES('MD4', workTypes.workType_name) = HASHBYTES('MD4', teachs.TypeWorkName) -- collate Cyrillic_General_CI_AS
	inner join hod.Import.FactStaffHistories as fsh on fsh.fsh_id = teachs.idFactStaffHistory

	-- get WorkTypes
	inner join hod.Import.WorkTypes as works on works.workType_id = fsh.workType_id

WHERE teachs.DateEnd is null
	--and FirstName like '%Ал%на%'