
DROP VIEW dbo.DepsInfo

CREATE VIEW dbo.DepsInfo
AS

SELECT 
--DISTINCT -- по идее это гребанный костыль
	deps.dep_id
	,deps.dep_guid
	,deps.dep_name
	,count(group_id) as count_groups
	--,grs.group_name
	,emps.FirstName
	,emps.LastName
	,emps.MiddleName

FROM hod.Import.Departments as deps

	-- Направления
	inner join hod.Import.Directions as dirs on dirs.dep_id = deps.dep_id
	-- Обучение
	inner join hod.Import.EducBranches as ebs on ebs.eBr_id = dirs.eBr_id

	-- Группы
	inner join hod.Import.Groups as grs on grs.dir_id = dirs.dir_id
		and grs.DateExit > getdate()

	left join (
		SELECT
			ps.dep_id 
			,ps.ps_id
			--,emps.emp_guid
			--,emps.emp_id
			,emps.LastName
			,emps.FIrstName
			,emps.MiddleName
		FROM hod.Import.PlanStaffs as ps

			-- FactStaff
			left join hod.Import.FactStaffs as fs on fs.ps_id = ps.ps_id

			-- Сотрудники (для имен и прочего)
			left join hod.Import.Employees as emps on emps.emp_id = fs.emp_id
				--and emps.LastName like N'%дорог%'

		WHERE ps.post_id in (755,756,42)
	) as emps on emps.dep_id = deps.dep_id


	---- Преподаватели кафедр (но нужны только заведующие)
	--inner join hod.Import.KafTeachers as teachs on teachs.dep_guid = deps.dep_guid 
	----full outer join hod.Import.KafTeachers as teachs on teachs.dep_guid = deps.dep_guid 
	--	and teachs.DateEnd is null
	--	--and teachs.post_guid in ('E53AEDE9-68C0-E111-8738-0018FE865BEC','A8140994-7FAD-437E-B4C0-69DEFBBA3A19','F5E2E1C5-402C-4E94-A506-A737EA6D5EF8') -- заведующий

GROUP BY
	deps.dep_id 
	,deps.dep_guid
	,deps.dep_name
	,emps.FirstName
	,emps.LastName
	,emps.MiddleName
