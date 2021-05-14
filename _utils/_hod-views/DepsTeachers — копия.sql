
--CREATE VIEW dbo.DepsTeachers
--AS

SELECT
	deps.dep_id,
	--deps.dep_name,
	subs.sub_id,
	subs.sub_name


FROM hod.Import.Departments as deps
	
	-- Предметы
	inner join hod.dbo.Subjects as subs on subs.dep_id = deps.dep_id

	inner join (
		SELECT
			emps.emp_id,
			deps.dep_id

		FROM hod.Import.Employees as emps
			inner join hod.Import.FactStaffs as fs on fs.emp_id = emps.emp_id
			inner join hod.Import.PlanStaffs as ps on ps.ps_id = fs.ps_id
				and ps.post_id in (
					'48',	-- преподаватель ВПО
					'47',	-- старший преподаватель
					'46',	-- доцент
					'753',	-- доцент (к.н.)
					'754',	-- доцент (д.н.)
					'748',	-- старший преподаватель (к.н.)
					'759'	-- преподаватель (ВПО) (к.н.)
				)
				--and ps.post_guid in (
				--	'DF3AEDE9-68C0-E111-8738-0018FE865BEC',	-- преподаватель ВПО
				--	'E13AEDE9-68C0-E111-8738-0018FE865BEC',	-- старший преподаватель
				--	'E23AEDE9-68C0-E111-8738-0018FE865BEC',	-- доцент
				--	'7FEDA297-0AD1-48B6-9B4D-20611BD593A3',	-- доцент (к.н.)
				--	'648C0496-E7F6-4661-9C35-6FED730E567A'	-- доцент (д.н.)
				--	)
			inner join hod.Import.FactStaffsHistory as fsh on fsh.fs_id = fs.fs_id
			inner join hod.Import.Departments as deps on deps.dep_id = ps.dep_id
	) as teachs on teachs.emp_id = 

	-- Роли
	inner join hod.Auth.Roles as roles on roles.role_id = users.role_id

	-- Преподаватели
	left join hod.Import.KafTeachers as teachs on teachs.fsh_id = users.fsh_id
