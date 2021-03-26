
--CREATE VIEW AuthUsers
--AS

SELECT
	users.user_login,
	users.user_password,
	users.role_id,
	teachs.dep_guid

FROM hod.Auth.Users as users

	-- Роли
	inner join hod.Auth.Roles as roles on roles.role_id = users.role_id

	-- Преподаватели
	left join hod.Import.KafTeachers as teachs on teachs.fsh_id = users.fsh_id
