
--CREATE VIEW Export.DepProperty
--AS

SELECT TOP 100
	dirs.direct_id,
	--dirs.

	groups.group_id,
	groups.group_name,
	--groups.

	loads.fsh_id,
	loads.LoadValue,
	loads.sub_name,
	loads.subType_name,
	--loads.dep_guid,
	--loads.

	teachInfo.fsh_id,
	teachInfo.emp_id,
	teachInfo.LastName,
	teachInfo.FirstName,
	teachInfo.Otch


FROM hod.Import.Directions as dirs

	-- Группы
	inner join hod.Import.Groups as groups on groups.direct_id = dirs.direct_id --and groups.group_name like N'%ст%17%'
	
	-- Учебные планы
	left join hod.dbo.AcademicPlans as plans on plans.direct_id = dirs.direct_id

	-- Записи учебного плана
	inner join hod.dbo.BlockRecs as recs on recs.acPlan_id = plans.acPlan_id

	-- Представление: Нагрузка 
	left join hod.dbo.Loads as loads on loads.acPlan_id = plans.acPlan_id

	-- Представление: Инфа по преподавателям
	left join hod.dbo.TeacherInfo as teachInfo on teachInfo.fsh_id = loads.fsh_id

	--inner join hod.dbo.BlockRecs as recs recs.acPlan_id = plans.acPlan_id

	