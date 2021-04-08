
CREATE VIEW Auth.AuthUsers
AS

SELECT
	users.user_login
	,users.user_password
	,fs.fs_id
	,ps.ps_id
	,deps.dep_id
	, IIF(roles.role_id = 1,

		CASE 

		when p.post_id in (755,756,42)
		then 2

		else deps.role_id

		end,

		roles.role_id) as id_role_actual

	--, IIF(roles.role_id = 1,

	--	CASE

	--	when p.post_id in (755,756,42)
	--	then 'Заведующий'

	--	else deps.role_id

	--	end,

	--	roles.role_name) as name_role_actual

FROM hod.Auth.Users as users

	-- FactStaff
	inner join hod.Import.FactStaffs as fs on fs.fs_id = users.fs_id

	-- PlanStaff (возможно тут можно и по factStaff найти)
	inner join hod.Import.PlanStaffs as ps on ps.ps_id = fs.ps_id

	-- Должности
	inner join hod.Import.Posts as p on p.post_id = ps.post_id

	-- Отделы
	inner join hod.Import.Departments as deps on deps.dep_id = ps.dep_id

	-- Роли
	inner join hod.Auth.Roles as roles on roles.role_id = deps.role_id

	-- Преподаватели
	--left join hod.Import.KafTeachers as teachs on teachs.fsh_id = users.fsh_id
